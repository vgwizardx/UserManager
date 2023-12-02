using AutoBogus;
using Bogus;
using Domain.Common.DTOs;

namespace Infrastructure.Seeders;

public class UserSeeder : IUserSeeder
{
    Faker<UserDTO>? _userFaker = null;

    public Faker<UserDTO> GetUserSeeds()
    {
        if (_userFaker is null)
        {
            return _userFaker = new AutoFaker<UserDTO>()
                .RuleFor(u => u.Id, faker => faker.Random.Guid())
                .RuleFor(u => u.FirstName, faker => faker.Name.FirstName())
                .RuleFor(u => u.LastName, faker => faker.Name.LastName())
                .RuleFor(u => u.StreetAddress, faker => faker.Address.StreetAddress())
                .RuleFor(u => u.City, faker => faker.Address.City())
                .RuleFor(u => u.State, faker => faker.Address.State())
                .RuleFor(u => u.ZipCode, faker => faker.Address.ZipCode())
                .RuleFor(u => u.Age, faker => faker.Random.Int(18, 100))
                .RuleFor(u => u.Email, faker => faker.Internet.Email());
        }
        return _userFaker;
    }
}