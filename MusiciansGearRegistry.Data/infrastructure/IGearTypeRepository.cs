using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IGearTypeRepository
{
    Task<GearType> Get(int GearTypeId);
    Task<Dictionary<Guid, GearType>> GetMany(CommonSearchEntity GearTypeSearch);

    Task<GearType?> Add(
        GearType GearType,
        int userId);

    Task<GearType?> Update(
        GearType GearType,
        int userId);

    Task<bool> Delete(
        int GearTypeId,
        int userId);
}
