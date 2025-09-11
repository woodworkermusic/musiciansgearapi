using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GearModelController : ApiControllerBase
{
    private readonly IGearModelService _gearModelSvc; 

    public GearModelController(IGearModelService equipmentModelSvc,
        ILoggingService logSvc) : base(logSvc, "EquipmentModel") 
    {
        _gearModelSvc = equipmentModelSvc;
    }

    [Route("/{modelId}")]
    [HttpGet]
    public async Task<IActionResult> Get(int modelId)
    {
        var dto = await _gearModelSvc.Get(modelId);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [Route("/Search")]
    [HttpPost]
    public async Task<IActionResult> GetMany([FromBody] CommonSearchEntity manufacturerSearch)
    {
        var dto = await _gearModelSvc.GetMany(manufacturerSearch);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] GearModel newModel)
    {
        //var dto = await _GearModelSvc.Add(newModel, userId);
        var dto = await _gearModelSvc.Add(newModel, 1);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] GearModel modelUpdate)
    {
        // Will have to check against the logged in user to make sure they can update this piece of Gear
        // or that they are an admin.
        //var dto = await _GearModelSvc.Update(modelUpdate, userId);
        var dto = await _gearModelSvc.Update(modelUpdate, 1);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [Route("/{modelId}/{userId}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int modelId
        , int userId)
    {
        // Will have to check against the logged in user to make sure they are either the current gear owner 
        // or an admin level user to do this.
        var dto = await _gearModelSvc.Delete(modelId, userId);
        return Ok(dto);
    }
}
