using SensorService.DataAccess;
using SensorService.DataAccess.Configuration;
using SensorService.DataAccess.Interfaces;
using SensorService.Services;
using SensorService.Services.Interfaces;
using SensorService.Web.Extensions;
using SensorService.Web.MappingProfiles;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");
    
    var builder = WebApplication.CreateBuilder(args);
    var webHost = builder.WebHost;
    var services = builder.Services;
    var configuration = builder.Configuration;
    
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

    webHost.UseSerilog();

    services.AddOpenApiDocument();

    var influxDbConfig = new InfluxDbConfiguration();
    configuration.Bind("InfluxDb", influxDbConfig);

    services.AddSingleton(influxDbConfig);

    services.AddTransient<IRoomSensorService, RoomSensorSensorService>();
    services.AddTransient<ICo2Repository, MeasurementRepository>();
    services.AddTransient<ITemperatureRepository, MeasurementRepository>();
    services.AddTransient<IHumidityRepository, MeasurementRepository>();

    services.AddAuthorization();    
    services.AddControllers();

    services.AddAutoMapper(typeof(Co2Profile));

    var app = builder.Build();

    if (builder.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseSerilogRequestLogging();

    app.AddSwaggerAndRedoc();

    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    
    app.Run();
    
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}

