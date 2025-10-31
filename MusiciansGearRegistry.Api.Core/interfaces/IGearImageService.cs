using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IGearImageService
{
    Task<UserGearImage> Get_UserGearImage(int id);
    Task<UserGearImage> Add_UserGearImage(dto_UserGearImage userGearImage);
    Task<bool> Delete_UserGearImage(int id
        , int userId);

    Task<KeyValuePair<Guid, GearModelImage>> Get_GearModelImage(int id);
    Task<GearModelImage> Add_GearModelImage(dto_GearModelImage gearModelImage);
    Task<bool> Delete_GearModelImage(int id
    , int userId);

    Task<GearTypeImage> Get_GearTypeImage(int id);
    Task<GearTypeImage> Add_GearTypeImage(dto_GearTypeImage gearTypeImage);
    Task<bool> Delete_GearTypeImage(int id
       , int userId);

}
