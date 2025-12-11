using MusiciansGearRegistry.Api.Security.models;

namespace MusiciansGearRegistry.Api.Security.interfaces;

public interface IAccessService
{
    LoginResult Login(LoginRequest loginInfo);
}
