using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IUserGearRepository
{
    Task<UserGear> Get(int userGearId);
    Task<List<UserGear>> GetMany(int userProfileId);
    Task<UserGear> Add(UserGear newGear,
        int userId);

    Task<UserGear> Update(UserGear Gear
        , int userId);

    Task<bool> Delete(
        int userGearId,
        int userId);
}
