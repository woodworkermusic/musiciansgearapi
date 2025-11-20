using MusiciansGearRegistry.Data.models;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IUserProfileRepository
{
    Task<UserProfile> Get(int userProfileId);
    Task<bool> Add(CreateUserRequest createRequest);
    Task<UserProfile> Update(UserProfile currentProfile
        , int updatedBy);

    Task<bool> Delete(int userProfileId, int userId);
}
