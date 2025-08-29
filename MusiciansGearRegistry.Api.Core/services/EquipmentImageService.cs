using MusiciansGearRegistry.Api.Core.dto;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class EquipmentImageService : ServiceBase, IEquipmentImageService
{
    private readonly IEquipmentImageRepository _imageRepo;

    public EquipmentImageService(IEquipmentImageRepository imageRepo
        , ILoggingService logSvc) : base(logSvc, "EquipmentImageService") { 
        _imageRepo = imageRepo;
    }

    public async Task<UserEquipmentImageDto> Get_UserEquipmentImage(int id)
    {
        await _imageRepo.Get_UserEquipmentImage(id);
        return null;
    }

    public async Task<UserEquipmentImageDto> Add_UserEquipmentImage(UserEquipmentImage newImage)
    {
        await _imageRepo.Add_UserEquipmentImage(newImage);
        return null;
    }
    
    public async Task<bool> Delete_UserEquipmentImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_UserEquipmentImage(id, userId);
    }

    // *********************************************************************

    public async Task<EquipmentTypeImageDto> Get_EquipmentTypeImage(int id)
    {
        await _imageRepo.Get_EquipmentTypeImage(id);
        return null;
    }

    public async Task<EquipmentTypeImageDto> Add_EquipmentTypeImage(EquipmentTypeImage newImage
        , int userId)
    {
        await _imageRepo.Add_EquipmentTypeImage(newImage, userId);
        return null;
    }

    public async Task<bool> Delete_EquipmentTypeImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_EquipmentTypeImage(id, userId);
    }

    // *********************************************************************

    public async Task<EquipmentModelImageDto> Get_EquipmentModelImage(int id)
    {
        await _imageRepo.Get_EquipmentModelImage(id);
        return null;
    }

    public async Task<EquipmentModelImageDto> Add_EquipmentModelImage(EquipmentModelImage newImage
        , int userId)
    {
        await _imageRepo.Add_EquipmentModelImage(newImage, userId);
        return null;
    }

    public async Task<bool> Delete_EquipmentModelImage(int id
        , int userId)
    {
        return await _imageRepo.Delete_EquipmentModelImage(id, userId);
    }

}
