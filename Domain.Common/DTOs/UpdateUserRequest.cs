using System.ComponentModel.DataAnnotations;
using Domain.Interfaces.DTOs;

namespace Domain.Common.DTOs;

public class UpdateUserRequest : IUpdateUserRequest
{
    [StringLength(100)]
    public string? FirstName { get; set; }
    [StringLength(100)]
    public string? LastName { get; set; }
    [StringLength(100)]
    public string? StreetAddress { get; set; }
    [StringLength(100)]
    public string? City { get; set; }
    [StringLength(50)]
    public string? State { get; set; }
    [StringLength(10)]
    public string? ZipCode { get; set; }
    public int Age { get; set; }

    [StringLength(254)]
    public string? Email { get; set; }
}