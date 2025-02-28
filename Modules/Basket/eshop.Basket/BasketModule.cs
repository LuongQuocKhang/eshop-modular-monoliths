using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Basket;

public static class BasketModule
{
    public static IServiceCollection AddBasketModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to container
        // services.AddApplicationServices(configuration)
        //     .AddInfrastructureServices(configuration)
        //     .AddApiServices(configuration);
        
        return services;
    }
    
    public static IApplicationBuilder UseBasketModule(this IApplicationBuilder app)
    {
        // Configure HTTP request pipeline
        // app.UseApplicationServices()
        //     .UseInfrastructureServices()
        //     .UseApiServices();
        return app;
    }
}