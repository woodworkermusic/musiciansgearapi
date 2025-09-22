using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.Services;

public class GearModelService : IGearModelService
{
    private readonly IGearModelRepository _GearModelRepo;

    public GearModelService(IGearModelRepository GearModelRepository)
    {
        this._GearModelRepo = GearModelRepository;
    }

    public async Task<GearModel> Add(GearModel GearModel, int userId)
    {
        return await _GearModelRepo.Add(GearModel, userId);
    }

    public async Task<bool> Delete(int GearModelId, int userId)
    {
        return await _GearModelRepo.Delete(GearModelId, userId);
    }

    public async Task<GearModel> Get(int GearModelId)
    {
        return await _GearModelRepo.Get(GearModelId);
    }

    public async Task<List<KeyValuePair<Guid,  GearModel>>> GetMany(CommonSearchEntity searchEntity)
    {
        return await _GearModelRepo.GetMany(searchEntity);
    }

    public async Task<GearModel> Update(GearModel GearModel, int userId)
    {
        return await _GearModelRepo.Update(GearModel, userId);
    }
}
