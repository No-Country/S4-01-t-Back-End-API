using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using S4_Back_End_API.Data;
using S4_Back_End_API.Mappings;
using System;
using System.Security.Cryptography.X509Certificates;

namespace S4_Back_End_API.StartUp;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        // Add CORS
        services.AddCors(c =>
        {
            c.AddPolicy("AllowOrigin",
                options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        // ADD Transients, Scope, Singletons, etc. HERE
        //services.AddTransient<>();

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

    public static IServiceCollection AddAMapper(this IServiceCollection services)
    {
        //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(typeof(AutoMapperProfile));
        return services;
    }

    public static IMvcBuilder AddNewtonJson(this IMvcBuilder newton)
    {
        newton.AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            options.UseCamelCasing(false);
        });
        return newton;
    }
}
