using Microsoft.EntityFrameworkCore;
using AutoBogus;
using Domain.Common.DTOs;
using Infrastructure.Seeders;
using Infrastructure.Configuration;


namespace UserManager.Application.API.Data.Contexts;

public class UserManagerDbContext : DbContext
{
    private readonly UserSeeder _seeder;

    public UserManagerDbContext(DbContextOptions<UserManagerDbContext> options, UserSeeder seeder)
        : base(options)
    {
        _seeder = seeder;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");
        modelBuilder.ApplyConfiguration(new UserConfiguration(_seeder));
    }

    public DbSet<UserDTO>? Users { get; set; }
}
