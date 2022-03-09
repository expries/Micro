using AutoMapper;
using SensorService.Contracts.V1.Requests;
using SensorService.Contracts.V1.Responses;
using SensorService.Entities;

namespace SensorService.Web.MappingProfiles;

public class HumidityProfile : Profile
{
    public HumidityProfile()
    {
        CreateMap<AddHumidityDto, Humidity>();
        CreateMap<Humidity, HumidityDto>();
    }
}