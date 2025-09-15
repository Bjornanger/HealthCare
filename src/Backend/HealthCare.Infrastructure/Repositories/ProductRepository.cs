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
    public async Task<bool> UpdateAsync(Product updatedProduct, Guid oldProductId)
    {
        if (updatedProduct.Id != oldProductId)
        {
            return false;
        }

        _context.Products.Update(updatedProduct);
        await _context.SaveChangesAsync();
        return true;

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
    public async Task<Product?> UpdateStockQuantity(Guid id, int newQuantity)
    {
        var productToChangeQuantityOn = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (productToChangeQuantityOn == null)
        {
            return null;
        }

        productToChangeQuantityOn.QuantityInStock = newQuantity;
        await _context.SaveChangesAsync();
        return productToChangeQuantityOn;
    }
}