using Microsoft.EntityFrameworkCore;
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

    public async Task<UserGearImage> Add_UserGearImage(UserGearImage newImage)
    {
        await _dbContext
            .UserGearImage
            .AddAsync(newImage);

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

        return true;
    }

    public async Task<GearModelImage> Get_GearModelImage(int id)
    {
        return await _dbContext
            .GearModelImage
            .SingleAsync(s => s.GearModelImageId == id);
    }

    public async Task<GearModelImage> Add_GearModelImage(GearModelImage newImage
        , int userId)
    {
        newImage.CreatedOn = DateTime.UtcNow;
        newImage.CreatedBy = userId.ToString();

        await _dbContext
            .GearModelImage
            .AddAsync(newImage);

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

        return true;
    }

    public async Task<GearTypeImage> Get_GearTypeImage(int id)
    {
        return await _dbContext
            .GearTypeImage
            .SingleAsync(s => s.GearTypeImageId == id);
    }

    public async Task<GearTypeImage> Add_GearTypeImage(GearTypeImage newImage
        , int userId)
    {
        newImage.CreatedOn = DateTime.UtcNow;
        newImage.CreatedBy = userId.ToString();

        await _dbContext
            .GearTypeImage
            .AddAsync(newImage);

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

        return true;
    }
}
