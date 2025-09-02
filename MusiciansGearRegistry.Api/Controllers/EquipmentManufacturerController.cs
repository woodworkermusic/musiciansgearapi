using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Security.interfaces;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentManufacturerController : ApiControllerBase
    {
        private readonly IEquipmentManufacturerService _equipmentMfrSvc;

        public EquipmentManufacturerController(ILoggingService log
            , IEquipmentManufacturerService equipmentMfrSvc)
            : base(log, "EquipmentManufacturer")
        {
            _equipmentMfrSvc = equipmentMfrSvc;
        }

        [Route("/{manufacturerId}")]
        [HttpGet]
        public async Task<IActionResult> Get(int manufacturerId)
        {
            var dto = await _equipmentMfrSvc.Get(manufacturerId);
            return (dto != null) ? Ok(dto) : BadRequest("nope");
        }

        [Route("/Search")]
        [HttpPost]
        public async Task<IActionResult> GetMany([FromBody] CommonSearchEntity manufacturerSearch)
        {
            var dto = await _equipmentMfrSvc.GetMany(manufacturerSearch);
            return (dto != null) ? Ok(dto) : BadRequest("nope");
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EquipmentManufacturer newManufacturer)
        {
            var dto = await _equipmentMfrSvc.Add(newManufacturer, 1);
            return (dto != null) ? Ok(dto) : BadRequest("nope");
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EquipmentManufacturer manufacturerUpdate)
        {
            // Will have to check against the logged in user to make sure they can update this piece of equipment
            // or that they are an admin.
            var dto = await _equipmentMfrSvc.Update(manufacturerUpdate, 1);
            return (dto != null) ? Ok(dto) : BadRequest("nope");
        }

        [Route("/{manufacturerId}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int manufacturerId)
        {
            // Will have to check against the logged in user to make sure they are either the current gear owner 
            // or an admin level user to do this.
            var dto = await _equipmentMfrSvc.Delete(manufacturerId, 1);
            return Ok(dto);
        }
    }
}
