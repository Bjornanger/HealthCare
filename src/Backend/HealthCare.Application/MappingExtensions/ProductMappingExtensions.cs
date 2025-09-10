using HealthCare.Application.DataTransferObjects.Product;
using HealthCare.Domain.Entities;

namespace HealthCare.Application.MappingExtensions;

public static class ProductMappingExtensions
{
    public static Product ToCreateProductEntity(CreateProductDto dto)
    {
        return new Product
        {
            Name = dto.Name,
            QuantityInStock = dto.QuantityInStock,
            UnitTypeId = dto.UnitTypeId,
            UnitType = dto.UnitType
        };
    }

    public static ProductDto ToProductDto(Product entity)
    {
        return new ProductDto
        {
            Id = entity.Id,
            Name = entity.Name,
            QuantityInStock = entity.QuantityInStock,
            UnitTypeId = entity.UnitTypeId,
            UnitType = entity.UnitType
        };
    }

    public static IEnumerable<ProductDto> ToProductDtoList(this IEnumerable<Product> entities)
    {
        return entities.Select(ToProductDto);
    }

    public static Product UpdateFromProductDtoToEntity(ProductDto dto, Guid id)
    {
        var updateProduct = new Product
        {
            Id = id,
            Name = dto.Name,
            QuantityInStock = dto.QuantityInStock,
            UnitTypeId = dto.UnitTypeId,
            UnitType = dto.UnitType
        };
        return updateProduct;
    }

}