using SensorService.Entities;

namespace SensorService.DataAccess.Interfaces;

public interface ITemperatureRepository
{
    public Task<List<Temperature>> GetMeasurementsAsync();

    public Task AddMeasurementAsync(Temperature measurement);
}