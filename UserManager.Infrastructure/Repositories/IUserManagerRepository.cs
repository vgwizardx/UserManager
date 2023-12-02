using Domain.Interfaces.Repositories;
using Domain.Common.DTOs;

namespace Infrastructure.Repositories;

public interface IUserManagerRepository : IGenericRepository<UserDTO>
{
}