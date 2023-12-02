using Domain.Common.DTOs;

namespace UserManager.Application.API.Tests.DTOs.GetUser;

public class GetUserListResponseTests
{
    [Fact]
    public void Should_InitializeUsersCollection_When_Constructed()
    {
        // Act
        var response = new GetUserListResponse();

        // Assert
        Assert.NotNull(response.Users);
        Assert.Empty(response.Users);
    }

    [Fact]
    public void Should_HoldUserInfoObjects_When_UsersAdded()
    {
        // Arrange
        var response = new GetUserListResponse();
        var user = new UserDTO { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };

        // Act
        response.Users = new List<UserDTO> { user };

        // Assert
        Assert.Single(response.Users);
        Assert.Contains(user, response.Users);
    }

    [Fact]
    public void Should_AllowEmptyCollection_When_NoUsersAdded()
    {
        // Arrange
        var response = new GetUserListResponse();

        // Act
        response.Users = new List<UserDTO>();

        // Assert
        Assert.NotNull(response.Users);
        Assert.Empty(response.Users);
    }

    [Fact]
    public void Should_AcceptNullValuesForUserInfoProperties_When_UsersWithNullPropertiesAdded()
    {
        // Arrange
        var response = new GetUserListResponse();
        var userWithNullFields = new UserDTO { FirstName = null, LastName = null, Email = null };

        // Act
        response.Users = new List<UserDTO> { userWithNullFields };

        // Assert
        Assert.Single(response.Users);
        var addedUser = response.Users.First();
        Assert.Null(addedUser.FirstName);
        Assert.Null(addedUser.LastName);
        Assert.Null(addedUser.Email);
    }
}