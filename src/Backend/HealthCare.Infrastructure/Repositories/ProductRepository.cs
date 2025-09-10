using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Domain.Entities;
using HealthCare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{

    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.Include(p => p.UnitType).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.Include(p => p.UnitType).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> AddAsync(Product entity)
    {
        var newProduct = await _context.Products.AddAsync(entity);

        await _context.SaveChangesAsync();
        return newProduct.Entity;

    }

    public async Task<bool> UpdateAsync(Product newProduct, Guid oldProductId)
    {
        var productToUpdate = await _context.Products.FirstOrDefaultAsync(p => p.Id == oldProductId);

        if (productToUpdate != null)
        {
            productToUpdate.Name = newProduct.Name;
            productToUpdate.QuantityInStock = newProduct.QuantityInStock;
            productToUpdate.UnitTypeId = newProduct.UnitTypeId;
            productToUpdate.UnitType = newProduct.UnitType;

            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var successObject = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (successObject != null)
        {
            _context.Products.Remove(successObject);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<Product?> UpdateStockQuantity(Guid id, int changeAmount)
    {
        var productQuantityToChange = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productQuantityToChange == null)
        {
            return null;
        }

        var newQuantity = productQuantityToChange.QuantityInStock + changeAmount;
        
        if (newQuantity < 0)
        {
            throw new InvalidOperationException("Storage cant be negative.");
        }
        productQuantityToChange.QuantityInStock = newQuantity;
        await _context.SaveChangesAsync();
        return productQuantityToChange;

    }
}