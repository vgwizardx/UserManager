using System.ComponentModel.DataAnnotations;
using Domain.Common.DTOs;


namespace UserManager.Application.API.Tests.DTOs.AddUser;

public class AddUserRequestTests
{

    [Fact]
    public void Should_IndicateInvalid_WhenFirstNameIsNull()
    {
        // Arrange
        var request = new AddUserRequest { FirstName = null, LastName = "Doe", Email = "test@example.com" };
        var validationContext = new ValidationContext(request);
        var validationResults = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("FirstName"));
    }


    [Fact]
    public void Should_IndicateInvalid_WhenFirstNameExceeds100Characters()
    {
        // Arrange
        var longName = new string('a', 101);
        var request = new AddUserRequest { FirstName = longName, LastName = "Doe", Email = "test@example.com" };
        var validationContext = new ValidationContext(request);
        var validationResults = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("FirstName"));
    }

    [Fact]
    public void Should_IndicateValid_WhenAllPropertiesAreValid()
    {
        
        // Arrange
        var request = new AddUserRequest
        {
            FirstName = "John",
            LastName = "Doe",
            StreetAddress = "123 street",
            City = "Michigan",
            State = "Michigan",
            ZipCode = "48654",
            Age = 56,
            Email = "test@example.com"
        };
        var validationContext = new ValidationContext(request);
        var validationResults = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }
}