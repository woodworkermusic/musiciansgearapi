using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IManufacturerService
{
    Task<Manufacturer> Get(
            int manufacturerId);

    Task<List<KeyValuePair<Guid, Manufacturer>>> GetMany(CommonSearchEntity manufacturerSearch);

    Task<Manufacturer> Add(
                dto_Manufacturer Manufacturer,
                int userId);

    Task<Manufacturer> Update(
                dto_Manufacturer Manufacturer,
                int userId);

    Task<bool> Delete(
        int manufacturerId,
        int userId);
}
