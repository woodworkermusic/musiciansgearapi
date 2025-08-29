using MusiciansGearRegistry.Api.Core.dto;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IEquipmentModelService
{
    Task<EquipmentModelDto> EquipmentModel_Get(
        int equipmentModelId);

    Task<List<EquipmentModelDto>> EquipmentModel_GetMany(
                int? manufacturerId,
                int? modelTypeId,
                string startsWith,
                int pageNumber,
                int pageCount);

    Task<EquipmentModelDto> EquipmentModel_Add(
                EquipmentModel equipmentModelDto,
                int userId);

    Task<EquipmentModelDto> EquipmentModel_Update(
                EquipmentModel equipmentModelDto,
                int userId);

    Task<bool> EquipmentModel_Delete(
                int equipmentModelId,
                int userId);
}
