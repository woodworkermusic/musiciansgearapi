using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class EquipmentTypeService : IEquipmentTypeService
{
    private readonly IEquipmentTypeRepository _equipmentTypeRepo;

    public EquipmentTypeService(IEquipmentTypeRepository equipmentTypeRepo)
    {
        _equipmentTypeRepo = equipmentTypeRepo;
    }

    public async Task<EquipmentType> Add(EquipmentType equipmentType, int userId)
    {
        return await _equipmentTypeRepo.Add(equipmentType, userId);
    }

    public async Task<bool> Delete(int equipmentTypeId, int userId)
    {
        return await _equipmentTypeRepo.Delete(equipmentTypeId, userId);
    }

    public async Task<EquipmentType> Get(int equipmentTypeId)
    {
        return await _equipmentTypeRepo.Get(equipmentTypeId);
    }

    public async Task<List<EquipmentType>> GetMany(CommonSearchEntity equipmentTypeSearch)
    {
        return await _equipmentTypeRepo.GetMany(equipmentTypeSearch);
    }

    public async Task<EquipmentType> Update(EquipmentType equipmentType, int userId)
    {
        return await _equipmentTypeRepo.Update(equipmentType, userId);
    }
}
