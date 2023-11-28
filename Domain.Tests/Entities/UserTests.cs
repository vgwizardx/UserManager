using AutoBogus;
using JetBrains.Annotations;

namespace UserManager.Domain.Tests.Entities;

[TestSubject(typeof(Email))]
public class UserTests
{
    [Fact]
    public void Should_NotBeNull_When_UserInfoIsInitialized()
    {
        // Act
        var userInfo = new AutoFaker<User>().Generate();

        // Assert
        Assert.NotNull(userInfo);
        Assert.NotNull(userInfo.FirstName);
        Assert.NotNull(userInfo.LastName);
        Assert.NotNull(userInfo.Email);
        Assert.NotEqual(Guid.Empty, userInfo.Id);
    }

    [Theory]
    [InlineData(null, "LastName")]
    [InlineData("FirstName", null)]
    [InlineData("", "LastName")]
    [InlineData("FirstName", "")]
    public void Should_ThrowArgumentException_When_InvalidNameIsUsed(string firstName, string lastName)
    {
        // Arrange
        var user = new AutoFaker<User>().Generate();
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new User(firstName, lastName, user.StreetAddress, user.City, user.State, user.ZipCode, user.Age, user.Email));
    }


}