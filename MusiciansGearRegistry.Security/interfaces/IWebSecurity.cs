using System.Security.Claims;

namespace MusiciansGearRegistry.Api.Security.interfaces;

public interface IWebSecurity
{
    //UserProfile GetUser(string username);
    //UserProfile GetCurrentUser();
    //UserProfile CreateUser(string userName, Roles role);

    void InitializeDatastore(string connectionStringName);
    //LoginResult Login(LoginInfo loginInfo);
    bool UserHasFullAccount(int userId);

    bool ChangePassword(string userName, string oldPassword, string newPassword);
    string GetPasswordResetToken(string userName);
    bool ResetPassword(string resetToken, string newPassword);
    bool CheckUserNameAndPassword(string userName, string password);

    bool ConfirmAccount(string accountConfirmationToken);
    bool CreateAccount(string userName, string password, bool requireConfirmationToken = false, int attachToUserId = -1);
    string CreateUserAndAccount(string userName, string password, object userProfileValues, bool requireConfirmationToken = false);
    int GetUserId(string userName);
    void Logout(int userId);
    bool IsAuthenticated();
    bool AddRole(int userId, string roleName);
    bool AddRole(int userId, int roleId);
    bool RemoveRole(int userId, int roleId);

    bool UpdateUserName(int userId, string newUserName);
    bool UpdateEmail(int userId, string newEmail);
    bool UpdateUserProfile(int userId, string email, string firstName, string lastName, DateTime? birthday, string gender);

    //UserLogin CreateLogin(int userId, int loginProviderId, string providerKey);

    //List<Roles> GetRoles(int userId);
    //bool RoleIsValidForApp(List<Roles> roles, string origin);

    bool UserNameAvailable(string userName);

    string CurrentUserName();
    int CurrentUserId();
    string GetUserName(int userId);
    string GetUsersCurrentApplicationName(int userId);

    ClaimsPrincipal ValidateToken(string token);
    int ClearAllTokensForUser(int userId);
    void SetPrincipalToThreadAndContext(ClaimsPrincipal principal);
}
