using Domain.Interfaces.Entities;
using Domain.ValueObjects;

namespace UserManager.Domain.Entities;

public class User : IUser
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public int Age { get; set; }
    public IEmail Email { get; set; }

    public User(Guid id, string firstName, string lastName, string streetAddress, string city, string state, string zipCode, int age, IEmail email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name cannot be null or empty.");
        }


        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        FirstName = firstName;
        LastName = lastName;
        StreetAddress = streetAddress;
        City = city;
        State = state;
        ZipCode = zipCode;
        Age = age;
        Email = email;
    }

}
