using HealthCare.Domain.Entities;

namespace HealthCare.Application.Interfaces.RepositoryInterfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> UpdateStockQuantity(Guid id, int newQuantity);
}