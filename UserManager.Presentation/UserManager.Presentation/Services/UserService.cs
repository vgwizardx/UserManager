using Domain.Common.DTOs;
using Domain.Interfaces.DTOs;
using Domain.Interfaces.Services;
using Newtonsoft.Json;

namespace UserManager.Presentation.Services;

public class UserService(HttpClient httpClient, ILogger<UserService> logger) : IUserService
{

    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns></returns>
    public async Task<IGetUserListResponse?> GetAsync()
    {
        var get = await httpClient.GetAsync("api/user/");
        var resString = get.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<GetUserListResponse>(resString.Result);
    }

    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IGetUserResponse?> GetAsync(Guid id)
    {
        return await httpClient.GetFromJsonAsync<GetUserResponse>($"api/user/{id}");
    }

    /// <summary>
    /// Add new user
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<IAddUserResponse?> AddUserAsync(IAddUserRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("api/user", request);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<AddUserResponse>();
        }

        logger.LogError("Add failed - Message: {message}, status code: {statusCode}", response.RequestMessage, response.StatusCode);
        return null;
    }

    /// <summary>
    /// Delete User
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"api/user/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        logger.LogError("Delete failed - Message: {message}, status code: {statusCode}", response.RequestMessage, response.StatusCode);
        return false;
    }

    /// <summary>
    /// Update an existing user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<IUpdateUserResponse?> UpdateUserAsync(Guid id, IUpdateUserRequest request)
    {
        var response = await httpClient.PatchAsJsonAsync($"api/user/{id}", request);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UpdateUserResponse>();
        }

        logger.LogError("Update failed - Message: {message}, status code: {statusCode}", response.RequestMessage, response.StatusCode);
        return null;
    }

}