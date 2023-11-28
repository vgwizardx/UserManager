using AutoBogus;
using UserManager.Domain.Entities;
using UserManager.Domain.ValueObjects;

namespace UserManager.Domain.Test.Helpers
{
    public sealed class UserFaker : AutoFaker<User>
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
                .RuleFor(u => u.Email, f => new ValueObjects.Email(f.Internet.Email()))
                .CustomInstantiator(f => new User(
                    f.Name.FirstName(),
                    f.Name.LastName(),
                    f.Address.StreetAddress(),
                    f.Address.City(),
                    f.Address.State(),
                    f.Address.ZipCode(),
                    f.Random.Int(18, 100),
                    new Email(f.Internet.Email())));
        }
    }
}
