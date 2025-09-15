using HealthCare.Application.DataTransferObjects.UnitType;
using HealthCare.Application.Interfaces.ServiceInterfaces;

namespace HealthCare.Api.EndpointExtensions;

public static class UnitTypeEndpoint
{
    public static IEndpointRouteBuilder MapUnitTypeEndpointExtensions(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/unitTypes");

        group.MapGet("/", GetAllUnitTypes);
        group.MapGet("/{id:guid}", GetUnitTypeById);
        group.MapPost("/", AddUnitType);
        group.MapPut("/{id:guid}", UpdateUnitType);
        group.MapDelete("/{id:guid}", DeleteUnitType);
       
        return app;
    }

    private static async Task<IResult> GetAllUnitTypes(IUnitTypeService unitTypeService)
    {
        var unitTypeList = await unitTypeService.GetAllAsync();

        if (unitTypeList is null || !unitTypeList.Any())
        {
            unitTypeList = new List<UnitTypeDto>();
        }

        return Results.Ok(unitTypeList);
    }
    private static async Task<IResult> GetUnitTypeById(IUnitTypeService unitTypeService, Guid id)
    {
        var unityTypeFound = await unitTypeService.GetByIdAsync(id);

        if (unityTypeFound == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(unityTypeFound);
    }
    private static async Task<IResult> AddUnitType(IUnitTypeService unitTypeService, CreateUnitTypeDto unitTypeDto)
    {
        var newUnitType = await unitTypeService.AddAsync(unitTypeDto);

        if (newUnitType == null)
        {
            return Results.BadRequest();
        }

        return Results.Ok(newUnitType);
    }
    private static async Task<IResult> UpdateUnitType(IUnitTypeService unitTypeService, UnitTypeDto unitTypeDto, Guid id)
    {
        var successObject = await unitTypeService.UpdateAsync(unitTypeDto, id);

        if (!successObject)
        {
            return Results.BadRequest();
        }

        return Results.Ok();
    }
    private static async Task<IResult> DeleteUnitType(IUnitTypeService unitTypeService, Guid id)
    {
        var successObject = await unitTypeService.DeleteAsync(id);

        if (!successObject)
        {
            return Results.BadRequest();
        }

        return Results.Ok();
    }
}