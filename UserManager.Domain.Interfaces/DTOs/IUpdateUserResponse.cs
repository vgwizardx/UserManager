namespace Domain.Interfaces.DTOs;

public interface IUpdateUserResponse : IBaseDTO
{
    string? Email { get; set; }
}