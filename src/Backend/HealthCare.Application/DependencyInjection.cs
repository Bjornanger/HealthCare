using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Application.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        
        services.AddScoped<IProductService, IProductService >();

        return services;
    }
}