using MusiciansGearRegistry.Api.Core.dto;
using MusiciansGearRegistry.Api.Core.Entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IEquipmentTypeService
{
    Task<EquipmentModelDto> EquipmentType_Get(int EquipmentTypeId);

    Task<List<EquipmentTypeDto>> EquipmentType_GetMany(CommonSearchEntity equipmentTypeSearch);

    Task<EquipmentModelDto> EquipmentType_Add(
                EquipmentModel equipmentType,
                int userId);

    Task<EquipmentModelDto> EquipmentType_Update(
                EquipmentModel equipmentType,
                int userId);

    Task<bool> EquipmentType_Delete(
                int equipmentTypeId,
                int userId);
}
