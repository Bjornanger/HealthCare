using System.ComponentModel.DataAnnotations;
using HealthCare.Domain.Interfaces;

namespace HealthCare.Domain.Entities;

public class UnitType : IEntity
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}