using System.ComponentModel.DataAnnotations;

namespace Domain.Interfaces.DTOs;

public interface IUpdateUserRequest
{
    [StringLength(100)]
    public string? FirstName { get; set; }
    [StringLength(100)]
    public string? LastName { get; set; }
    [StringLength(254)]
    public string? Email { get; set; }
}