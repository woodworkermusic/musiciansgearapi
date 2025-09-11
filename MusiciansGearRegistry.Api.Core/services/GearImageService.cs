using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class GearImageService : ServiceBase, IGearImageService
{
    private readonly IGearImageRepository _imageRepo;

    public GearImageService(IGearImageRepository imageRepo
        , ILoggingService logSvc) : base(logSvc, "GearImageService") { 
        _imageRepo = imageRepo;
    }

    public async Task<UserGearImage> Get_UserGearImage(int id)
    {
        await _imageRepo.Get_UserGearImage(id);
        return null;
    }

    public async Task<UserGearImage> Add_UserGearImage(UserGearImage newImage)
    {
        await _imageRepo.Add_UserGearImage(newImage);
        return null;
    }
    
    public async Task<bool> Delete_UserGearImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_UserGearImage(id, userId);
    }

    // *********************************************************************

    public async Task<GearTypeImage> Get_GearTypeImage(int id)
    {
        await _imageRepo.Get_GearTypeImage(id);
        return null;
    }

    public async Task<GearTypeImage> Add_GearTypeImage(GearTypeImage newImage
        , int userId)
    {
        await _imageRepo.Add_GearTypeImage(newImage, userId);
        return null;
    }

    public async Task<bool> Delete_GearTypeImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_GearTypeImage(id, userId);
    }

    // *********************************************************************

    public async Task<GearModelImage> Get_GearModelImage(int id)
    {
        await _imageRepo.Get_GearModelImage(id);
        return null;
    }

    public async Task<GearModelImage> Add_GearModelImage(GearModelImage newImage
        , int userId)
    {
        await _imageRepo.Add_GearModelImage(newImage, userId);
        return null;
    }

    public async Task<bool> Delete_GearModelImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_GearModelImage(id, userId);
    }

}
