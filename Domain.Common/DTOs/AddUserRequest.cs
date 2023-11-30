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
    [StringLength(100)]
    public string? StreetAddress { get; set; }
    [Required]
    [StringLength(100)]
    public string? City { get; set; }
    [Required]
    [StringLength(50)]
    public string? State { get; set; }
    [Required]
    [StringLength(10)]
    public string? ZipCode { get; set; }
    public int Age { get; set; }

    [Required]
    [StringLength(254)]
    public string? Email { get; set; }
}