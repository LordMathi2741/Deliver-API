namespace Domain.Interfaces;

public interface IRepositoryGeneric<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(int id);
}