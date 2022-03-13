using AutoMapper;
using SensorService.Contracts.V1.Requests;
using SensorService.Contracts.V1.Responses;
using SensorService.Entities;

namespace SensorService.Web.MappingProfiles;

public class Co2Profile : Profile 
{
    public Co2Profile()
    {
        CreateMap<AddCo2Dto, Co2>();
        CreateMap<Co2, Co2Dto>();
    }
}