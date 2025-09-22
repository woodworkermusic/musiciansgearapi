using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IManufacturerRepository
{
    Task<Manufacturer> Get(int manufacturerId);
    Task<List<KeyValuePair<Guid, Manufacturer>>> GetMany(CommonSearchEntity manufacturerSearch);

    Task<Manufacturer> Add(
        dtoManufacturer newManufacturer,
        int userId);

    Task<Manufacturer> Update(
        dtoManufacturer dtoManufacturer,
        int userId);

    Task<bool> Delete(
        int manufacturerId,
        int userId);
}
