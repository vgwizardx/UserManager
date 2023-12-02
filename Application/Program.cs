using System.Reflection;
using Domain.Interfaces.Services;
using Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Serilog;
using UserManager.Application.API.Services;
using Utilities.Middleware;
using UserManager.Application.API.Data.Contexts;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, 
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});
var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUsername = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Host={dbHost};Database={dbName};Username={dbUsername};Password={dbPassword};Server={dbServer}";

builder.Services.AddNpgsql<UserManagerDbContext>(connectionString);
builder.Services.AddScoped<IUserManagerRepository, UserManagerRepository>();
builder.Services.AddSingleton<UserSeeder>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<CorrelationIdMiddleware>();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

//app.UseAuthorization();

#region Middlewares
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
#endregion


app.MapControllers();

UpdateDatabase(app);

app.Run();


void UpdateDatabase(IApplicationBuilder app)
{
    if (app == null) throw new ArgumentNullException(nameof(app));

    using var serviceScope = app.ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope();
    using var context = serviceScope
        .ServiceProvider
        .GetService<UserManagerDbContext>();

    if (context == null) throw new ArgumentNullException(nameof(UserManagerDbContext));
        context.Database.Migrate();
}
