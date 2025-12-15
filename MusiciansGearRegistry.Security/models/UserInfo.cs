namespace MusiciansGearRegistry.Api.Security.models;

public class UserInfo
{
    public string userName { get; set; }
    public string fullName { get; set; }
    public string displayName { get; set; }
    public string email { get; set; }
    public List<string> roles { get; set; }
}
