namespace SensorService.Contracts.V1.Requests;

public class AddCo2Dto
{
    public double Value { get; set; }
    
    public DateTime Time { get; set; }
}