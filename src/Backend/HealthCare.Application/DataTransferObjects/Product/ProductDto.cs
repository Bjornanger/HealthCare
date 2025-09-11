using HealthCare.Application.DataTransferObjects.UnitType;
using HealthCare.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Application.DataTransferObjects.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int QuantityInStock { get; set; }
    public Guid UnitTypeId { get; set; }
    public UnitTypeDto UnitType { get; set; } = null!;
}