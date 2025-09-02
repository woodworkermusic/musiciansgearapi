using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IEquipmentManufacturerService
{
    Task<EquipmentManufacturer> Get(
            int manufacturerId);

    Task<List<EquipmentManufacturer>> GetMany(CommonSearchEntity manufacturerSearch);

    Task<EquipmentManufacturer> Add(
                EquipmentManufacturer equipmentManufacturer,
                int userId);

    Task<EquipmentManufacturer> Update(
                EquipmentManufacturer equipmentManufacturer,
                int userId);

    Task<bool> Delete(
        int manufacturerId,
        int userId);
}
