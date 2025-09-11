using HealthCare.Application.Interfaces.ServiceInterfaces;
using HealthCare.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddScoped<IProductService, ProductService >();
        services.AddScoped<IUnitTypeService, UnitTypeService>();


        return services;
    }
}