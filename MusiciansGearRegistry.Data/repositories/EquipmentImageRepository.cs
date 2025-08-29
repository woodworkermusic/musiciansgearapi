using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public class EquipmentImageRepository : RepositoryBase, IEquipmentImageRepository
{
    public EquipmentImageRepository(MusiciansGearRegistryContext dbContext) : base(dbContext) { }

    public async Task<UserEquipmentImage> Get_UserEquipmentImage(int id)
    {
        return await _dbContext
            .UserEquipmentImage
            .SingleAsync(s => s.UserEquipmentImageId == id);
    }

    public async Task<UserEquipmentImage> Add_UserEquipmentImage(UserEquipmentImage newImage)
    {
        await _dbContext
            .UserEquipmentImage
            .AddAsync(newImage);

        return newImage;
    }

    public async Task<bool> Delete_UserEquipmentImage(int id
        , int userId)
    {
        var equipmentImage = await Get_UserEquipmentImage(id);

        if (equipmentImage != null) return false;

        equipmentImage.DeletedOn = DateTime.UtcNow;
        equipmentImage.DeletedBy = userId.ToString();

        _dbContext
            .UserEquipmentImage
            .Update(equipmentImage);

        return true;
    }

    public async Task<EquipmentModelImage> Get_EquipmentModelImage(int id)
    {
        return await _dbContext
            .EquipmentModelImage
            .SingleAsync(s => s.EquipmentModelImageId == id);
    }

    public async Task<EquipmentModelImage> Add_EquipmentModelImage(EquipmentModelImage newImage
        , int userId)
    {
        newImage.CreatedOn = DateTime.UtcNow;
        newImage.CreatedBy = userId.ToString();

        await _dbContext
            .EquipmentModelImage
            .AddAsync(newImage);

        return newImage;
    }

    public async Task<bool> Delete_EquipmentModelImage(int id
    , int userId)
    {
        var equipmentImage = await Get_EquipmentModelImage(id);

        if (equipmentImage != null) return false;

        equipmentImage.DeletedOn = DateTime.UtcNow;
        equipmentImage.DeletedBy = userId.ToString();

        _dbContext
            .EquipmentModelImage
            .Update(equipmentImage);

        return true;
    }

    public async Task<EquipmentTypeImage> Get_EquipmentTypeImage(int id)
    {
        return await _dbContext
            .EquipmentTypeImage
            .SingleAsync(s => s.EquipmentTypeImageId == id);
    }

    public async Task<EquipmentTypeImage> Add_EquipmentTypeImage(EquipmentTypeImage newImage
        , int userId)
    {
        newImage.CreatedOn = DateTime.UtcNow;
        newImage.CreatedBy = userId.ToString();

        await _dbContext
            .EquipmentTypeImage
            .AddAsync(newImage);

        return newImage;
    }

    public async Task<bool> Delete_EquipmentTypeImage(int id
    , int userId)
    {
        var equipmentImage = await Get_EquipmentTypeImage(id);

        if (equipmentImage != null) return false;

        equipmentImage.DeletedOn = DateTime.UtcNow;
        equipmentImage.DeletedBy = userId.ToString();

        _dbContext
            .EquipmentTypeImage
            .Update(equipmentImage);

        return true;
    }
}
