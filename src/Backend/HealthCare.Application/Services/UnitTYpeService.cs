using HealthCare.Application.DataTransferObjects.UnitType;
using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Application.Interfaces.ServiceInterfaces;
using HealthCare.Application.MappingExtensions;

namespace HealthCare.Application.Services;

public class UnitTypeService : IUnitTypeService
{
    private readonly IUnitTypeRepository _unitTypeRepository;

    public UnitTypeService(IUnitTypeRepository unitTypeRepository)
    {
        _unitTypeRepository = unitTypeRepository;
    }


    public async Task<IEnumerable<UnitTypeDto>> GetAllAsync()
    {

        try
        {
            var unitTypeList = await _unitTypeRepository.GetAllAsync();

            if (unitTypeList == null || !unitTypeList.Any())
            {
                return Enumerable.Empty<UnitTypeDto>();
            }

            return unitTypeList.ToUnitTypeDtoList();

        }
        catch (Exception e)
        {
            //lägg in logger
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<UnitTypeDto?> GetByIdAsync(Guid id)
    {
        try
        {
            var unitType = await _unitTypeRepository.GetByIdAsync(id);

            if (unitType == null)
            {
                return null;
            }

            return unitType.ToUnitTypeDto();
        }
        catch (Exception e)
        {
            //lägg in logger
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<UnitTypeDto> AddAsync(CreateUnitTypeDto createUnitTypeDto)
    {
        try
        {
            var newUnitType = createUnitTypeDto.ToCreateUnitTypeEntity();

            var successObject = await _unitTypeRepository.AddAsync(newUnitType);

           if (successObject == null)
           {
               return null;
           }

           return successObject.ToUnitTypeDto();

        }
        catch (Exception e)
        {
            //lägg in logger
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(UnitTypeDto updateUnitTypeDto, Guid id)
    {
        try
        {
            var unitTypeToUpdate = updateUnitTypeDto.UpdateFromUnitTypeDtoDtoToEntity(id);

            var successObject = await _unitTypeRepository.UpdateAsync(unitTypeToUpdate, unitTypeToUpdate.Id);

            if (!successObject)
            {
                return false;
            }

            return true;

        }
        catch (Exception e)
        {
            //lägg in logger
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var successObject = await _unitTypeRepository.DeleteAsync(id);

            if (!successObject)
            {
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            //lägg in logger
            Console.WriteLine(e);
            throw;
        }
    }
}