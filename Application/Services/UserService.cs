using AutoBogus;
using Domain.Common.DTOs;
using Domain.Interfaces.DTOs;
using Domain.Interfaces.Services;

namespace UserManager.Application.API.Services;

public class UserService : IUserService
{
    public async Task<IGetUserResponse?> GetAsync(Guid id)
    {
        // Using AutoBogus to generate a fake response
        var fakeUserResponse = new AutoFaker<GetUserResponse>()
            .RuleFor(u => u.FirstName, faker => faker.Name.FirstName())
            .RuleFor(u => u.LastName, faker => faker.Name.LastName())
            .RuleFor(u => u.StreetAddress, faker => faker.Address.StreetAddress())
            .RuleFor(u => u.City, faker => faker.Address.City())
            .RuleFor(u => u.State, faker => faker.Address.State())
            .RuleFor(u => u.ZipCode, faker => faker.Address.ZipCode())
            .RuleFor(u => u.Age, faker => faker.Random.Int(18, 100))
            .RuleFor(u => u.Email, faker => faker.Internet.Email()).Generate();

        return await Task.FromResult(fakeUserResponse);
    }

    public async Task<IGetUserListResponse?> GetAsync()
    {
        var userInfoFaker = new AutoFaker<User>()
            .RuleFor(u => u.FirstName, faker => faker.Name.FirstName())
            .RuleFor(u => u.LastName, faker => faker.Name.LastName())
            .RuleFor(u => u.StreetAddress, faker => faker.Address.StreetAddress())
            .RuleFor(u => u.City, faker => faker.Address.City())
            .RuleFor(u => u.State, faker => faker.Address.State())
            .RuleFor(u => u.ZipCode, faker => faker.Address.ZipCode())
            .RuleFor(u => u.Age, faker => faker.Random.Int(18, 100))
            .RuleFor(u => u.Email, faker => faker.Internet.Email());

        List<User> userInfos = userInfoFaker.Generate(5); 

        var fakeUserListResponse = new GetUserListResponse
        {
            Users = userInfos
        };

        return await Task.FromResult(fakeUserListResponse);
    }

    public async Task<IAddUserResponse?> AddUserAsync(IAddUserRequest request)
    {
        // Generating a fake response for adding a user
        var fakeAddUserResponse =  new AutoFaker<AddUserResponse>()
            .RuleFor(u => u.Email, faker => faker.Internet.Email()).Generate();

        return await Task.FromResult(fakeAddUserResponse);
    }

    public async Task<IUpdateUserResponse?> UpdateUserAsync(Guid id, IUpdateUserRequest request)
    {
        // Generating a fake response for updating a user
        var fakeUpdateUserResponse =new AutoFaker<UpdateUserResponse>()
            .RuleFor(u => u.Email, faker => faker.Internet.Email()).Generate();

        return await Task.FromResult(fakeUpdateUserResponse);
    }
}
