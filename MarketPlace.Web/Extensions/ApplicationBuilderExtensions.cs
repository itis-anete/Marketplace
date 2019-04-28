using Microsoft.AspNetCore.Builder;

namespace Marketplace.Web.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerWithEndpoint(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder
                .UseSwagger()
                .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "SwaggerDoc");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}