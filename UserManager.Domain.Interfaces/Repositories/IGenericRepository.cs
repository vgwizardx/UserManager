using Domain.Interfaces.Entities;

namespace Domain.Interfaces.Repositories;

/// <summary>
/// The repository could be broken up into CRUD interfaces. This would allow us to use ISP and SRP.
/// Since this is a sample project I choose to just use one Interface for simplicity. I added in the comments how this could
/// be refactored.
/// </summary>
public interface IGenericRepository<T> where T : class
{
    // Add a new user and return the ID of the created user (ICreate)
    Task<object> AddAsync(T entity);

    // Update an existing user and return the ID of the updated user (IUpdate)
    void Update(T entity);

    // Remove a user (IDelete)
    Task<bool> Delete(object id);

    // Get a user by their unique identifier (IRead)
    Task<T?> GetByIdAsync(object id);

    // Get all users (IRead)
    Task<IEnumerable<T>> GetAllAsync();

    Task<bool> SaveChangesAsync();

}

