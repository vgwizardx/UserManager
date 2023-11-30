using Domain.Common.DTOs;
using Domain.Interfaces;
using Domain.Interfaces.DTOs;
using Domain.Interfaces.Services;
using Newtonsoft.Json;

namespace UserManager.Persistence.Services;

public class UserService(HttpClient httpClient) : IUserService
{

    // Retrieve all users
    public async Task<IGetUserListResponse?> GetAsync()
    {
        var get = await httpClient.GetAsync("api/user/");
        var resString = get.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<GetUserListResponse>(resString.Result);
        return response;
    }

    // Retrieve a specific user by ID
    public async Task<IGetUserResponse?> GetAsync(Guid id)
    {
        return await httpClient.GetFromJsonAsync<GetUserResponse>($"api/user/{id}");
    }

    // Add a new user
    public async Task<IAddUserResponse?> AddUserAsync(IAddUserRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("api/user", request);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<AddUserResponse>();
        }

        throw new InvalidOperationException("Error adding user");
    }

    // Update an existing user
    public async Task<IUpdateUserResponse?> UpdateUserAsync(Guid id, IUpdateUserRequest request)
    {
        var response = await httpClient.PatchAsync($"api/user/{id}", JsonContent.Create(request));
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UpdateUserResponse>();
        }

        throw new InvalidOperationException("Error updating user");
    }

}