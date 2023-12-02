using AutoBogus;
using Domain.Common.DTOs;

namespace UserManager.Domain.Test.Helpers;

public sealed class UserFaker : AutoFaker<UserDTO>
{
    public UserFaker()
    {
        RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StreetAddress, f => f.Address.StreetAddress())
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.State, f => f.Address.State())
            .RuleFor(u => u.ZipCode, f => f.Address.ZipCode())
            .RuleFor(u => u.Age, f => f.Random.Int(18, 100))
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .CustomInstantiator(f => new UserDTO
            {
                FirstName = f.Name.FirstName(),
                LastName = f.Name.LastName(),
                StreetAddress = f.Address.StreetAddress(),
                City = f.Address.City(),
                State = f.Address.State(),
                ZipCode = f.Address.ZipCode(),
                Age = f.Random.Int(18, 100),
                Email = f.Internet.Email()
            });
    }
}