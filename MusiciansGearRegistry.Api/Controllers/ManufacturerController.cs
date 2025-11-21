using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManufacturerController : ApiControllerBase
{
    private readonly IManufacturerService _MfrSvc;

    public ManufacturerController(IManufacturerService MfrSvc
        , ILogger<ManufacturerController> logger
        , TelemetryClient telemetryClient
        )
        : base(logger, telemetryClient)
    {
        _MfrSvc = MfrSvc;
    }

    [HttpGet("{manufacturerId}")]
    public async Task<IActionResult> Get(int manufacturerId)
    {
        return await ProcessSvcRequest<Manufacturer>(_MfrSvc.Get(manufacturerId));
    }

    [HttpPost("Search")]
    public async Task<IActionResult> GetMany([FromBody] CommonSearchEntity manufacturerSearch)
    {
        return await ProcessSvcRequest<List<KeyValuePair<Guid, Manufacturer>>>(_MfrSvc.GetMany(manufacturerSearch));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] dto_Manufacturer newManufacturer)
    {
        return await ProcessSvcRequest<Manufacturer>(_MfrSvc.Add(newManufacturer, 1));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] dto_Manufacturer manufacturerUpdate)
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
