using SensorService.DataAccess.Interfaces;
using SensorService.Entities;
using SensorService.Services.Interfaces;

namespace SensorService.Services;

public class RoomSensorSensorService : IRoomSensorService
{
    private readonly ICo2Repository _co2Repository;
    
    private readonly ITemperatureRepository _temperatureRepository;
    
    private readonly IHumidityRepository _humidityRepository;
    
    public RoomSensorSensorService(
        ICo2Repository co2Repository, 
        ITemperatureRepository temperatureRepository, 
        IHumidityRepository humidityRepository)
    {
        _co2Repository = co2Repository;
        _temperatureRepository = temperatureRepository;
        _humidityRepository = humidityRepository;
    }

    public async Task<IEnumerable<Co2>> GetCo2MeasurementsAsync()
    {
        return await _co2Repository.GetMeasurementsAsync();
    }

    public async Task<IEnumerable<Temperature>> GetTemperatureMeasurementsAsync()
    {
        return await _temperatureRepository.GetMeasurementsAsync();
    }

    public async Task<IEnumerable<Humidity>> GetHumidityMeasurementsAsync()
    {
        return await _humidityRepository.GetMeasurementsAsync();
    }

    public async Task AddCo2Measurement(Co2 measurement)
    {
        await _co2Repository.AddMeasurementAsync(measurement);
    }

    public async Task AddHumidityMeasurement(Humidity measurement)
    {
        await _humidityRepository.AddMeasurementAsync(measurement);
    }

    public async Task AddTemperatureMeasurement(Temperature measurement)
    {
        await _temperatureRepository.AddMeasurementAsync(measurement);
    }
}