using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;

namespace Template.Swagger
{
    public static class SwaggerConfig
    {

        public static IServiceCollection AddSwaggerCongiguration(this IServiceCollection services) {

            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Templeate .NET CORE",
                    Version = "v1",
                    Description = "Teste",
                    Contact =  new OpenApiContact { 
                        Name = "Eridani Campos",
                        Email = "eridanicampos@hotmail.com"                       
                    }
                    
                } );

                options.IncludeXmlComments(Path.Combine("wwwroot", "api-doc.xml"));
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(x =>
            {
                x.RoutePrefix = "documentation";
                x.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1");
            });
        }
    }
}
