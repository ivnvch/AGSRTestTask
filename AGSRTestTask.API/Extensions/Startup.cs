using System.Reflection;
using Microsoft.OpenApi.Models;


namespace AGSRTestTask.Extensions;

public static class Startup
{
   public static void AddSwagger(this IServiceCollection services)
        {

            services.AddApiVersioning().AddApiExplorer(options =>
            {
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "AGSRTestTask.API",
                    Description = "This is version 1.0",
                    TermsOfService = new Uri("https://habr.com/ru/companies/microsoft/articles/325872/"),
                    Contact = new OpenApiContact()
                    {
                        Name = "AGSRTestTask Production",
                        Email = "example@mail.ru"
                    }
                });
                
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });
        }
}