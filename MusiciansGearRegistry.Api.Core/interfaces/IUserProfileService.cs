using MusiciansGearRegistry.Data.models;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IUserProfileService
{
    Task<UserProfile> Get(int userProfileId);
    Task<bool> Add(CreateUserRequest createUserRequest);
    Task<UserProfile> Update(
        UserProfile updatedProfile,
        int updatedBy);
    Task<bool> Delete(int userProfileId
        , int userId);
}
