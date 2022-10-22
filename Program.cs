using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using S4_Back_End_API.Data;
using S4_Back_End_API.StartUp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

builder.Services.AddAMapper();

builder.Services
                .AddControllers()
                .AddNewtonJson();

builder.Services.DBContext(builder);

var app = builder.Build();

app.ConfigureSwagger();

app.MapUserEndPoints();

app.UseHttpsRedirection();

app.UseRouting();

app.EnableCors();

app.UseAuthorization();

app.MapControllers();

app.Run();