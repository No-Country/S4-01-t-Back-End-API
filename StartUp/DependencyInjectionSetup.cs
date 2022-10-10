using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using S4_Back_End_API.Data;
using System;
using System.Security.Cryptography.X509Certificates;

namespace S4_Back_End_API.StartUp;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        // Enable CORS
        services.AddCors(c =>
        {
            c.AddPolicy("AllowOrigin",
                options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        return services;
    }
    public static IServiceCollection DBContext(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<ApplicationDbContext>(
            option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
        return services;
    }

    public static IApplicationBuilder EnableCors(this IApplicationBuilder app)
    {
        app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        return app;
    }

    //public static IServiceCollection NewtonJson(this IServiceCollection services)
    //{
    //    var newton = "blah";

    //    return newton;
    //}
}
