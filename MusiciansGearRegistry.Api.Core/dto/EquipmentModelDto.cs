using MusiciansGearRegistry.Data.Models;
using Newtonsoft.Json;

namespace MusiciansGearRegistry.Api.Core.dto;

public class EquipmentModelDto : EquipmentModel
{
    [JsonIgnore]
    public virtual EquipmentManufacturerDto EquipmentManufacturer { get; set; }
    [JsonIgnore]
    public virtual EquipmentTypeDto EquipmentType { get; set; }
    [JsonIgnore]
    public virtual ICollection<UserEquipmentDto> UserEquipment { get; set; }
    [JsonIgnore]
    public virtual ICollection<EquipmentModelImageDto> EquipmentModelImages { get; set; }

    public EquipmentModelDto()
    {
        this.UserEquipment = new List<UserEquipmentDto>();
        this.EquipmentModelImages = new List<EquipmentModelImageDto>();
    }

    public EquipmentModelDto(EquipmentModel equipmentModel)
    {

    }
}
