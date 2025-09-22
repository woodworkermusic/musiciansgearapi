using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IGearModelRepository
{
    Task<GearModel> Get(int GearModelId);
    Task<List<KeyValuePair<Guid,  GearModel>>> GetMany(CommonSearchEntity searchEntity);

    Task<GearModel?> Add(
        GearModel GearModel,
        int userId);

    Task<GearModel?> Update(
        GearModel GearModel,
        int userId);

    Task<bool> Delete(
        int GearModelId,
        int userId);
}
