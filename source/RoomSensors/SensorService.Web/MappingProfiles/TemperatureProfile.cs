using AutoMapper;
using SensorService.Contracts.V1.Requests;
using SensorService.Contracts.V1.Responses;
using SensorService.Entities;

namespace SensorService.Web.MappingProfiles;

public class TemperatureProfile : Profile
{
    public TemperatureProfile()
    {
        CreateMap<AddTemperatureDto, Temperature>();
        CreateMap<Temperature, TemperatureDto>();
    }
}