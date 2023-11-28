using Domain.Interfaces.DTOs;

namespace Domain.Common.DTOs;

public class GetUserListResponse : IGetUserListResponse
{
    public IEnumerable<IUser> Users { get; set; } = new List<User>();
}

public class User : BaseDTO, IUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; }
}