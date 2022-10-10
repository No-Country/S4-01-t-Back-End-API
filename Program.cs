using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using S4_Back_End_API.Data;
using S4_Back_End_API.StartUp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options => {
                        options.SerializerSettings.
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        });
builder.Services.DBContext(builder);

var app = builder.Build();

app.ConfigureSwagger();


app
    .MapUserEndPoints();
    //.MapDogEndPoints();

app.UseHttpsRedirection();

app.UseRouting();

app.EnableCors();

app.UseAuthorization();

app.MapControllers();

app.Run();