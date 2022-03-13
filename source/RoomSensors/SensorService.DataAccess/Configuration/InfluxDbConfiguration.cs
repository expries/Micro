namespace SensorService.DataAccess.Configuration;

public class InfluxDbConfiguration
{
    public string? Url { get; set; }
    
    public string? Org { get; set; }

    public string? Token { get; set; }
    
    public string? Co2Bucket { get; set; }
    
    public string? TemperatureBucket { get; set; }
    
    public string? HumidityBucket { get; set; }
    
}