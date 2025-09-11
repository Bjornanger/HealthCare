using HealthCare.Api.EndpointExtensions;
using HealthCare.Application;
using HealthCare.Infrastructure;

namespace HealthCare.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();
            

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "HealthCare API", Version = "v1" });
            });



            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.MapProductEndpointExtensions();
            app.MapUnitTypeEndpointExtensions();

            app.Run();
        }
    }
}
