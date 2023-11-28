using System.ComponentModel.DataAnnotations;

namespace Domain.Interfaces.DTOs;

public interface IAddUserRequest
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    public string? Email { get; set; }
}