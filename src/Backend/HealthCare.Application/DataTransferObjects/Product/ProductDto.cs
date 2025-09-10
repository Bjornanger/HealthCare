using HealthCare.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Application.DataTransferObjects.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int QuantityInStock { get; set; }
    public Guid UnitTypeId { get; set; }
    public UnitType UnitType { get; set; } = null!;
}