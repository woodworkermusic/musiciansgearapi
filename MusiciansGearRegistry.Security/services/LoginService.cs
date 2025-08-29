using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Security.enums;
using MusiciansGearRegistry.Api.Security.interfaces;
using MusiciansGearRegistry.Api.Security.models;
using MusiciansGearRegistry.Api.Security.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MusiciansGearRegistry.Api.Security.services;

public class LoginService : ILoginService
{
    // token manager
    private readonly ITokenHandlerService tokenHandler;
    private readonly ILoggingService log;
    private readonly SecurityContext _securityContext;

    public LoginService(SecurityContext securityContext
        , ITokenHandlerService tokenHandler
        , ILoggingService loggingService) 
    {
        _securityContext = securityContext;
        tokenHandler = tokenHandler;
        log = loggingService.GetLoggingService("SimpleMemberhipJwtSecurity");
    }

    #region login and logout

    public LoginResult Login(LoginRequest loginInfo)
    {
        if (loginInfo.LoginType.ToLower() == "email")
        {
            return Login_Email(loginInfo);
        }

        else if (loginInfo.LoginType.ToLower() == "username")
        {
            return Login_UserName(loginInfo);
        }

        //else if (loginInfo.LoginType.ToLower() == "facebook")
        //{
        //    return LoginWithFacebook(loginInfo);
        //}

        //else if (loginInfo.LoginType.ToLower() == "token")
        //{
        //    return LoginWithToken(loginInfo);
        //}

        else
            return new LoginResult()
            {
                success = false,
                message = "invalid login type"
            };
    }

    //public LoginResult LoginWithToken(LoginRequest loginInfo)
    //{
    //    LoginResult result = new LoginResult();

    //    ClaimsPrincipal principal;
    //    try
    //    {
    //        principal = ValidateToken(loginInfo.Token);
    //        SetPrincipalToThreadAndContext(principal);
    //    }
    //    catch (Exception)
    //    {
    //        principal = HandleExpiredToken(loginInfo.Token, loginInfo.Origin);
    //        SetPrincipalToThreadAndContext(principal);

    //        // get the new token if there is one
    //        loginInfo.Token = GetTokenForUser(CurrentUserId());
    //    }


    //    if (principal != null)
    //    {
    //        int userId = CurrentUserId();

    //        // check that the user pricipal is correctly set, and make sure that user's token has not expired
    //        if (userId == -1 || !MatchTokenWithUserToken(loginInfo.Token))
    //        {
    //            // something is messed up with this token. kill it
    //            using (SecurityContext db = new SecurityContext(connectionString))
    //            {
    //                // check for an existing token
    //                UserToken userToken = db.UserTokens.Where(x => x.AccessToken == loginInfo.Token).FirstOrDefault();

    //                // delete it 
    //                if (userToken != null)
    //                {
    //                    db.UserTokens.Remove(userToken);
    //                    db.SaveChanges();
    //                }
    //            }

    //            result.success = false;
    //            result.message = "Token expired.";
    //        }
    //    }
    //    else
    //    {
    //        result.success = false;
    //        result.message = "Token expired.";
    //    }

    //    return result;
    //}

    public LoginResult Login_UserName(LoginRequest loginInfo)
    {
        var loginResult = new LoginResult();

        if (loginInfo.UserName == "" || loginInfo.Password == "")
        {
            return loginResult;
        }

        var userProfile = _securityContext
            .UserProfile
            .Single(s => s.UserName == loginInfo.UserName);

        if (userProfile != null)
        {
            loginResult = ValidateLogin(userProfile, loginInfo.Password);
        }

        return loginResult;
    }

    public LoginResult Login_Email(LoginRequest loginInfo)
    {
        var loginResult = new LoginResult();

        if (loginInfo.Email == "" || loginInfo.Password == "")
        {
            return loginResult;
        }

        var userProfile = _securityContext
            .UserProfile
            .Single(s => s.EMailAddress == loginInfo.Email);

        if (userProfile != null)
        {
            loginResult = ValidateLogin(userProfile, loginInfo.Password);
        }

        return loginResult;
    }

    private LoginResult ValidateLogin(UserProfile userProfile
        , string loginPwd)
    {
        var hashedPwd = GenerateSaltedHash(loginPwd, userProfile.UserId);
        var pwdText = Convert.ToBase64String(hashedPwd);

        var loginResult = new LoginResult()
        {
            success = false,
            message = "invalid email or password"
        };

        loginResult.success = (pwdText == userProfile.UserPassword);
        loginResult.message = "";

        userProfile.LastLogin = DateTime.UtcNow;

        _securityContext.UserProfile.Update(userProfile);
        _securityContext.SaveChanges();

        return loginResult;
    }

    //public void Logout(int userId)
    //{
    //    // check connection
    //    InitializeDatastore(connectionStringName);

    //    // logout of membership
    //    WebMatrix.WebData.WebSecurity.Logout();

    //    // delete the token
    //    UserToken currentToken = this.GetActiveToken(userId);

    //    if (currentToken != null)
    //    {
    //        using (SecurityContext db = new SecurityContext(connectionString))
    //        {
    //            currentToken.DeletedBy = "system";
    //            currentToken.DeletedOn = DateTime.UtcNow;
    //            db.SaveChanges();
    //        }
    //    }
    //}

    private byte[] GenerateSaltedHash(string plainText
    , Guid userId)
    {
        var plainTextData = Encoding.UTF8.GetBytes(plainText);
        var userIdSalt = Encoding.UTF8.GetBytes(userId.ToString());

        var pwdData = plainTextData.Concat(userIdSalt);

        using var sha256 = SHA512.Create();

        return sha256.ComputeHash(pwdData.ToArray());
    }

    #endregion
}
