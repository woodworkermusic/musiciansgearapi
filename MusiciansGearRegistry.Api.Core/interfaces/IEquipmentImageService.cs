using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IEquipmentImageService
{
    Task<UserEquipmentImage> Get_UserEquipmentImage(int id);
    Task<UserEquipmentImage> Add_UserEquipmentImage(UserEquipmentImage newImage);
    Task<bool> Delete_UserEquipmentImage(int id
        , int userId);

    Task<EquipmentModelImage> Get_EquipmentModelImage(int id);
    Task<EquipmentModelImage> Add_EquipmentModelImage(EquipmentModelImage newImage
        , int userId);
    Task<bool> Delete_EquipmentModelImage(int id
    , int userId);

    Task<EquipmentTypeImage> Get_EquipmentTypeImage(int id);
    Task<EquipmentTypeImage> Add_EquipmentTypeImage(EquipmentTypeImage newImage
        , int userId);
    Task<bool> Delete_EquipmentTypeImage(int id
       , int userId);

}
