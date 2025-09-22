using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class GearTypeService : IGearTypeService
{
    private readonly IGearTypeRepository _GearTypeRepo;

    public GearTypeService(IGearTypeRepository GearTypeRepo)
    {
        _GearTypeRepo = GearTypeRepo;
    }

    public async Task<GearType> Add(GearType GearType, int userId)
    {
        return await _GearTypeRepo.Add(GearType, userId);
    }

    public async Task<bool> Delete(int GearTypeId, int userId)
    {
        return await _GearTypeRepo.Delete(GearTypeId, userId);
    }

    public async Task<GearType> Get(int GearTypeId)
    {
        return await _GearTypeRepo.Get(GearTypeId);
    }

    public async Task<List<KeyValuePair<Guid,  GearType>>> GetMany(CommonSearchEntity GearTypeSearch)
    {
        return await _GearTypeRepo.GetMany(GearTypeSearch);
    }

    public async Task<GearType> Update(GearType GearType, int userId)
    {
        return await _GearTypeRepo.Update(GearType, userId);
    }
}
