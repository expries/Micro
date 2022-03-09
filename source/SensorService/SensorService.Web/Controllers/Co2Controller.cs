using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SensorService.Contracts.V1;
using SensorService.Contracts.V1.Requests;
using SensorService.Contracts.V1.Responses;
using SensorService.Entities;
using SensorService.Services.Interfaces;

namespace SensorService.Web.Controllers;

public class Co2Controller : ControllerBase
{
    private readonly IRoomSensorService _roomSensorService;
    
    private readonly IMapper _mapper;
    
    public Co2Controller(IRoomSensorService roomSensorService, IMapper mapper)
    {
        _roomSensorService = roomSensorService;
        _mapper = mapper;
    }
    
    [HttpGet(ApiRoute.Co2.GetAll)]
    public async Task<IActionResult> GetAllAsync()
    {
        var measurements = await _roomSensorService.GetCo2MeasurementsAsync();
        var dtos = _mapper.Map<List<Co2Dto>>(measurements);
        return Ok(dtos);
    }
    
    [HttpPost(ApiRoute.Co2.Post)]
    public async Task<IActionResult> CreateAsync([FromBody] AddCo2Dto co2Dto)
    {
        var entity = _mapper.Map<Co2>(co2Dto);
        await _roomSensorService.AddCo2Measurement(entity);
        return NoContent();
    }
}