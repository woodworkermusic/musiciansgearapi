using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Security.interfaces;
using MusiciansGearRegistry.Data.models;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ApiControllerBase
{
    private readonly IUserProfileService _userProfileSvc;

    public UserProfileController(ILoggingService logSvc
        , IUserProfileService userProfileSvc) : base(logSvc, "UserProfile")
    {
        _userProfileSvc = userProfileSvc;
    }

    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserRequest createUserRequest)
    {
        var dto = _userProfileSvc.Add(createUserRequest);
        return (dto != null) ? Ok(dto) : BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int userProfileId, int userId)
    {
        var deleteResult = await _userProfileSvc.Delete(userProfileId, userId);
        return Ok(deleteResult);
    }
}
