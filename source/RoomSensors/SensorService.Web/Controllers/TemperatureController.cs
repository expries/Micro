using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SensorService.Contracts.V1;
using SensorService.Contracts.V1.Requests;
using SensorService.Contracts.V1.Responses;
using SensorService.Entities;
using SensorService.Services.Interfaces;

namespace SensorService.Web.Controllers;

public class TemperatureController : ControllerBase
{
    private readonly IRoomSensorService _roomSensorService;
    
    private readonly IMapper _mapper;
    
    public TemperatureController(IRoomSensorService roomSensorService, IMapper mapper)
    {
        _roomSensorService = roomSensorService;
        _mapper = mapper;
    }
    
    [HttpGet(ApiRoute.Temperature.GetAll)]
    public async Task<IActionResult> GetAllAsync()
    {
        var measurements = await _roomSensorService.GetTemperatureMeasurementsAsync();
        var dtos = _mapper.Map<List<TemperatureDto>>(measurements);
        return Ok(dtos);
    }
    
    [HttpPost(ApiRoute.Temperature.Post)]
    public async Task<IActionResult> CreateAsync([FromBody] AddTemperatureDto temperatureDto)
    {
        var entity = _mapper.Map<Temperature>(temperatureDto);
        await _roomSensorService.AddTemperatureMeasurement(entity);
        return NoContent();
    }
}