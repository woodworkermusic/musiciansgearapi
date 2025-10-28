using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using MusiciansGearRegistry.Data.dto;

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
        return await _imageRepo.Get_UserGearImage(id);
    }

    public async Task<UserGearImage> Add_UserGearImage(dto_UserGearImage newImage)
    {
        return await _imageRepo.Add_UserGearImage(newImage);
    }
    
    public async Task<bool> Delete_UserGearImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_UserGearImage(id, userId);
    }

    // *********************************************************************

    public async Task<GearTypeImage> Get_GearTypeImage(int id)
    {
        return await _imageRepo.Get_GearTypeImage(id);
    }

    public async Task<GearTypeImage> Add_GearTypeImage(dto_GearTypeImage newImage)
    {
        return await _imageRepo.Add_GearTypeImage(newImage);
    }

    public async Task<bool> Delete_GearTypeImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_GearTypeImage(id, userId);
    }

    // *********************************************************************

    public async Task<GearModelImage> Get_GearModelImage(int id)
    {
        return await _imageRepo.Get_GearModelImage(id);
    }

    public async Task<GearModelImage> Add_GearModelImage(dto_GearModelImage newImage)
    {
        return await _imageRepo.Add_GearModelImage(newImage);
    }

    public async Task<bool> Delete_GearModelImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_GearModelImage(id, userId);
    }

}
