using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.dto;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageContentController : ApiControllerBase
{
    private readonly IGearImageService _gearImageService;

    public ImageContentController(IGearImageService gearImageService,
        ILoggingService logSvc) : base(logSvc, "ImageContent")
    {
        _gearImageService = gearImageService;
    }

    [HttpPost("gearmodel")]
    public async Task<IActionResult> AddGearModelImage([FromBody] dto_GearModelImage gearModelImage)
    {
        var dto = await _gearImageService.Add_GearModelImage(gearModelImage);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
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
