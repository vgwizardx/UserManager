using UserManager.Domain.ValueObjects;
using JetBrains.Annotations;

namespace Domain.Tests.ValueObjects;

[TestSubject(typeof(Email))]
public class EmailTest
{
    [Theory]
    [InlineData("example@example.com")]
    [InlineData("test.user+test@domain.co.uk")]
    public void Should_CreateEmail_When_AddressIsValid(string validEmail)
    {
        // Act
        var email = new Email(validEmail);

        // Assert
        Assert.Equal(validEmail, email.Address);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("invalid-email")]
    [InlineData("user@invalid")]
    public void Should_ThrowArgumentException_When_AddressIsInvalid(string invalidEmail)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Email(invalidEmail));
        Assert.Equal("Invalid email address.", exception.Message);
    }
    
}