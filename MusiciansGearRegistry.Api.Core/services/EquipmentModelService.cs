using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.Services;

public class EquipmentModelService : IEquipmentModelService
{
    private readonly IEquipmentModelRepository _equipmentModelRepo;

    public EquipmentModelService(IEquipmentModelRepository equipmentModelRepository)
    {
        this._equipmentModelRepo = equipmentModelRepository;
    }

    public async Task<EquipmentModel> Add(EquipmentModel equipmentModel, int userId)
    {
        return await _equipmentModelRepo.Add(equipmentModel, userId);
    }

    public async Task<bool> Delete(int equipmentModelId, int userId)
    {
        return await _equipmentModelRepo.Delete(equipmentModelId, userId);
    }

    public async Task<EquipmentModel> Get(int equipmentModelId)
    {
        return await _equipmentModelRepo.Get(equipmentModelId);
    }

    public async Task<List<EquipmentModel>> GetMany(CommonSearchEntity searchEntity)
    {
        return await _equipmentModelRepo.GetMany(searchEntity);
    }

    public async Task<EquipmentModel> Update(EquipmentModel equipmentModel, int userId)
    {
        return await _equipmentModelRepo.Update(equipmentModel, userId);
    }
}
