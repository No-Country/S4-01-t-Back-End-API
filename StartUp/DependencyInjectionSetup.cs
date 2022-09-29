using Microsoft.EntityFrameworkCore;
using S4_Back_End_API.Data;
using System;

namespace S4_Back_End_API.StartUp;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
    public static IServiceCollection DBContext(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<ApplicationDbContext>(
            option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}
