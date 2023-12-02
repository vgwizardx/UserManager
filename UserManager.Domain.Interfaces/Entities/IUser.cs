using Domain.ValueObjects;

namespace Domain.Interfaces.Entities;

public interface IUser
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string StreetAddress { get; set; }
    string City { get; set; }
    string State { get; set; }
    string ZipCode { get; set; }
    int Age { get; set; }
    IEmail Email { get; set; }
}