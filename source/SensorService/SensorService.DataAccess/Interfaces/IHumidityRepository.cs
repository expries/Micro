using SensorService.Entities;

namespace SensorService.DataAccess.Interfaces;

public interface IHumidityRepository
{
    public Task<List<Humidity>> GetMeasurementsAsync();

    public Task AddMeasurementAsync(Humidity measurement);
}