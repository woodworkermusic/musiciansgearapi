using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GearTypeController : ApiControllerBase
{
    private readonly IGearTypeService _gearTypeService;

    public GearTypeController(IGearTypeService GearTypeService
        , ILoggingService logSvc) : base(logSvc, "GearType")
    {
        _gearTypeService = GearTypeService;
    }

    [HttpGet("{gearTypeId}")]
    public async Task<IActionResult> Get(int gearTypeId = 0)
    {
        if (gearTypeId != 0)
        {
            var dto = await _gearTypeService.Get(gearTypeId);
            return (dto != null) ? Ok(dto) : BadRequest("nope");
        }
        else
        {
            var dto = await _gearTypeService.Get();
            return (dto != null) ? Ok(dto) : BadRequest("nope");
        }
    }

    [HttpGet("manufacturer/{manufacturerId}")]
    public async Task<IActionResult> GetByManufacturer(int manufacturerId)
    {
        var result = await _gearTypeService.GetByManufacturer(manufacturerId);
        return (result != null) ? Ok(result) : BadRequest("nope");
    }

    [HttpPost("Search")]
    public async Task<IActionResult> GetMany([FromBody] CommonSearchEntity manufacturerSearch)
    {
        var dto = await _gearTypeService.GetMany(manufacturerSearch);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] dto_GearType newType)
    {
        var dto = await _gearTypeService.Add(newType, 1);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] GearType typeUpdate)
    {
        // Will have to check against the logged in user to make sure they can update this piece of Gear
        // or that they are an admin.
        //var dto = await _GearTypeService.Update(typeUpdate, userId);
        var dto = await _gearTypeService.Update(typeUpdate, 1);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpDelete("{modelId}/{userId}")]
    public async Task<IActionResult> Delete(int typeId
        , int userId)
    {
        // Will have to check against the logged in user to make sure they are either the current gear owner 
        // or an admin level user to do this.
        var dto = await _gearTypeService.Delete(typeId, userId);
        return Ok(dto);
    }
}
