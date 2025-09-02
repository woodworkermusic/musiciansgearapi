using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IEquipmentModelService
{
    Task<EquipmentModel> EquipmentModel_Get(
        int equipmentModelId);

    Task<List<EquipmentModel>> EquipmentModel_GetMany(
                int? manufacturerId,
                int? modelTypeId,
                string startsWith,
                int pageNumber,
                int pageCount);

    Task<EquipmentModel> EquipmentModel_Add(
                EquipmentModel equipmentModelDto,
                int userId);

    Task<EquipmentModel> EquipmentModel_Update(
                EquipmentModel equipmentModelDto,
                int userId);

    Task<bool> EquipmentModel_Delete(
                int equipmentModelId,
                int userId);
}
