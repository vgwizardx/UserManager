using Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using UserManager.Application.API.Data.Contexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UserManagerDbContext>
{
    public UserManagerDbContext CreateDbContext(string[] args)
    {
        var username = Environment.GetEnvironmentVariable("DB_USERNAME");
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
        var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};Username={username};Password={dbPassword}";

        var builder = new DbContextOptionsBuilder<UserManagerDbContext>();
        builder.UseNpgsql(connectionString);

        var seeder = new UserSeeder();

        return new UserManagerDbContext(builder.Options, seeder);
    }
}