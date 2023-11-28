using Domain.Interfaces.DTOs;

namespace Domain.Common.DTOs;

public class AddUserResponse : BaseDTO, IAddUserResponse
{
    public string? Email { get; set; }
}