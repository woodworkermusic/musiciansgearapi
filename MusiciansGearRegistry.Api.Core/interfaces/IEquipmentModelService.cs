using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IEquipmentModelService
{
    Task<EquipmentModel> Get(
        int equipmentModelId);

    Task<List<EquipmentModel>> GetMany(CommonSearchEntity searchEntity);

    Task<EquipmentModel> Add(
                EquipmentModel equipmentModelDto,
                int userId);

    Task<EquipmentModel> Update(
                EquipmentModel equipmentModel,
                int userId);

    Task<bool> Delete(
                int equipmentModelId,
                int userId);
}
