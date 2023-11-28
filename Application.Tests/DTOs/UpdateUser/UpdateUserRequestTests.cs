using System.ComponentModel.DataAnnotations;
using Domain.Common.DTOs;

namespace UserManager.Application.API.Tests.DTOs.UpdateUser;

public class UpdateUserRequestTests
{
    [Theory]
    [InlineData("FirstName", 101)]
    [InlineData("LastName", 101)]
    [InlineData("Email", 255)]
    public void Should_IndicateInvalid_When_PropertyExceedsMaxLength(string propertyName, int length)
    {
        // Arrange
        var request = new UpdateUserRequest();
        var property = request.GetType().GetProperty(propertyName);
        var longString = new string('a', length);
        property!.SetValue(request, longString);

        var validationContext = new ValidationContext(request);
        var validationResults = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains(propertyName));
    }

    [Theory]
    [InlineData("FirstName", 100)]
    [InlineData("LastName", 100)]
    [InlineData("Email", 254)]
    public void Should_IndicateValid_When_PropertyIsWithinMaxLength(string propertyName, int length)
    {
        // Arrange
        var request = new UpdateUserRequest();
        var property = request.GetType().GetProperty(propertyName);
        var validString = new string('a', length);
        property!.SetValue(request, validString);

        var validationContext = new ValidationContext(request);
        var validationResults = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.DoesNotContain(validationResults, r => r.MemberNames.Contains(propertyName));
    }

    [Fact]
    public void Should_IndicateValid_When_PropertiesAreNull()
    {
        // Arrange
        var request = new UpdateUserRequest(); // All properties are null

        var validationContext = new ValidationContext(request);
        var validationResults = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }
}