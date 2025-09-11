using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IGearImageService
{
    Task<UserGearImage> Get_UserGearImage(int id);
    Task<UserGearImage> Add_UserGearImage(UserGearImage newImage);
    Task<bool> Delete_UserGearImage(int id
        , int userId);

    Task<GearModelImage> Get_GearModelImage(int id);
    Task<GearModelImage> Add_GearModelImage(GearModelImage newImage
        , int userId);
    Task<bool> Delete_GearModelImage(int id
    , int userId);

    Task<GearTypeImage> Get_GearTypeImage(int id);
    Task<GearTypeImage> Add_GearTypeImage(GearTypeImage newImage
        , int userId);
    Task<bool> Delete_GearTypeImage(int id
       , int userId);

}
