using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace PruebaInvoxMedicalService.Service.Startup
{
    public static class ConfigureExtensions
    {
        public static void UseSwagger(this IApplicationBuilder app, IConfiguration Configuration)
        {
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
