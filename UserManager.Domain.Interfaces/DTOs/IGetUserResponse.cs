namespace Domain.Interfaces.DTOs;

public interface IGetUserResponse
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