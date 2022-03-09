using SensorService.Entities;

namespace SensorService.Services.Interfaces;

public interface IRoomSensorService
{
    public Task<IEnumerable<Co2>> GetCo2MeasurementsAsync();
    
    public Task<IEnumerable<Temperature>> GetTemperatureMeasurementsAsync();
    
    public Task<IEnumerable<Humidity>> GetHumidityMeasurementsAsync();

    public Task AddCo2Measurement(Co2 measurement);
    
    public Task AddHumidityMeasurement(Humidity measurement);
    
    public Task AddTemperatureMeasurement(Temperature measurement);
}