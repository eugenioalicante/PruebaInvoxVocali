using Microsoft.Extensions.DependencyInjection;
using PruebaInvoxMedicalService.Service.Interface;
using PruebaInvoxMedicalService.Service.Service;
using Swashbuckle.AspNetCore.Swagger;



namespace PruebaInvoxMedicalService.Service.Startup
{
    public static class ConfigureServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                c.DescribeAllEnumsAsStrings();
            });
        }

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            // Register service                     
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<IMP3Service, MP3Service>();
            
        }
    }
}
