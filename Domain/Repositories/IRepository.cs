using Domain.Entities;

namespace Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task CreateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    void Update(TEntity entity);
    void DeleteAsync(TEntity entity);

}