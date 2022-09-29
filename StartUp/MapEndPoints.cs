using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace S4_Back_End_API.StartUp;

public static class MapEndPoints
{
    public static WebApplication MapUserEndPoints(this WebApplication app)
    {
        //app.MapGet("/User/{name}", (string name) => $"Hello, {name}!");     //Quedo a modo de ejemplo de lo que podriamos llamar o usar
        return app;
    }

    public static WebApplication MapDogEndPoints(this WebApplication app)
    {
        //app.MapGet("/Dog/{name}", (string name) => $"Good Bye, {name}!");     //Quedo a modo de ejemplo de lo que podriamos llamar o usar
        return app;
    }
    
}
