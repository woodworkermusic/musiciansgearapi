using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IEquipmentTypeRepository
{
    Task<EquipmentType> Get(int EquipmentTypeId);
    Task<List<EquipmentType>> GetMany(CommonSearchEntity equipmentTypeSearch);

    Task<EquipmentType?> Add(
        EquipmentType equipmentType,
        int userId);

    Task<EquipmentType?> Update(
        EquipmentType equipmentType,
        int userId);

    Task<bool> Delete(
        int EquipmentTypeId,
        int userId);
}
