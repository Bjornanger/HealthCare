using HealthCare.Application.DataTransferObjects.Product;
using HealthCare.Application.DataTransferObjects.UnitType;

namespace HealthCare.Application.Interfaces.ServiceInterfaces;

public interface IUnitTypeService
{
    Task<IEnumerable<UnitTypeDto>> GetAllAsync();
    Task<UnitTypeDto?> GetByIdAsync(Guid id);
    Task<UnitTypeDto> AddAsync(CreateUnitTypeDto createUnitTypeDto);
    Task<bool> UpdateAsync(UnitTypeDto updateUnitTypeDto, Guid id);
    Task<bool> DeleteAsync(Guid id);
}