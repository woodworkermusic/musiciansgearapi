using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManufacturerController : ApiControllerBase
{
    private readonly IManufacturerService _MfrSvc;

    public ManufacturerController(ILoggingService log
        , IManufacturerService MfrSvc)
        : base(log, "Manufacturer")
    {
        _MfrSvc = MfrSvc;
    }

    [HttpGet("{manufacturerId}")]
    public async Task<IActionResult> Get(int manufacturerId)
    {
        var dto = await _MfrSvc.Get(manufacturerId);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPost("Search")]
    public async Task<IActionResult> GetMany([FromBody] CommonSearchEntity manufacturerSearch)
    {
        var dto = await _MfrSvc.GetMany(manufacturerSearch);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] dtoManufacturer newManufacturer)
    {
        var dto = await _MfrSvc.Add(newManufacturer, 1);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] dtoManufacturer manufacturerUpdate)
    {
        // Will have to check against the logged in user to make sure they can update this piece of 
        // or that they are an admin.
        var dto = await _MfrSvc.Update(manufacturerUpdate, 1);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpDelete("{manufacturerId}/{userId}")]
    public async Task<IActionResult> Delete(int manufacturerId
        , int userId)
    {
        // Will have to check against the logged in user to make sure they are either the current gear owner 
        // or an admin level user to do this.
        var dto = await _MfrSvc.Delete(manufacturerId, userId);
        return Ok(dto);
    }
}
