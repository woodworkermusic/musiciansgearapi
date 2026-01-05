using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface ISearchService
{
    Task<List<GearModel>> ByManufacturer(CommonSearchEntity searchEntity);
    Task<List<GearModel>> ByGearType(CommonSearchEntity searchEntity);
    Task<List<GearModel>> ByModel(CommonSearchEntity searchEntity);
}
