using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MusiciansGearRegistry.Api.Security.interfaces;
using System.Security.Claims;

namespace MusiciansGearRegistry.Api.Security.services;

public class TokenHandlerService : ITokenHandlerService
{
    public string GenerateLoginToken(string username, string role, DateTime expiresOn, string app)
    {
        //var symmetricKey = Convert.FromBase64String(ConfigurationManager["symmetricKey"]);
        var symmetricKey = Convert.FromBase64String(Guid.NewGuid().ToString());
        var now = DateTime.UtcNow;

        // generate token
        var tokenHandler = new JsonWebTokenHandler();
        SecurityTokenDescriptor tokenDescriptor = new();
        tokenDescriptor.Subject = new ClaimsIdentity(new Claim[] {
                                                         new Claim(ClaimTypes.Name, username),
                                                         new Claim(ClaimTypes.Role, role),
                                                         new Claim("App", app)
                                                        });

        tokenDescriptor.Issuer = "self";
        tokenDescriptor.Audience = "http://www.example.com";
        tokenDescriptor.Expires = DateTime.Now.AddYears(1);

        tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey),
                                                                        "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                                                                        "http://www.w3.org/2001/04/xmlenc#sha256");
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return token.ToString();
    }
}
