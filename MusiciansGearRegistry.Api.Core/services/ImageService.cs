using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using MusiciansGearRegistry.Data.dto;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MusiciansGearRegistry.Api.Core.services;

public class ImageService : ServiceBase, IImageService
{
    private readonly IImageRepository _imageRepo;

    public ImageService(IImageRepository imageRepo
        , ILoggingService logSvc
        , ILogger<ImageService> log
        , TelemetryClient telemetryClient
        ) 
        : base(logSvc, log, telemetryClient) { 
        _imageRepo = imageRepo;
    }

    #region "UserGearImages"

    public async Task<UserGearImage> Get_UserGearImage(int id)
    {
        return await _imageRepo.Get_UserGearImage(id);
    }

    public async Task<UserGearImage> Add_UserGearImage(INewImage newImage)
    {
        return await _imageRepo.Add_UserGearImage(newImage);
    }
    
    public async Task<bool> Delete_UserGearImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_UserGearImage(id, userId);
    }

    #endregion

    #region "GearTypeImages"

    public async Task<GearTypeImage> Get_GearTypeImage(int id)
    {
        return await _imageRepo.Get_GearTypeImage(id);
    }

    public async Task<GearTypeImage> Add_GearTypeImage(INewImage newImage)
    {
        return await _imageRepo.Add_GearTypeImage(newImage);
    }

    public async Task<bool> Delete_GearTypeImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_GearTypeImage(id, userId);
    }

    #endregion

    #region "GearModelImages"

    public async Task<List<int>> Get_GearModelImageIdList(int id)
    {
        return await _imageRepo.Get_GearModelImageIdList(id);
    }

    public async Task<KeyValuePair<Guid, GearModelImage>> Get_GearModelImage(int id)
    {
        return await _imageRepo.Get_GearModelImage(id);
    }

    public async Task<GearModelImage> Add_GearModelImage(INewImage newImage)
    {
        return await _imageRepo.Add_GearModelImage(newImage);
    }

    public async Task<bool> Delete_GearModelImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_GearModelImage(id, userId);
    }

    #endregion
}
