using Domain.Interfaces.DTOs;

namespace Domain.Common.DTOs;

public class UpdateUserResponse : BaseDTO, IUpdateUserResponse
{
    public string? Email { get; set; }
}