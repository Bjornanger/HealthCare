using HealthCare.Application.DataTransferObjects.UnitType;
using HealthCare.Application.Interfaces.ServiceInterfaces;

namespace HealthCare.Application.Services;

public class UnitTypeService : IUnitTypeService
{
    public Task<IEnumerable<UnitTypeDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UnitTypeDto?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UnitTypeDto> AddAsync(CreateUnitTypeDto createUnitTypeDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(UnitTypeDto updateUnitTypeDto, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}