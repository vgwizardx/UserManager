using System.ComponentModel.DataAnnotations;

namespace UserManager.Persistence.Models;

public class User
{ 
    public Guid Id { get; set; }
    [Required(ErrorMessage = "First Name is required.")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required.")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Street Address is required.")]
    public string? StreetAddress { get; set; }
    [Required(ErrorMessage = "City is required.")]
    public string? City { get; set; }
    [Required(ErrorMessage = "State is required.")]
    public string? State { get; set; }
    [Required(ErrorMessage = "Zip Code is required.")]
    public string? ZipCode { get; set; }
    [Required(ErrorMessage = "Age is required.")]
    public int Age { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    public string? Email { get; set; }
    public bool IsEditing { get; set; } = false;
    public string PropertyName { get; set; } = "";
    public string EditedValue { get; set; } = "";
}