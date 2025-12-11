namespace MusiciansGearRegistry.Api.Security.interfaces;

public interface ITokenService
{
    string GenerateLoginToken(string username, string role);
}
