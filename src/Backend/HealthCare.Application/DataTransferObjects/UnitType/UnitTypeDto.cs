using System.ComponentModel.DataAnnotations;

namespace HealthCare.Application.DataTransferObjects.UnitType;

public class UnitTypeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}