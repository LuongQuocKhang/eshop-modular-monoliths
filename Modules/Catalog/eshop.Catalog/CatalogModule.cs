using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Catalog;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to container
        // services.AddApplicationServices(configuration)
        //     .AddInfrastructureServices(configuration)
        //     .AddApiServices(configuration);
        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        // Configure HTTP request pipeline
        // app.UseApplicationServices()
        //     .UseInfrastructureServices()
        //     .UseApiServices();
        return app;
    }
}