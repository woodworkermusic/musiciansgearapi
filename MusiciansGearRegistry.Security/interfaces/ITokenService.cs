using MusiciansGearRegistry.Api.Security.models;

namespace MusiciansGearRegistry.Api.Security.interfaces;

public interface ITokenService
{
    string GenerateLoginToken(UserInfo userInfo);
}
