using System.ComponentModel.DataAnnotations;
using HealthCare.Domain.Interfaces;

namespace HealthCare.Domain.Models;

public class Product : IEntity
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int QuantityInStock { get; set; }
    
}