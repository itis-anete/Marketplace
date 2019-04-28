using System.IO;
using Marketplace.DbAccess;
using Marketplace.ProductDomain;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Marketplace.Web.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPgUnitOfWork(this IServiceCollection serviceCollection)
            => serviceCollection.AddScoped<IUnitOfWork, PgUnitOfWork>();

        public static IServiceCollection AddSameProductsFinder(this IServiceCollection serviceCollection)
            => serviceCollection.AddScoped<ISameProductsFinder, SameProductsFinder>();

        public static IServiceCollection AddMarketplaceSwaggerGen(this IServiceCollection serviceCollection)
        {
            void SwaggerGenOptionsAction(SwaggerGenOptions swaggerGenOptions)
            {
                var info = new Info
                {
                    Version = "1.0.0",
                    Title = "Marketplace API",
                    Description = "Created by VT$4PP"
                };
                
                swaggerGenOptions.SwaggerDoc("1.0.0", info);

//                var basePath = ApplicationEnvironment.ApplicationBasePath;
//                var filePath = Path.Combine(basePath, "Marketplace.Web.xml");
//                swaggerGenOptions.IncludeXmlComments(filePath);
            }

            return serviceCollection.AddSwaggerGen(SwaggerGenOptionsAction);
        }
    }
}























