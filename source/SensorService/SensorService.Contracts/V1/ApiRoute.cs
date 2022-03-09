using System.Security.Cryptography.X509Certificates;

namespace SensorService.Contracts.V1;

public static class ApiRoute
{
    public const string Root = "api";

    public const string Version = "v1";

    public const string Base = $"{Root}/{Version}";

    public static class Co2
    {
        public const string GetAll = $"{Base}/co2";

        public const string Post = $"{Base}/co2";
    }

    public static class Temperature
    {
        public const string GetAll = $"{Base}/temperature";

        public const string Post = $"{Base}/temperature";
    }
    
    public static class Humidity
    {
        public const string GetAll = $"{Base}/humidity";

        public const string Post = $"{Base}/humidity";
    }
}