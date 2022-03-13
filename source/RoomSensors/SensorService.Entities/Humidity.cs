using InfluxDB.Client.Core;

namespace SensorService.Entities;

[Measurement("humidity")]
public class Humidity
{
    [Column("value")]
    public double Value { get; set; }
    
    [Column(IsTimestamp = true)]
    public DateTime Time { get; set; }
}