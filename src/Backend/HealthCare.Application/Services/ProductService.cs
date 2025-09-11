using System.Runtime.InteropServices.ComTypes;
using HealthCare.Application.DataTransferObjects.Product;
using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Application.Interfaces.ServiceInterfaces;
using HealthCare.Application.MappingExtensions;

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
            //lägg in logger
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
            //lägg in logger

            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ProductDto?> AddAsync(CreateProductDto productDto)
    {
        try
        {
            var newProduct = productDto.ToCreateProductEntity();

            var successObject = await _productRepository.AddAsync(newProduct);

            if (successObject is null)
            {
                return null;
            }
            return successObject.ToProductDto();
            
        }
        catch (Exception e)
        {
            //lägg in logger
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

            var unitType = await _unitTypeRepository.GetByIdAsync(updateProductDto.UnitTypeId);

            var productToToUpdate = updateProductDto.UpdateFromProductDtoToEntity(id, unitType);

            var successObject = await _productRepository.UpdateAsync(productToToUpdate, productToToUpdate.Id);

            if (successObject)
            {
                return true;
            }

            return false;

        }
        catch (Exception e)
        {
            //Lägg in logger
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
            var modifyStockForThisProduct = await _productRepository.UpdateStockQuantity(id, changeAmount);

            if (modifyStockForThisProduct == null)
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