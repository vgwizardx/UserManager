using Domain.Common.DTOs;
using Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<UserDTO>
{
    private readonly UserSeeder _seeder;
    private const string TableName = "User";
    private const string IndexColumnName = "Id";

    public UserConfiguration(UserSeeder seeder)
    {
        _seeder = seeder;
    }

    public void Configure(EntityTypeBuilder<UserDTO> entity)
    {
        entity.ToTable(TableName);
        entity.HasKey(x => x.Id);

        entity.HasIndex(x => x.Id)
            .HasDatabaseName(IndexColumnName)
            .IsUnique();

        entity.Property(x => x.Id)
            .HasColumnName(IndexColumnName)
            .HasColumnType("uuid")
            .HasDefaultValueSql("uuid_generate_v4()")
            .IsRequired();

        entity.HasData(_seeder.GetUserSeeds().Generate(50));

    }
}
