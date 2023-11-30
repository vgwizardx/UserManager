namespace Domain.Interfaces.DTOs;

public interface IGetUserListResponse
{
    IEnumerable<IUser> Users { get; set; }
}

public interface IUser : IBaseDTO
{
    string? FirstName { get; set; }
    string? LastName { get; set; }
    string? StreetAddress { get; set; }
    string? City { get; set; }
    string? State { get; set; }
    string? ZipCode { get; set; }
    int Age { get; set; }
    string? Email { get; set; }

}