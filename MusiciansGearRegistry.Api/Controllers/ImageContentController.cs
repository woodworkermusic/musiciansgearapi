using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.dto;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageContentController : ApiControllerBase
{
    private readonly IGearImageService _gearImageService;

    public ImageContentController(IGearImageService gearImageService
        , ILogger<ImageContentController> logger
        , TelemetryClient telemetryClient
        ) 
        : base(logger, telemetryClient)
    {
        _gearImageService = gearImageService;
    }

    [HttpPost("gearmodel")]
    public async Task<IActionResult> GearModelImage_Add([FromBody] dto_GearModelImage gearModelImage)
    {
        var dto = await _gearImageService.Add_GearModelImage(gearModelImage);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpGet("gearmodel/{imageId}")]
    public async Task<IActionResult> GearModelImage_Get(int imageId)
    {
        var result = await _gearImageService.Get_GearModelImage(imageId);
        return Ok(result);
    }

    [HttpDelete("gearmodel/{imageId}")]
    public async Task<IActionResult> GearModelImage_Delete(int imageId)
    {
        var result = await _gearImageService.Delete_GearModelImage(imageId, 1);
        return Ok(true);
    }

    [HttpPost("geartype")]
    public async Task<IActionResult> AddGearTypeImage([FromBody] dto_GearTypeImage gearTypeImage)
    {
        var dto = await _gearImageService.Add_GearTypeImage(gearTypeImage);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPost("usergear")]
    public async Task<IActionResult> AddUserGearImage([FromBody] dto_UserGearImage userGearImage)
    {
        var dto = await _gearImageService.Add_UserGearImage(userGearImage);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }
}
