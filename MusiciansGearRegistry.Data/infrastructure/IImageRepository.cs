using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IImageRepository
{
    Task<UserGearImage> Get_UserGearImage(int id);
    Task<UserGearImage> Add_UserGearImage(INewImage newImage);
    Task<bool> Delete_UserGearImage(int id
        , int userId);

    Task<List<int>> Get_GearModelImageIdList(int id);
    Task<KeyValuePair<Guid, GearModelImage>> Get_GearModelImage(int id);
    Task<GearModelImage> Add_GearModelImage(INewImage newImage);
    Task<bool> Delete_GearModelImage(int id
    , int userId);

    Task<GearTypeImage> Get_GearTypeImage(int id);
    Task<GearTypeImage> Add_GearTypeImage(INewImage newImage);
    Task<bool> Delete_GearTypeImage(int id
       , int userId);
}
