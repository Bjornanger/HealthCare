using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Domain.Models;

namespace HealthCare.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Product entity, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> UpdateStockQuantity(Guid id, int changeAmount)
    {
        throw new NotImplementedException();
    }
}