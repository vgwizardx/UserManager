using Bogus;
using Domain.Common.DTOs;

namespace Infrastructure.Seeders
{
    public interface IUserSeeder
    {
        Faker<UserDTO> GetUserSeeds();
    }
}