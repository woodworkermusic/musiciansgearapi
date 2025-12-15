namespace MusiciansGearRegistry.Api.Security.interfaces;

public interface ITokenService
{
    string GenerateLoginToken(string username, List<string> roles);
}
