using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MusiciansGearRegistry.Api.Security.interfaces;
using MusiciansGearRegistry.Api.Security.models;
using System.Security.Claims;
using Newtonsoft.Json;

namespace MusiciansGearRegistry.Api.Security.services;

public class TokenService : ITokenService
{
    private readonly string _symmetricKey;

    public TokenService(string symmetricKey)
    {
        _symmetricKey = symmetricKey;
    }

    public string GenerateLoginToken(UserInfo userInfo)
    {
        var now = DateTime.UtcNow;

        // generate token
        var tokenHandler = new JsonWebTokenHandler();
        SecurityTokenDescriptor tokenDescriptor = new();

        var claims = new List<Claim> {
            new Claim("musiciansgearregistryuser", JsonConvert.SerializeObject(userInfo))
        };

        //claims.Add(new Claim(ClaimTypes.Webpage, "MusiciansGearRegistry.Api"));

        tokenDescriptor.Subject = new ClaimsIdentity(claims);

        tokenDescriptor.Issuer = "self";
        tokenDescriptor.Audience = "";
        tokenDescriptor.Expires = DateTime.Now.AddMonths(1);

        var keyData = Convert.FromBase64String(_symmetricKey);
        tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyData),
                                                                        "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                                                                        "http://www.w3.org/2001/04/xmlenc#sha256");
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return token.ToString();
    }
}
