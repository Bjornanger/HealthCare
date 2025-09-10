using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Application.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddScoped<IProductService, IProductService >();

        return services;
    }
}