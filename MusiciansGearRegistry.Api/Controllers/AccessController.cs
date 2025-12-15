using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Security.interfaces;
using MusiciansGearRegistry.Api.Security.models;
namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccessController : ApiControllerBase
{
    private readonly IAccessService _accessService;
    private readonly ITokenService _tokenService;

    public AccessController(IAccessService accessService
        , ITokenService tokenService
        , ILogger<AccessController> logger
        , TelemetryClient telemetryClient
        ) 
        : base(logger, telemetryClient)
    {
        _accessService = accessService;
        _tokenService = tokenService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> SignIn([FromBody] LoginRequest loginRequest)
    {
        var loginResult = _accessService.Login(loginRequest);
        return (loginResult.success) ? Ok(loginResult) : BadRequest("nope");
    }

    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        return Ok();
    }
}
