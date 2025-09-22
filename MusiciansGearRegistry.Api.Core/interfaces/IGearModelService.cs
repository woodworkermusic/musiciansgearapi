using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IGearModelService
{
    Task<GearModel> Get(
        int GearModelId);

    Task<List<KeyValuePair<Guid,  GearModel>>> GetMany(CommonSearchEntity searchEntity);

    Task<GearModel> Add(
                GearModel GearModelDto,
                int userId);

    Task<GearModel> Update(
                GearModel GearModel,
                int userId);

    Task<bool> Delete(
                int GearModelId,
                int userId);
}
