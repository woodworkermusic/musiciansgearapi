using MusiciansGearRegistry.Api.Core.dto;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IEquipmentImageService
{
    Task<UserEquipmentImageDto> Get_UserEquipmentImage(int id);
    Task<UserEquipmentImageDto> Add_UserEquipmentImage(UserEquipmentImage newImage);
    Task<bool> Delete_UserEquipmentImage(int id
        , int userId);

    Task<EquipmentModelImageDto> Get_EquipmentModelImage(int id);
    Task<EquipmentModelImageDto> Add_EquipmentModelImage(EquipmentModelImage newImage
        , int userId);
    Task<bool> Delete_EquipmentModelImage(int id
    , int userId);

    Task<EquipmentTypeImageDto> Get_EquipmentTypeImage(int id);
    Task<EquipmentTypeImageDto> Add_EquipmentTypeImage(EquipmentTypeImage newImage
        , int userId);
    Task<bool> Delete_EquipmentTypeImage(int id
       , int userId);

}
