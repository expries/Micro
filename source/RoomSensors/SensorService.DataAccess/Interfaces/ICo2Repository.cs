using SensorService.Entities;

namespace SensorService.DataAccess.Interfaces;

public interface ICo2Repository
{
    public Task<List<Co2>> GetMeasurementsAsync();

    public Task AddMeasurementAsync(Co2 measurement);
}