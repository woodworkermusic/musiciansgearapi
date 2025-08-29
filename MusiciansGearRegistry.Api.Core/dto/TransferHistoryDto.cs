using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.dto;

public class TransferHistoryDto : TransferHistory 
{
    public int NewUserEquipmentId { get; set; }

    public virtual UserProfileDto UserProfile_From { get; set; }
    public virtual ClientDto Client { get; set; }

    public virtual UserEquipmentDto UserGear { get; set; }
    public virtual UserEquipmentDto NewUserGear { get; set; }
}
