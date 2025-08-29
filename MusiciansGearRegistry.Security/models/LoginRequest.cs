using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusiciansGearRegistry.Api.Security.models;

public class LoginRequest
{
    /// <summary>
    /// valid values:  user, anonymous, token, staff
    /// </summary>
    [Required]
    [Description("valid values:  user, anonymous, token, staff")]
    public string LoginType { get; set; }

    public string UserName { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }

    /// <summary>
    /// for 3rd party logins.  facebook etc.
    /// </summary>
    public string ExternalToken { get; set; }

    public string Email { get; set; }

    public bool IsMobile { get; set; }
}
