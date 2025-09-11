
using HealthCare.Application.DataTransferObjects.Product;
using HealthCare.Domain.Entities;

namespace HealthCare.Application.MappingExtensions;

public static class ProductMappingExtensions
{
    public static Product ToCreateProductEntity(this CreateProductDto dto)
    {
        return new Product
        {
            Name = dto.Name,
            QuantityInStock = dto.QuantityInStock,
            UnitTypeId = dto.UnitTypeId
        };
    }
  
    public static ProductDto ToProductDto(this Product entity)
    {
        return new ProductDto
        {
            Id = entity.Id,
            Name = entity.Name,
            QuantityInStock = entity.QuantityInStock,
            UnitTypeId = entity.UnitTypeId,
            UnitType = entity.UnitType?.ToUnitTypeDto()
        };
    }

    public static IEnumerable<ProductDto> ToProductDtoList(this IEnumerable<Product> entities)
    {
        return entities.Select(ToProductDto);
    }

    public static Product UpdateFromProductDtoToEntity(this ProductDto dto, Guid id, UnitType unitType)
    {
        var updateProduct = new Product
        {
            Id = id,
            Name = dto.Name,
            QuantityInStock = dto.QuantityInStock,
            UnitTypeId = unitType.Id,
            UnitType = unitType
        };
        return updateProduct;
    }

}