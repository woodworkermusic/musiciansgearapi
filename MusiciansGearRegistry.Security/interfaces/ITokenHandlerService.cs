namespace MusiciansGearRegistry.Api.Security.interfaces;

public interface ITokenHandlerService
{
    string GenerateLoginToken(string username, string role, DateTime expiresOn, string app);
}
