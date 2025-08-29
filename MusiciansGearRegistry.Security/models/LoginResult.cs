using MusiciansGearRegistry.Api.Security.enums;
using MusiciansGearRegistry.Api.Security.interfaces;

namespace MusiciansGearRegistry.Api.Security.models;

public class LoginResult : ILoginResult
{
    public bool success {get; set;}
    public string message {get; set;}

    // basic user info
    public string userName { get; set; }
    public string fullName { get; set; }
    public string displayName { get; set; }
    public bool isAnonymous { get; set; }
    public string email { get; set; }
    public Roles role { get; set; }
     
    // security
    public string accessToken {get; set;}
    public string tokenType {get; set;}
    public Nullable<DateTime> expiresOn { get; set; }
    public bool pwdExpired { get; set; }

    public LoginResult()
    {
        success = false;
        isAnonymous = false;
        message = "invalid username / emailaddress or password.";
    }
}

