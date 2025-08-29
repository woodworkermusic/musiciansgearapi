using MusiciansGearRegistry.Data.Models;
using Newtonsoft.Json;

namespace MusiciansGearRegistry.Api.Core.dto;

public class EquipmentManufacturerDto : EquipmentManufacturer
{
    [JsonIgnore]
    public virtual ICollection<EquipmentModelDto> EquipmentModels { get; set; }
    [JsonIgnore]
    public virtual ICollection<LocationDto> ManufacturerLocations { get; set; }

    public EquipmentManufacturerDto()
    {
        this.EquipmentModels = new List<EquipmentModelDto>();
        this.ManufacturerLocations = new List<LocationDto>();
    }

    public EquipmentManufacturerDto(EquipmentManufacturer? manufacturer 
        , bool fullDetail)
    {
        if (manufacturer == null) return;

        if (fullDetail)
        {
        }
    }
}
