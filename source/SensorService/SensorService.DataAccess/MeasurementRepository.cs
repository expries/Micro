using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Flux.Domain;
using SensorService.DataAccess.Configuration;
using SensorService.DataAccess.Interfaces;
using SensorService.Entities;

namespace SensorService.DataAccess;

public class MeasurementRepository : ICo2Repository, IHumidityRepository, ITemperatureRepository
{
    private readonly InfluxDbConfiguration _configuration;
    
    public MeasurementRepository(InfluxDbConfiguration configuration)
    {
        _configuration = configuration;
    }

    async Task<List<Co2>> ICo2Repository.GetMeasurementsAsync()
    {
        var tables = await QueryBucketAsync(_configuration.Co2Bucket);

        var values = tables
            .SelectMany(GetValues)
            .Select(_ => new Co2 { Time = _.Key, Value = _.Value });
        
        return values.ToList();
    }

    async Task ICo2Repository.AddMeasurementAsync(Co2 measurement)
    {
        await WriteMeasurement(_configuration.Co2Bucket, measurement);
    }

    async Task<List<Humidity>> IHumidityRepository.GetMeasurementsAsync()
    {
        
        var tables = await QueryBucketAsync(_configuration.HumidityBucket);

        var values = tables
            .SelectMany(GetValues)
            .Select(_ => new Humidity { Time = _.Key, Value = _.Value });

        return values.ToList();
    }

    async Task IHumidityRepository.AddMeasurementAsync(Humidity measurement)
    {
        await WriteMeasurement(_configuration.HumidityBucket, measurement);
    }

    async Task<List<Temperature>> ITemperatureRepository.GetMeasurementsAsync()
    {
        var tables = await QueryBucketAsync(_configuration.TemperatureBucket);

        var values = tables
            .SelectMany(GetValues)
            .Select(_ => new Temperature { Time = _.Key, Value = _.Value });

        return values.ToList();
    }

    async Task ITemperatureRepository.AddMeasurementAsync(Temperature measurement)
    {
        await WriteMeasurement(_configuration.TemperatureBucket, measurement);
    }

    private async Task WriteMeasurement<T>(string? bucket, T measurement)
    {
        var client = CreateInfluxDbClient();
        var writer = client.GetWriteApiAsync();
        await writer.WriteMeasurementAsync(bucket, _configuration.Org, WritePrecision.Ns, measurement);
    }

    private async Task<List<FluxTable>> QueryBucketAsync(string? bucketName)
    {
        var query = $"from(bucket: \"{bucketName}\") |> range(start: -1h)";
        var client = CreateInfluxDbClient();
        var reader = client.GetQueryApi();
        return await reader.QueryAsync(query, _configuration.Org);
    }

    private InfluxDBClient CreateInfluxDbClient() =>
        InfluxDBClientFactory.Create(_configuration.Url, _configuration.Token);
    
    private static IEnumerable<KeyValuePair<DateTime, double>> GetValues(FluxTable table)
    {
        foreach (var record in table.Records)
        {
            var influxTime = record.GetTime();
            if (influxTime is null) continue;
            var time = influxTime.Value.ToDateTimeUtc();
            var value = (double) record.GetValueByKey("_value");
            yield return new KeyValuePair<DateTime, double>(time, value);
        }
    }
}