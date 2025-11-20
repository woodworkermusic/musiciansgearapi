using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.models;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class UserProfileService : ServiceBase, IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepo;

    public UserProfileService(IUserProfileRepository userProfileRepo
        , ILoggingService log)
        : base(log, "UserProfileService")
    {
        _userProfileRepo = userProfileRepo;
    }

    public async Task<UserProfile> Get(int userProfileId)
    {
        return await _userProfileRepo.Get(userProfileId);
    }


    public async Task<bool> Add(CreateUserRequest createUserRequest)
    {
        return await _userProfileRepo.Add(createUserRequest);
    }

    public async Task<UserProfile> Update(
        UserProfile updatedProfile,
        int updatedBy)
    {
        return await _userProfileRepo.Update(updatedProfile, updatedBy);
    }

    public async Task<bool> Delete(int userProfileId
        , int userId)
    {
        return await _userProfileRepo.Delete(userProfileId, userId);
    }
}

