using HealthCare.Application.DataTransferObjects.Product;
using HealthCare.Application.DataTransferObjects.UnitType;
using HealthCare.Domain.Entities;

namespace HealthCare.Application.MappingExtensions;

public static class UnitTypeMappingExtensions
{
    public static UnitType ToCreateUnitTypeEntity(this CreateUnitTypeDto dto)
    {
        return new UnitType
        {

            Name = dto.Name
        };
    }


    public static UnitTypeDto ToUnitTypeDto(this UnitType entity)
    {
        return new UnitTypeDto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public static IEnumerable<UnitTypeDto> ToUnitTypeDtoList(this IEnumerable<UnitType> entities)
    {
        return entities.Select(ToUnitTypeDto);
    }

    public static UnitType UpdateFromUnitTypeDtoDtoToEntity(this UnitTypeDto dto, Guid id)
    {
        var updateUnitType = new UnitType
        {
            Id = id,
            Name = dto.Name,
         
        };
        return updateUnitType;
    }
}