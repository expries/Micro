using InfluxDB.Client.Core;

namespace SensorService.Entities;

[Measurement("co2")]
public class Co2
{
    [Column("value")]
    public double Value { get; set; }
    
    [Column(IsTimestamp = true)]
    public DateTime Time { get; set; }
}