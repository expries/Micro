namespace SensorService.DataAccess.Exceptions;

public class InfluxDbException : Exception
{
    public InfluxDbException()
    {
    }

    public InfluxDbException(string message) : base(message)
    {
    }

    public InfluxDbException(string message, Exception inner) : base(message, inner)
    {
    }
}