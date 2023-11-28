using Domain.Interfaces.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common.DTOs;

public class AddUserRequest : IAddUserRequest
{
    [Required]
    [StringLength(100)]
    public string? FirstName { get; set; }
    [Required]
    [StringLength(100)]
    public string? LastName { get; set; }
    [Required]
    [StringLength(254)]
    public string? Email { get; set; }
}