using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public class GearImageRepository : RepositoryBase, IGearImageRepository
{
    public GearImageRepository(MusiciansGearRegistryContext dbContext) : base(dbContext) { }

    public async Task<UserGearImage> Get_UserGearImage(int id)
    {
        return await _dbContext
            .UserGearImage
            .SingleAsync(s => s.UserGearImageId == id);
    }

    public async Task<UserGearImage> Add_UserGearImage(dto_UserGearImage userGearImage)
    {
        var newImage = new UserGearImage()
        {
            CreatedBy = userGearImage.CreatedBy,
            CreatedOn = DateTime.UtcNow,
            ImageFile = userGearImage.ImageFile,
            ImageData = System.Text.Encoding.UTF8.GetBytes(userGearImage.ImageData)
        };

        await _dbContext
            .UserGearImage
            .AddAsync(newImage);

        await _dbContext.SaveChangesAsync();

        return newImage;
    }

    public async Task<bool> Delete_UserGearImage(int id
        , int userId)
    {
        var GearImage = await Get_UserGearImage(id);

        if (GearImage != null) return false;

        GearImage.DeletedOn = DateTime.UtcNow;
        GearImage.DeletedBy = userId.ToString();

        _dbContext
            .UserGearImage
            .Update(GearImage);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<GearModelImage> Get_GearModelImage(int id)
    {
        return await _dbContext
            .GearModelImage
            .SingleAsync(s => s.GearModelImageId == id);
    }

    public async Task<GearModelImage> Add_GearModelImage(dto_GearModelImage gearModelImage)
    {
        var newImage = new GearModelImage()
        {
            CreatedBy = gearModelImage.CreatedBy,
            CreatedOn = DateTime.UtcNow,
            ImageFile = gearModelImage.ImageFile,
            ImageData = System.Text.Encoding.UTF8.GetBytes(gearModelImage.ImageData)
        };

        await _dbContext
            .GearModelImage
            .AddAsync(newImage);

        await _dbContext.SaveChangesAsync();

        return newImage;
    }

    public async Task<bool> Delete_GearModelImage(int id
    , int userId)
    {
        var GearImage = await Get_GearModelImage(id);

        if (GearImage != null) return false;

        GearImage.DeletedOn = DateTime.UtcNow;
        GearImage.DeletedBy = userId.ToString();

        _dbContext
            .GearModelImage
            .Update(GearImage);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<GearTypeImage> Get_GearTypeImage(int id)
    {
        return await _dbContext
            .GearTypeImage
            .SingleAsync(s => s.GearTypeImageId == id);
    }

    public async Task<GearTypeImage> Add_GearTypeImage(dto_GearTypeImage gearTypeImage)
    {
        var newImage = new GearTypeImage()
        {
            CreatedBy = gearTypeImage.CreatedBy,
            CreatedOn = DateTime.UtcNow,
            ImageFile = gearTypeImage.ImageFile,
            ImageData = System.Text.Encoding.UTF8.GetBytes(gearTypeImage.ImageData)
        };

        await _dbContext
            .GearTypeImage
            .AddAsync(newImage);

        await _dbContext.SaveChangesAsync();

        return newImage;
    }

    public async Task<bool> Delete_GearTypeImage(int id
    , int userId)
    {
        var GearImage = await Get_GearTypeImage(id);

        if (GearImage != null) return false;

        GearImage.DeletedOn = DateTime.UtcNow;
        GearImage.DeletedBy = userId.ToString();

        _dbContext
            .GearTypeImage
            .Update(GearImage);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}
