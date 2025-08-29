using MusiciansGearRegistry.Api.Core.dto;
using MusiciansGearRegistry.Api.Core.Entities;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using MusiciansGearRegistry.Api.Logging.interfaces;

namespace MusiciansGearRegistry.Api.Core.services;

public class EquipmentTypeService : IEquipmentTypeService
{
    private readonly IEquipmentTypeRepository _equipmentTypeRepo;

    public EquipmentTypeService(IEquipmentTypeRepository equipmentTypeRepo)
    {
        _equipmentTypeRepo = equipmentTypeRepo;
    }

    public Task<EquipmentModelDto> EquipmentType_Add(EquipmentModel equipmentType, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EquipmentType_Delete(int equipmentTypeId, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentModelDto> EquipmentType_Get(int EquipmentTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<List<EquipmentTypeDto>> EquipmentType_GetMany(CommonSearchEntity equipmentTypeSearch)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentModelDto> EquipmentType_Update(EquipmentModel equipmentType, int userId)
    {
        throw new NotImplementedException();
    }
}
