using Domain.Interfaces.DTOs;

namespace Domain.Common.DTOs;

public class GetUserListResponse : IGetUserListResponse
{
    public IEnumerable<IUser> Users { get; set; } = new List<UserDTO>();
}