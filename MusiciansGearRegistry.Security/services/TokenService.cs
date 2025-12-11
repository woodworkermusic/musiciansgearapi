using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MusiciansGearRegistry.Api.Security.interfaces;
using System.Security.Claims;

namespace MusiciansGearRegistry.Api.Security.services;

public class TokenService : ITokenService
{
    private readonly string _symmetricKey;

    public TokenService(string symmetricKey)
    {
        _symmetricKey = symmetricKey;
    }

    public string GenerateLoginToken(string username, string role)
    {
        var now = DateTime.UtcNow;

        // generate token
        var tokenHandler = new JsonWebTokenHandler();
        SecurityTokenDescriptor tokenDescriptor = new();
        tokenDescriptor.Subject = new ClaimsIdentity(new Claim[] {
                                                         new Claim(ClaimTypes.Name, username),
                                                         new Claim(ClaimTypes.Role, role),
                                                         new Claim("MusiciansGearRegistry.Api", "MusiciansGearRegistry.Api")
                                                        });

        tokenDescriptor.Issuer = "self";
        tokenDescriptor.Audience = "http://www.example.com";
        tokenDescriptor.Expires = DateTime.Now.AddMonths(1);

        var keyData = Convert.FromBase64String(_symmetricKey);
        tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyData),
                                                                        "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                                                                        "http://www.w3.org/2001/04/xmlenc#sha256");
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return token.ToString();
    }
}
