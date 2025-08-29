using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.dto;

public class UserEquipmentImageDto : UserEquipmentImage
{
    public bool isDeleted { get; set; }
    public bool restoreItem { get; set; }

    public UserEquipmentImageDto(UserEquipmentImage userGearImage = null)
    {
        if (userGearImage != null)
        {
            this.isDeleted = false;
            this.restoreItem = false;

            this.UserEquipmentImageId = userGearImage.UserEquipmentImageId;
            this.UserEquipmentId = userGearImage.UserEquipmentId;
            this.EquipmentImageFile = userGearImage.EquipmentImageFile;

            //this.AssignStampFields<UserEquipmentImage>(this, userGearImage);
        }
    }
}
