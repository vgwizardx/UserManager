using Domain.Common.DTOs;
using Domain.Interfaces;
using Domain.Interfaces.DTOs;
using Domain.Interfaces.Services;

namespace UserManager.Persistence.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Retrieve all users
    public async Task<IGetUserListResponse?> GetAsync()
    {
        return await _httpClient.GetFromJsonAsync<IGetUserListResponse>("api/user");
    }

    public Task<IUpdateUserResponse?> UpdateUserAsync(IUpdateUserRequest request)
    {
        throw new NotImplementedException();
    }

    // Retrieve a specific user by ID
    public async Task<IGetUserResponse?> GetAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<GetUserResponse>($"api/user/{id}");
    }

    // Add a new user
    public async Task<IAddUserResponse?> AddUserAsync(IAddUserRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/user", request);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<AddUserResponse>();
        }

        throw new InvalidOperationException("Error adding user");
    }

    // Update an existing user
    public async Task<IUpdateUserResponse?> UpdateUserAsync(Guid id, IUpdateUserRequest request)
    {
        var response = await _httpClient.PatchAsync($"api/user/{id}", JsonContent.Create(request));
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UpdateUserResponse>();
        }

        throw new InvalidOperationException("Error updating user");
    }

}