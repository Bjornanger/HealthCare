using HealthCare.Application.DataTransferObjects.Product;

namespace HealthCare.Client.Interfaces;

public interface IProductApiService<TEntity> 
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity, Guid id);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateQuantityOnProductAsync(Guid id, int changeAmount);
}
