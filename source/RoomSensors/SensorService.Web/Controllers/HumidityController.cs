using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SensorService.Contracts.V1;
using SensorService.Contracts.V1.Requests;
using SensorService.Contracts.V1.Responses;
using SensorService.Entities;
using SensorService.Services.Interfaces;

namespace SensorService.Web.Controllers;

public class HumidityController : ControllerBase
{
    private readonly IRoomSensorService _roomSensorService;
    
    private readonly IMapper _mapper;
    
    public HumidityController(IRoomSensorService roomSensorService, IMapper mapper)
    {
        _roomSensorService = roomSensorService;
        _mapper = mapper;
    }
    
    [HttpGet(ApiRoute.Humidity.GetAll)]
    public async Task<IActionResult> GetAllAsync()
    {
        var measurements = await _roomSensorService.GetHumidityMeasurementsAsync();
        var dtos = _mapper.Map<List<HumidityDto>>(measurements);
        return Ok(dtos);
    }
    
    [HttpPost(ApiRoute.Humidity.Post)]
    public async Task<IActionResult> CreateAsync([FromBody] AddHumidityDto humidityDtoDto)
    {
        var entity = _mapper.Map<Humidity>(humidityDtoDto);
        await _roomSensorService.AddHumidityMeasurement(entity);
        return NoContent();
    }
}