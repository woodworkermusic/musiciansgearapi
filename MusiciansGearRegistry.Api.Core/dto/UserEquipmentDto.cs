using MusiciansGearRegistry.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Api.Core.dto;

[NotMapped]
public class UserEquipmentDto : UserEquipment
{
    public List<UserEquipmentImageDto> userGearImages { get; set; } = new List<UserEquipmentImageDto>();

    public UserEquipmentDto(UserEquipment userGear)
    {
        if (userGear != null)
        {
            this.UserEquipmentId = userGear.UserEquipmentId;
            this.UserProfileId = userGear.UserProfileId;
            this.Active = userGear.Active;
            this.EquipmentModelId = userGear.EquipmentModelId;
            this.SerialNumber = userGear.SerialNumber;
            this.DateAcquired = userGear.DateAcquired;
            this.IsOriginal = userGear.IsOriginal;
            this.EquipmentNotes = userGear.EquipmentNotes;

            //this.AssignStampFields<UserEquipment>(this, userGear);

            //if (userGear.UserGearImages != null)
            //{
            //    userGear.UserGearImages.ToList()
            //        .ForEach(x => this.userGearImages.Add(new UserEquipmentImageDto(x)));
            //}
        }
    }
}
