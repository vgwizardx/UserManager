using Domain.Interfaces.DTOs;

namespace Domain.Interfaces.Services;

public interface IUserService
{
    Task<IGetUserResponse?> GetAsync(Guid id);
    Task<IGetUserListResponse?> GetAsync();
    Task<IAddUserResponse?> AddUserAsync(IAddUserRequest request);
    Task<IUpdateUserResponse?> UpdateUserAsync(Guid id, IUpdateUserRequest request);
}