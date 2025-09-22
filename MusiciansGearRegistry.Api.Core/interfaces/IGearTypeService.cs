using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IGearTypeService
{
    Task<GearType> Get(int GearTypeId);

    Task<Dictionary<Guid, GearType>> GetMany(CommonSearchEntity GearTypeSearch);

    Task<GearType> Add(
                GearType GearType,
                int userId);

    Task<GearType> Update(
                GearType GearType,
                int userId);

    Task<bool> Delete(
                int GearTypeId,
                int userId);
}
