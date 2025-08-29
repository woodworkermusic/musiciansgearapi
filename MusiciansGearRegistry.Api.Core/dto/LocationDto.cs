using MusiciansGearRegistry.Data.Models;
using Newtonsoft.Json;

namespace MusiciansGearRegistry.Api.Core.dto;

public class LocationDto : Location
{
    [JsonIgnore]
    public virtual EquipmentManufacturerDto EquipmentManufacturer { get; set; }
    [JsonIgnore]
    public virtual ClientDto Client { get; set; }
    [JsonIgnore]
    public virtual UserProfileDto UserProfile { get; set; }
}

