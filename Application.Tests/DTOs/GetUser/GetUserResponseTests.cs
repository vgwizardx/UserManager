using Domain.Common.DTOs;

namespace UserManager.Application.API.Tests.DTOs.GetUser;

public class GetUserResponseTests
{
    [Fact]
    public void Should_AssignAndRetrievePropertiesCorrectly_When_PropertiesAreValid()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstName = "John";
        var lastName = "Doe";
        var email = "john.doe@example.com";

        // Act
        var response = new GetUserResponse
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        // Assert
        Assert.Equal(id, response.Id);
        Assert.Equal(firstName, response.FirstName);
        Assert.Equal(lastName, response.LastName);
        Assert.Equal(email, response.Email);
    }

    [Fact]
    public void Should_AcceptNullValues_When_NullablePropertiesAreSetToNull()
    {
        // Arrange & Act
        var response = new GetUserResponse
        {
            FirstName = null,
            LastName = null,
            Email = null
        };

        // Assert
        Assert.Null(response.FirstName);
        Assert.Null(response.LastName);
        Assert.Null(response.Email);
    }
}