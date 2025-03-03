using eshop.Catalog.Data.Seed;
using eshop.Shared.Data.Interceptor;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Catalog;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to container

        // Api Endpoints services

        // Application services

        // Data - Infrastructure services
        string connectionString = configuration.GetConnectionString("CatalogConnection")!;

        services.AddDbContext<CatalogDbContext>(options =>
        {
            options.AddInterceptors(new AuditableEntityInterceptor());
            options.UseNpgsql(connectionString);
        });

        // Data - Seed services

        services.AddScoped< IDataSeeder, CatalogDataSeed>();

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        // Configure HTTP request pipeline
        // app.UseApplicationServices()
        //     .UseInfrastructureServices()
        //     .UseApiServices();


        app.UseMigration<CatalogDbContext>();

        return app;
    }

    
}