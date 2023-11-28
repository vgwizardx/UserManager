using Domain.Interfaces.Entities;

namespace Domain.Interfaces.Repositories;

/// <summary>
/// The repository could be broken up into CRUD interfaces. This would allow us to use ISP and SRP.
/// Since this is a sample project I choose to just use one Interface for simplicity. I added in the comments how this could
/// be refactored.
/// </summary>
public interface IUserInfoRepository
{
    // Add a new user and return the ID of the created user (ICreate)
    Task<Guid> AddUserAsync(IUser user);

    // Update an existing user and return the ID of the updated user (IUpdate)
    Task<Guid> UpdateUserAsync(IUser user);

    // Remove a user (IDelete)
    Task RemoveUserAsync(IUser user);

    // Get a user by their unique identifier (IRead)
    Task<IUser> GetUserByIdAsync(Guid userInfoId);

    // Get all users (IRead)
    Task<IEnumerable<IUser>> GetAllUsersAsync();
}

