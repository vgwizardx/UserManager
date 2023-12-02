using Domain.Interfaces.DTOs;

namespace Domain.Common.DTOs;

public class BaseDTO : IBaseDTO
{
    public Guid Id { get; set; }
}