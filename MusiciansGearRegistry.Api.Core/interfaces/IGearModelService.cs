using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IGearModelService
{
    Task<GearModel> Get(
        int GearModelId);

    Task<List<GearModel>> GetMany(CommonSearchEntity searchEntity);

    Task<List<GearModel>> GetByManufacturerAndType(int manufacturerId
        , int gearTypeId);

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
