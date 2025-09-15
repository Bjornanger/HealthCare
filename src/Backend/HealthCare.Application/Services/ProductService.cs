
using HealthCare.Application.DataTransferObjects.Product;
using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Application.Interfaces.ServiceInterfaces;
using HealthCare.Application.MappingExtensions;
using HealthCare.Domain.Entities;

namespace HealthCare.Application.Services;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;
    private readonly IUnitTypeRepository _unitTypeRepository;


    public ProductService(IProductRepository productRepository, IUnitTypeRepository unitTypeRepository)
    {
        _productRepository = productRepository;
        _unitTypeRepository = unitTypeRepository;
    }


    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        try
        {
            var productList = await _productRepository.GetAllAsync();

            if (productList is null || !productList.Any())
            {
                return Enumerable.Empty<ProductDto>();
            }

            return productList.ToProductDtoList();


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        try
        {
            var productToFind = await _productRepository.GetByIdAsync(id);

            if (productToFind is null || productToFind.Id == Guid.Empty)
            {
                return null;
            }

            return productToFind.ToProductDto();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<ProductDto> AddAsync(CreateProductDto productDto)
    {
        try
        {
            var newProduct = productDto.ToCreateProductEntity();

            var successObject = await _productRepository.AddAsync(newProduct);

            if (successObject == null)
            {
                return null;
            }
            return successObject.ToProductDto();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<bool> UpdateAsync(ProductDto updateProductDto, Guid id)
    {
        try
        {
            if (updateProductDto.UnitTypeId == Guid.Empty)
            {
                return false;
            }

            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }
               

            var unitType = await _unitTypeRepository.GetByIdAsync(updateProductDto.UnitTypeId);
            if (unitType == null)
            {
                return false;
            }

            product.Name = updateProductDto.Name;
            product.QuantityInStock = updateProductDto.QuantityInStock;
            product.UnitTypeId = unitType.Id;
            product.UnitType = unitType;

            

            var successObject = await _productRepository.UpdateAsync(product, product.Id);

            if (successObject)
            {
                return true;
            }

            return false;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var successObject = await _productRepository.DeleteAsync(id);

            if (successObject)
            {
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            //lägg in logger
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<bool> UpdateQuantity(Guid id, int changeAmount)
    {
        try
        {
            var productToChangeQuantityOn = await _productRepository.GetByIdAsync(id);
            if (productToChangeQuantityOn == null)
            {
                return false;
            }


            var newQuantity = productToChangeQuantityOn.QuantityInStock + changeAmount;
            if (newQuantity < 0)
            {
                return false;
            }


            await _productRepository.UpdateStockQuantity(id, newQuantity);
            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}