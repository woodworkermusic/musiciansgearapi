using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IGearTypeService
{
    Task<GearType> Get(int GearTypeId);

    Task<List<GearType>> GetMany(CommonSearchEntity GearTypeSearch);
    Task<List<GearType>> Get();

    Task<List<GearType>> GetByManufacturer(int manufacturerId);

    Task<GearType> Add(
                dto_GearType GearType,
                int userId);

    Task<GearType> Update(
                GearType GearType,
                int userId);

    Task<bool> Delete(
                int GearTypeId,
                int userId);
}
