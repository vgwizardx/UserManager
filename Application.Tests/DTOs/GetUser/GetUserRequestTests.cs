using Domain.Common.DTOs;

namespace UserManager.Application.API.Tests.DTOs.GetUser;

public class GetUserRequestTests
{

    [Fact]
    public void Should_ThrowArgumentException_When_IdIsEmptyGuid()
    {
        // Arrange
        var dto = new GetUserRequest();

        // Act
        Action act = () => dto.Id = Guid.Empty;

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Should_NotThrowException_When_IdIsValid()
    {
        // Arrange
        var dto = new GetUserRequest();
        var validGuid = Guid.NewGuid();

        // Act
        Action act = () => dto.Id = validGuid;

        // Assert
        var exceptionRecorded = Record.Exception(act);

        Assert.Null(exceptionRecorded); // No exception should be thrown
    }
}