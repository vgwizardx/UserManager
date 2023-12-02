using Domain.Interfaces.DTOs;

namespace Domain.Interfaces.Services;

public interface IUserService
{
    Task<IGetUserResponse?> GetAsync(Guid id);
    Task<IGetUserListResponse?> GetAsync();
    Task<IAddUserResponse?> AddUserAsync(IAddUserRequest request);

    Task<bool> DeleteUserAsync(Guid id);
    Task<IUpdateUserResponse?> UpdateUserAsync(Guid id, IUpdateUserRequest request);
}