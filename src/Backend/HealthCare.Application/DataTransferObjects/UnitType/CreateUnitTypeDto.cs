using System.ComponentModel.DataAnnotations;

namespace HealthCare.Application.DataTransferObjects.UnitType;

public class CreateUnitTypeDto
{
   [Required]
    public string Name { get; set; } = string.Empty;
}