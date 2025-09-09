using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusiciansGearRegistry.Api.Security.models;

public class LoginRequest
{
    [Required]
    [Description("valid values:  user, token, externalToken, email")]
    public string LoginType { get; set; }

    public string? UserName { get; set; }
    public string Password { get; set; }
    public string? Token { get; set; }

    /// <summary>
    /// for 3rd party logins.  facebook etc.
    /// </summary>
    public string? ExternalToken { get; set; }
    public string? Email { get; set; }
}
