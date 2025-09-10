using HealthCare.Application.DataTransferObjects.Product;

namespace HealthCare.Application.Interfaces.ServiceInterfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(Guid id);
    Task<bool> AddAsync(CreateProductDto createProductDto);
    Task<bool> UpdateAsync(ProductDto updateProductDto, Guid id);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateQuantity(Guid id, int changeAmount);

}