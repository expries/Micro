namespace SensorService.Contracts.V1.Requests;

public class AddTemperatureDto
{
    public double Value { get; set; }
    
    public DateTime Time { get; set; }
}