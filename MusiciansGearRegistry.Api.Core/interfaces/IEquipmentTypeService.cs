using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IEquipmentTypeService
{
    Task<EquipmentModel> EquipmentType_Get(int EquipmentTypeId);

    Task<List<EquipmentType>> EquipmentType_GetMany(CommonSearchEntity equipmentTypeSearch);

    Task<EquipmentModel> EquipmentType_Add(
                EquipmentModel equipmentType,
                int userId);

    Task<EquipmentModel> EquipmentType_Update(
                EquipmentModel equipmentType,
                int userId);

    Task<bool> EquipmentType_Delete(
                int equipmentTypeId,
                int userId);
}
