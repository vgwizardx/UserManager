using Microsoft.EntityFrameworkCore;
using Domain.Common.DTOs;
using UserManager.Application.API.Data.Contexts;

namespace Infrastructure.Repositories;

public sealed class UserManagerRepository : IUserManagerRepository
{
    private readonly UserManagerDbContext _context;
    private readonly DbSet<UserDTO> _dbSet;

    public UserManagerRepository(UserManagerDbContext context)
    {
        _context = context;
        _dbSet = context.Set<UserDTO>();
    }

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<UserDTO?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
   
    }

    /// <summary>
    /// Creates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>GUID (You mast cast the return value to type Guid)</returns>
    public async Task<object> AddAsync(UserDTO entity)
    {
        var createdEntity = await _dbSet.AddAsync(entity);

        return createdEntity.Entity.Id;
    }

    public void Update(UserDTO entity)
    {
        _dbSet.Update(entity);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public async Task<bool> Delete(object id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);
        if (entityToDelete == null)
            return false;
        _dbSet.Remove(entityToDelete);

        return true;
    }
        

    /// <summary>
    /// Save changes to the database
    /// </summary>
    /// <returns></returns>
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
    }
}