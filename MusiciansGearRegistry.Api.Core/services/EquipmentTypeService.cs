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

    public Task<EquipmentModel> EquipmentType_Add(EquipmentModel equipmentType, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EquipmentType_Delete(int equipmentTypeId, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentModel> EquipmentType_Get(int EquipmentTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<List<EquipmentType>> EquipmentType_GetMany(CommonSearchEntity equipmentTypeSearch)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentModel> EquipmentType_Update(EquipmentModel equipmentType, int userId)
    {
        throw new NotImplementedException();
    }
}
