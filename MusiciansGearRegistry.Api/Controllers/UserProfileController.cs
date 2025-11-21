using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Security.interfaces;
using MusiciansGearRegistry.Data.models;
using Microsoft.ApplicationInsights;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ApiControllerBase
{
    private readonly IUserProfileService _userProfileSvc;

    public UserProfileController(IUserProfileService userProfileSvc
        , ILogger<GearModelController> logger
        , TelemetryClient telemetryClient
        ) 
        : base(logger, telemetryClient)
    {
        _userProfileSvc = userProfileSvc;
    }

    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserRequest createUserRequest)
    {
        return await ProcessSvcRequest<bool>(_userProfileSvc.Add(createUserRequest));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int userProfileId, int userId)
    {
        var deleteResult = await _userProfileSvc.Delete(userProfileId, userId);
        return Ok(deleteResult);
    }
}
