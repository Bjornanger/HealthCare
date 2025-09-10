using HealthCare.Application.DataTransferObjects.Product;
using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Application.Interfaces.ServiceInterfaces;

namespace HealthCare.Application.Services;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;


    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddAsync(CreateProductDto createProductDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ProductDto updateProductDto, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateQuantity(Guid id, int changeAmount)
    {
        throw new NotImplementedException();
    }
}