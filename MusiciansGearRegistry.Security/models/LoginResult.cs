using MusiciansGearRegistry.Api.Security.interfaces;

namespace MusiciansGearRegistry.Api.Security.models;

public class LoginResult : ILoginResult
{
    public bool success {get; set;}
    public string message {get; set;}

    // security
    public string accessToken {get; set;}
    public string tokenType {get; set;}
    public Nullable<DateTime> expiresOn { get; set; }
    public bool pwdExpired { get; set; }

    public LoginResult()
    {
        success = false;
        message = "invalid username / emailaddress or password.";
    }
}

