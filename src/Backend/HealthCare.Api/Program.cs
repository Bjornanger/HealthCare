using HealthCare.Application;
using HealthCare.Infrastructure;

namespace HealthCare.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

            var app = builder.Build();

            app.Run();
        }
    }
}
