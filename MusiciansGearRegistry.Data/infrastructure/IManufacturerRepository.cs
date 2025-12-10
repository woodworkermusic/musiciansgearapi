using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IManufacturerRepository
{
    Task<Manufacturer> Get(int manufacturerId);
    Task<List<Manufacturer>> GetMany(CommonSearchEntity manufacturerSearch);

    Task<Manufacturer> Add(
        dto_Manufacturer newManufacturer,
        int userId);

    Task<Manufacturer> Update(
        dto_Manufacturer dtoManufacturer,
        int userId);

    Task<bool> Delete(
        int manufacturerId,
        int userId);
}
