using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Security.interfaces;
using MusiciansGearRegistry.Api.Security.models;
namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccessController : ApiControllerBase
{
    private readonly ILoginService _loginSvc;

    public AccessController(ILoggingService logSvc
        , ILoginService loginSvc) : base(logSvc, "Access")
    {
        _loginSvc = loginSvc;
    }

    [Route("SignIn")]
    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] LoginRequest loginRequest)
    {
        var loginResult = _loginSvc.Login(loginRequest);
        return (loginResult != null) ? Ok() : BadRequest("nope");
    }
}
