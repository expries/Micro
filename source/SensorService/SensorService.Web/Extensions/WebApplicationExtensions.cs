namespace SensorService.Web.Extensions;

public static class WebApplicationExtensions
{
    private const string SwaggerDocument = "v1";

    private const string SwaggerPath = $"/swagger/{SwaggerDocument}/swagger.json";
    
    public static void AddSwaggerAndRedoc(this WebApplication app)
    {
        app.UseOpenApi(_ =>
        {
            _.DocumentName = SwaggerDocument;
            _.Path = SwaggerPath;
        });

        app.UseSwaggerUI(_ =>
        {
            _.SwaggerEndpoint(SwaggerPath, "Room Sensor API v1");
        });
    
        app.UseReDoc(_ =>
        {
            _.DocumentPath = SwaggerPath;
            _.Path = "/redoc";
        });
    }
}