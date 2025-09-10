using System.ComponentModel.DataAnnotations;
using HealthCare.Domain.Entities;

namespace HealthCare.Application.DataTransferObjects.Product;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int QuantityInStock { get; set; }
    public Guid UnitTypeId { get; set; }
    public UnitType UnitType { get; set; } = null!;
}