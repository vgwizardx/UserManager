namespace Domain.Interfaces.DTOs;

public interface IAddUserResponse : IBaseDTO
{
    string? Email { get; set; }
}