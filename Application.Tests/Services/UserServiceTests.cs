using Infrastructure.Repositories;
using Moq;
using Domain.Common.DTOs;
using UserManager.Application.API.Services;
using UserManager.Domain.Test.Helpers;
using Microsoft.Extensions.Logging;

namespace UserManager.Application.API.Tests.Services
{
    public class UserServiceTests
    {
        private readonly MockRepository _mockRepository;

        private readonly Mock<IUserManagerRepository> _mockUserManagerRepository;

        private Mock<ILogger<UserService>> _mockLogger;

        public UserServiceTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockUserManagerRepository = _mockRepository.Create<IUserManagerRepository>();

           _mockLogger =  new Mock<ILogger<UserService>>();
        }

        private UserService CreateService()
        {
            return new UserService(_mockLogger.Object, 
                _mockUserManagerRepository.Object);
        }

        [Fact]
        public async Task GetByIdAsync_Should_GetUserById_When_UserExists()
        {
            // Arrange
            var mockRepository = new Mock<IUserManagerRepository>();
            var userId = Guid.NewGuid();
            var fakeUser = new UserFaker().Generate();
            fakeUser.Id = userId;

            mockRepository.Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync(fakeUser);

            var userService = CreateService();

            // Act
            var result = await userService.GetAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fakeUser.Email, result.Email);
        }

        [Fact]
        public async Task GetAllAsync_Should_ReturnAllUsers()
        {
            // Arrange
            var mockRepository = new Mock<IUserManagerRepository>();
            var fakeUsers = new UserFaker().Generate(5);

            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(fakeUsers);

            var userService = CreateService();

            // Act
            var result = await userService.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fakeUsers.Count, result.Users.Count());
        }

        [Fact]
        public async Task AddUserAsync_Should_AddUser_When_ValidUserInfoIsUsed()
        {
            // Arrange
            var mockRepository = new Mock<IUserManagerRepository>();
            var fakeUser = new UserFaker().Generate();
            var addUserRequest = new AddUserRequest
            {
                FirstName = fakeUser?.FirstName,
                LastName = fakeUser?.LastName,
                StreetAddress = fakeUser?.StreetAddress,
                City = fakeUser?.City,
                State = fakeUser?.State,
                ZipCode = fakeUser?.ZipCode,
                Age = fakeUser!.Age,
                Email = fakeUser?.Email
            };
            var userToAdd = new UserDTO
            {
                /* properties set from addUserRequest */
            };

            mockRepository.Setup(repo => repo.AddAsync(It.IsAny<UserDTO>()))
                .ReturnsAsync(userToAdd.Id);
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var userService = CreateService();

            // Act
            var result = await userService.AddUserAsync(addUserRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userToAdd.Id, result.Id);
        }

        [Fact]
        public async Task DeleteUserAsync_Should_DeleteUser_When_AValidUserToDeleteIsUsed()
        {
            // Arrange
            var mockRepository = new Mock<IUserManagerRepository>();
            var userId = Guid.NewGuid();

            mockRepository.Setup(repo => repo.Delete(userId)).Verifiable();
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var userService = CreateService();

            // Act
            var result = await userService.DeleteUserAsync(userId);

            // Assert
            Assert.True(result);
            mockRepository.Verify(repo => repo.Delete(userId), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_Should_WhatWeDo_When_WhatBeHappening()
        {
            // Arrange
            var mockRepository = new Mock<IUserManagerRepository>();
            var userId = Guid.NewGuid();
            var fakeUser = new UserFaker().Generate();
            var updateUserRequest = new UpdateUserRequest()
            {
                FirstName = fakeUser?.FirstName,
                LastName = fakeUser?.LastName,
                StreetAddress = fakeUser?.StreetAddress,
                City = fakeUser?.City,
                State = fakeUser?.State,
                ZipCode = fakeUser?.ZipCode,
                Age = fakeUser!.Age,
                Email = fakeUser?.Email
            };
            var existingUser = new UserFaker().Generate();
            var oldEmail = existingUser.Email;
            existingUser.Id = userId;
            existingUser.Email = fakeUser!.Email;

            mockRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(existingUser);
            mockRepository.Setup(repo => repo.Update(It.IsAny<UserDTO>())).Verifiable();
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var userService = CreateService();

            // Act
            var result = await userService.UpdateUserAsync(userId, updateUserRequest);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(existingUser.Email, oldEmail);
            mockRepository.Verify(repo => repo.Update(It.IsAny<UserDTO>()), Times.Once);
        }
    }
}
