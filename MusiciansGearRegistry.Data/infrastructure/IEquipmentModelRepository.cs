using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IEquipmentModelRepository
{
    Task<EquipmentModel> Get(int equipmentModelId);
    Task<List<EquipmentModel>> GetMany(
        int? manufacturerId,
        string startsWith,
        int pageNumber,
        int pageCount);

    Task<EquipmentModel?> Add(
        EquipmentModel equipmentModel,
        int userId);

    Task<EquipmentModel?> Update(
        EquipmentModel equipmentModel,
        int userId);

    Task<bool> Delete(
        int equipmentModelId,
        int userId);
}
