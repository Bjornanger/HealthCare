using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Infrastructure.Data;
using HealthCare.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("HealthCareConnection")));

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}