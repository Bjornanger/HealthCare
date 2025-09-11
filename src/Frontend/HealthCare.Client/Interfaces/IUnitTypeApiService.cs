using HealthCare.Application.DataTransferObjects.UnitType;
using HealthCare.Domain.Interfaces;

namespace HealthCare.Client.Interfaces;

public interface IUnitTypeApiService<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(CreateUnitTypeDto entity);
    Task<bool> UpdateAsync(TEntity entity, Guid id);
    Task<bool> DeleteAsync(Guid id);
}