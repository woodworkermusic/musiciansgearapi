using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.interfaces;

public interface IImageService
{
    Task<UserGearImage> Get_UserGearImage(int id);
    Task<UserGearImage> Add_UserGearImage(INewImage userGearImage);
    Task<bool> Delete_UserGearImage(int id
        , int userId);

    Task<List<int>> Get_GearModelImageIdList(int id);
    Task<GearModelImage> Get_GearModelImage(int id);
    Task<GearModelImage> Add_GearModelImage(INewImage gearModelImage);
    Task<bool> Delete_GearModelImage(int id
    , int userId);

    Task<GearTypeImage> Get_GearTypeImage(int id);
    Task<GearTypeImage> Add_GearTypeImage(INewImage gearTypeImage);
    Task<bool> Delete_GearTypeImage(int id
       , int userId);

}
