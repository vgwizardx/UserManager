using Domain.Interfaces.DTOs;

namespace Domain.Common.DTOs;

public class BaseDTO : IBaseDTO
{
    
    private Guid _id;

    public Guid Id 
    { 
        get => _id;
        set
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("Id cannot be an empty GUID.");
            }
            _id = value;
        }
    }
}