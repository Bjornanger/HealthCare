using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Domain.Models;

namespace HealthCare.Infrastructure.Repositories;

public class UnitTypeRepository : IUnitTypeRepository
{
    public Task<IEnumerable<UnitType>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UnitType> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(UnitType entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(UnitType entity, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}