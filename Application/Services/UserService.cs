using Domain.Common.DTOs;
using Domain.Interfaces.DTOs;
using Domain.Interfaces.Services;
using Infrastructure.Repositories;

namespace UserManager.Application.API.Services;

/// <summary>
/// Provides services for managing user data.
/// </summary>
public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserManagerRepository _userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="logger"></param>
    public UserService(ILogger<UserService> logger, IUserManagerRepository userRepository)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>A task that represents the asynchronous operation. 
    /// The task result contains the <see cref="IGetUserResponse"/> with user details.</returns>
    public async Task<IGetUserResponse?> GetAsync(Guid id)
    {
        // Using AutoBogus to generate a fake response
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return null;
        }

        var userResponse = new GetUserResponse
        {
            FirstName = user?.FirstName,
            LastName = user?.LastName,
            StreetAddress = user?.StreetAddress,
            City = user?.City,
            State = user?.State,
            ZipCode = user?.ZipCode,
            Age = user?.Age ?? throw new NullReferenceException("The value of 'user?.Age' should not be null"),
            Email = user.Email
        };

        return userResponse;
    }

    /// <summary>
    /// Retrieves a list of all users.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. 
    /// The task result contains the <see cref="IGetUserListResponse"/> with the list of users.</returns>
    public async Task<IGetUserListResponse?> GetAsync()
    {
        var users = await _userRepository.GetAllAsync();

        var getUserListResponse = new GetUserListResponse
        {
            Users = users.Select(user => new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StreetAddress = user.StreetAddress,
                City = user.City,
                State = user.State,
                ZipCode = user.ZipCode,
                Age = user.Age,
                Email = user.Email
            })
        };

        return getUserListResponse;
    }

    /// <summary>
    /// Adds a new user to the system.
    /// </summary>
    /// <param name="request">The user data to add.</param>
    /// <returns>A task that represents the asynchronous operation. 
    /// The task result contains the <see cref="IAddUserResponse"/> with the added user's details.</returns>
    public async Task<IAddUserResponse?> AddUserAsync(IAddUserRequest request)
    {      
        var user = new UserDTO
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            StreetAddress = request.StreetAddress,
            City = request.City,
            State = request.State,
            ZipCode = request.ZipCode,
            Age = request.Age,
            Email = request.Email
        };

       var addResponse = await _userRepository.AddAsync(user);
       await _userRepository.SaveChangesAsync();

        var response = new AddUserResponse
        {
            Email = user.Email,
            Id = (Guid)addResponse
        };

        return await Task.FromResult(response);
    }

    /// <summary>
    /// Deletes a user from the system.
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete.</param>
    /// <returns>A task that represents the asynchronous operation. 
    /// The task result is a boolean indicating whether the deletion was successful.</returns>
    public async Task<bool> DeleteUserAsync(Guid id)
    {
        try
        {
            await _userRepository.Delete(id);
            return await _userRepository.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Unable to delete user {id}, exception: {@e}", id, e);
        }
        return false;
    }

    /// <summary>
    /// Updates a user's information.
    /// </summary>
    /// <param name="id">The unique identifier of the user to update.</param>
    /// <param name="request">The updated user data.</param>
    /// <returns>A task that represents the asynchronous operation. 
    /// The task result contains the <see cref="IUpdateUserResponse"/> with the updated user's details.</returns>
    public async Task<IUpdateUserResponse?> UpdateUserAsync(Guid id, IUpdateUserRequest request)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(id);
        if (userToUpdate == null)
        {
            return null; 
        }

        if (!string.IsNullOrEmpty(request.FirstName) && request.FirstName != userToUpdate.FirstName)
        {
            userToUpdate.FirstName = request.FirstName;
        }

        if (!string.IsNullOrEmpty(request.LastName) && request.LastName != userToUpdate.LastName)
        {
            userToUpdate.LastName = request.LastName;
        }

        if (!string.IsNullOrEmpty(request.StreetAddress) && request.StreetAddress != userToUpdate.StreetAddress)
        {
            userToUpdate.StreetAddress = request.StreetAddress;
        }

        if (!string.IsNullOrEmpty(request.City) && request.City != userToUpdate.City)
        {
            userToUpdate.City = request.City;
        }

        if (!string.IsNullOrEmpty(request.State) && request.State != userToUpdate.State)
        {
            userToUpdate.State = request.State;
        }

        if (!string.IsNullOrEmpty(request.ZipCode) && request.ZipCode != userToUpdate.ZipCode)
        {
            userToUpdate.ZipCode = request.ZipCode;
        }

        if (request.Age != 0 && request.Age != userToUpdate.Age)
        {
            userToUpdate.Age = request.Age;
        }

        if (!string.IsNullOrEmpty(request.Email) && request.Email != userToUpdate.Email)
        {
            userToUpdate.Email = request.Email;
        }

        _userRepository.Update(userToUpdate);
        await _userRepository.SaveChangesAsync();

        var updateUserResponse = new UpdateUserResponse
        {
            FirstName = userToUpdate?.FirstName,
            LastName = userToUpdate?.LastName,
            StreetAddress = userToUpdate?.StreetAddress,
            City = userToUpdate?.City,
            State = userToUpdate?.State,
            ZipCode = userToUpdate?.ZipCode,
            Age = userToUpdate!.Age,
            Email = userToUpdate?.Email,
            Id = userToUpdate!.Id
        };

        return updateUserResponse;
    }
}
