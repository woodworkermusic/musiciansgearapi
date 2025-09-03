using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentTypeController : ApiControllerBase
{
    private readonly IEquipmentTypeService _equipmentTypeService;

    public EquipmentTypeController(IEquipmentTypeService equipmentTypeService
        , ILoggingService logSvc) : base(logSvc, "EquipmentType")
    {
        _equipmentTypeService = equipmentTypeService;
    }

    [Route("/{typeId}")]
    [HttpGet]
    public async Task<IActionResult> Get(int typeId)
    {
        var dto = await _equipmentTypeService.Get(typeId);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [Route("/Search")]
    [HttpPost]
    public async Task<IActionResult> GetMany([FromBody] CommonSearchEntity manufacturerSearch)
    {
        var dto = await _equipmentTypeService.GetMany(manufacturerSearch);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] EquipmentType newType)
    {
        //var dto = await _equipmentTypeService.Add(newType, userId);
        var dto = await _equipmentTypeService.Add(newType, 1);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] EquipmentType typeUpdate)
    {
        // Will have to check against the logged in user to make sure they can update this piece of equipment
        // or that they are an admin.
        //var dto = await _equipmentTypeService.Update(typeUpdate, userId);
        var dto = await _equipmentTypeService.Update(typeUpdate, 1);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [Route("/{modelId}/{userId}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int typeId
        , int userId)
    {
        // Will have to check against the logged in user to make sure they are either the current gear owner 
        // or an admin level user to do this.
        var dto = await _equipmentTypeService.Delete(typeId, userId);
        return Ok(dto);
    }
}
