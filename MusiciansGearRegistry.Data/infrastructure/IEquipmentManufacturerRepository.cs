using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IEquipmentManufacturerRepository
{
    Task<EquipmentManufacturer> Get(int manufacturerId);
    Task<List<EquipmentManufacturer>> GetMany(CommonSearchEntity manufacturerSearch);

    Task<EquipmentManufacturer> Add(
        EquipmentManufacturer newManufacturer,
        int userId);

    Task<EquipmentManufacturer> Update(
        EquipmentManufacturer dtoManufacturer,
        int userId);

    Task<bool> Delete(
        int manufacturerId,
        int userId);
}
