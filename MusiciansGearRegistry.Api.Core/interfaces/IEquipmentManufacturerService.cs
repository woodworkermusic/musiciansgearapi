using MusiciansGearRegistry.Api.Core.dto;
using MusiciansGearRegistry.Api.Core.Entities;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IEquipmentManufacturerService
{
    Task<EquipmentManufacturerDto> Get(
            int manufacturerId);

    Task<List<EquipmentManufacturerDto>> GetMany(CommonSearchEntity manufacturerSearch);

    Task<EquipmentManufacturerDto> Add(
                EquipmentManufacturer dtoManufacturer,
                int userId);

    Task<EquipmentManufacturerDto> Update(
                EquipmentManufacturer dtoManufacturer,
                int userId);

    Task<bool> Delete(
        int manufacturerId,
        int userId);

}
