using Microsoft.EntityFrameworkCore;
using S4_Back_End_API.Data;
using S4_Back_End_API.StartUp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();
builder.Services.AddControllers();
builder.Services.DBContext(builder);

var app = builder.Build();

app.ConfigureSwagger();

app
    .MapUserEndPoints()
    .MapDogEndPoints();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();