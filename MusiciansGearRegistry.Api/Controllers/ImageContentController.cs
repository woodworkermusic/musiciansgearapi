using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.infrastructure;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageContentController : ApiControllerBase
{
    private readonly IImageService _imageService;

    public ImageContentController(IImageService imageService
        , ILogger<ImageContentController> logger
        , TelemetryClient telemetryClient
        ) 
        : base(logger, telemetryClient)
    {
        _imageService = imageService;
    }


    [HttpPost("gearmodel")]
    public async Task<IActionResult> GearModelImage_Add([FromBody] INewImage gearModelImage)
    {
        var dto = await _imageService.Add_GearModelImage(gearModelImage);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpGet("gearmodel/{imageId}")]
    public async Task<IActionResult> GearModelImage_Get(int imageId)
    {
        var result = await _imageService.Get_GearModelImage(imageId);
        return Ok(result);
    }

    [HttpGet("gearmodel/{gearModelId}/idlist")]
    public async Task<IActionResult> GearModelImage_IdList(int gearModelId)
    {
        var result = await _imageService.Get_GearModelImageIdList(gearModelId);
        return Ok(result);
    }

    [HttpDelete("gearmodel/{imageId}")]
    public async Task<IActionResult> GearModelImage_Delete(int imageId)
    {
        var result = await _imageService.Delete_GearModelImage(imageId, 1);
        return Ok(true);
    }

    [HttpPost("geartype")]
    public async Task<IActionResult> AddGearTypeImage([FromBody] INewImage gearTypeImage)
    {
        var dto = await _imageService.Add_GearTypeImage(gearTypeImage);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }

    [HttpPost("usergear")]
    public async Task<IActionResult> AddUserGearImage([FromBody] INewImage userGearImage)
    {
        var dto = await _imageService.Add_UserGearImage(userGearImage);
        return (dto != null) ? Ok(dto) : BadRequest("nope");
    }
}
