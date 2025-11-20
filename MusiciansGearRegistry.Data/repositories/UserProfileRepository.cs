using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.models;
using MusiciansGearRegistry.Data.Models;
using System.Security.Cryptography;
using System.Text;
using System.Xml.XPath;

namespace MusiciansGearRegistry.Data.repositories;

public class UserProfileRepository : RepositoryBase, IUserProfileRepository
{
    public UserProfileRepository(MusiciansGearRegistryContext context) : base(context) { }

    public async Task<UserProfile?> Get(int userProfileId)
    {
        return await _dbContext
            .UserProfile
            .SingleAsync(s => s.UserProfileId == userProfileId);
    }

    public async Task<bool> Add(CreateUserRequest createRequest)
    {
        if (_dbContext.UserProfile.Any(a => a.UserName == createRequest.UserName)) return false;

        var newId = Guid.NewGuid();
        var hashedPwd = GenerateSaltedHash(createRequest.NewUserPassword, newId);

        var newUserProfile = new UserProfile()
        {
            FirstName = createRequest.FirstName,
            MiddleInitial = createRequest.MiddleInitial,
            LastName = createRequest.LastName,
            DateOfBirth = createRequest.DateOfBirth,
            UserName = createRequest.UserName,
            EMailAddress = createRequest.EMailAddress,
            PhoneNumber = createRequest.PhoneNumber,
            UserId = newId,
            UserPassword = Convert.ToBase64String(hashedPwd),
            DateRegistered = DateTime.UtcNow,
            CreatedBy = "system",
            CreatedOn = DateTime.UtcNow
        };

        await _dbContext.UserProfile.AddAsync(newUserProfile);
        int result = await _dbContext.SaveChangesAsync();

        return (result > 0);
    }

    public async Task<UserProfile> Update(UserProfile currentProfile
        , int updatedBy)
    {
        if (!_dbContext.UserProfile.Any(a => a.UserProfileId == currentProfile.UserProfileId)) return null;
        if (_dbContext.UserProfile.Any(a => a.UserName == currentProfile.UserName && a.UserProfileId  != currentProfile.UserProfileId)) return null;

        // Ok to update.
        currentProfile.ModifiedBy = updatedBy.ToString();
        currentProfile.ModifiedOn = DateTime.UtcNow;

        _dbContext.UserProfile.Update(currentProfile);
        await _dbContext.SaveChangesAsync();

        return currentProfile;
    }

    // need an update pwd method 

    public async Task<bool> Delete(int userProfileId, int userId)
    {
        if (!_dbContext.UserProfile.Any(a => a.UserProfileId == userProfileId)) return false;

        var userProfile = await _dbContext
            .UserProfile
            .SingleAsync(s => s.UserProfileId == userProfileId);

        userProfile.DeletedBy = userId.ToString();
        userProfile.DeletedOn = DateTime.UtcNow;

        _dbContext.UserProfile.Update(userProfile);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    private byte[] GenerateSaltedHash(string plainText
        , Guid userId)
    {
        var plainTextData = Encoding.UTF8.GetBytes(plainText);
        var userIdSalt = Encoding.UTF8.GetBytes(userId.ToString());

        var pwdData = plainTextData.Concat(userIdSalt);

        using var sha256 = SHA512.Create();

        return sha256.ComputeHash(pwdData.ToArray());
    }
}