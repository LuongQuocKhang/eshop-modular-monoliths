using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Ordering;

public static class OrderingModule
{
    public static IServiceCollection AddOrderingModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to container
        // services.AddApplicationServices(configuration)
        //     .AddInfrastructureServices(configuration)
        //     .AddApiServices(configuration);
        
        return services;
    }
    
    public static IApplicationBuilder UseOrderingModule(this IApplicationBuilder app)
    {
        // Configure HTTP request pipeline
        // app.UseApplicationServices()
        //     .UseInfrastructureServices()
        //     .UseApiServices();
        return app;
    }
}