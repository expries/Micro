using InfluxDB.Client.Core;

namespace SensorService.Entities;

[Measurement("temperature")]
public class Temperature
{
    [Column("value")]
    public double Value { get; set; }
    
    [Column(IsTimestamp = true)]
    public DateTime Time { get; set; }
}