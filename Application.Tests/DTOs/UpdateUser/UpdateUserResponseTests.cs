using Domain.Common.DTOs;

namespace UserManager.Application.API.Tests.DTOs.UpdateUser;

public class UpdateUserResponseTests
{
    [Fact]
    public void Should_InitializePropertiesCorrectly_When_ValidValuesAreUsed()
    {
        // Arrange
        var email = "test@example.com";
        var response = new UpdateUserResponse { Email = email, Id = Guid.NewGuid() };

        // Act
        var responseId = response.Id;

        // Assert
        Assert.Equal(email, response.Email);
        Assert.NotEqual(Guid.Empty, responseId);
    }

    [Fact]
    public void Should_AllowNullEmail_When_NullEmailIsUsed()
    {
        // Arrange & Act
        var response = new UpdateUserResponse { Email = null };

        // Assert
        Assert.Null(response.Email);
    }
}


