using HealthCare.Domain.Models;

namespace HealthCare.Application.Interfaces.RepositoryInterfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> UpdateStockQuantity(Guid id, int changeAmount);
}