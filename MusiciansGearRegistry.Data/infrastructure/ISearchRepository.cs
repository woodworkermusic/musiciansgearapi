using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface ISearchRepository
{
    Task<List<GearModel>> ByManufacturer(CommonSearchEntity searchEntity);
    Task<List<GearModel>> ByGearType(CommonSearchEntity searchEntity);
    Task<List<GearModel>> ByModel(CommonSearchEntity searchEntity);
}
