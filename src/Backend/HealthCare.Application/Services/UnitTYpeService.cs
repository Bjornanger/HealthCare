using HealthCare.Application.DataTransferObjects.UnitType;
using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Application.Interfaces.ServiceInterfaces;
using HealthCare.Application.MappingExtensions;

namespace HealthCare.Application.Services;

public class UnitTypeService : IUnitTypeService
{
    private readonly IUnitTypeRepository _unitTypeRepository;
    private readonly IProductRepository _productRepository;


    public UnitTypeService(IUnitTypeRepository unitTypeRepository, IProductRepository productRepository)
    {
        _unitTypeRepository = unitTypeRepository;
        _productRepository = productRepository;
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
    public async Task<bool> DeleteAsync(Guid unitTypeId)
    {
        try
        {

            if (unitTypeId == Guid.Parse("00000000-0000-0000-0000-000000000001"))
            {
                return false;
            }

            var productsWithUnitType = await _productRepository.GetAllAsync();

            var listOfProductsToReplaceUnitTypeOn = productsWithUnitType.Where(p => p.UnitTypeId == unitTypeId);

            var defaultValueForProducts = new UnitTypeDto
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Åtgärd krävs"
            };

            foreach (var product in listOfProductsToReplaceUnitTypeOn)
            {
                product.UnitTypeId = defaultValueForProducts.Id;
                product.UnitType.Name = defaultValueForProducts.Name;
                await _productRepository.UpdateAsync( product, product.Id);
            }

            var successObject = await _unitTypeRepository.DeleteAsync(unitTypeId);

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