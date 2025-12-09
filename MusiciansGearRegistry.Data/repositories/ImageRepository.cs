using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public class ImageRepository : RepositoryBase, IImageRepository
{
    public ImageRepository(MusiciansGearRegistryContext dbContext) : base(dbContext) { }

    #region "UserGearImages"

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
            UserGearId = userGearImage.UserGearId,
            CreatedBy = userGearImage.CreatedBy,
            CreatedOn = DateTime.UtcNow,
            ImageFile = userGearImage.ImageFile,
            ImageType = userGearImage.ImageType,
            ImageData = userGearImage.ImageData
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

    #endregion

    #region "GearModelImages"

    public async Task<List<int>> Get_GearModelImageIdList(int id)
    {
        return await _dbContext
            .GearModelImage
            .Where(w => w.GearModelId == id)
            .Select(s => s.GearModelImageId)
            .ToListAsync();

    }
    public async Task<KeyValuePair<Guid, GearModelImage>> Get_GearModelImage(int id)
    {
        var gearModelImage = await _dbContext
            .GearModelImage
            .SingleAsync(s => s.GearModelImageId == id);

        return KeyValuePair.Create(Guid.NewGuid(), gearModelImage);
    }

    public async Task<GearModelImage> Add_GearModelImage(dto_GearModelImage gearModelImage)
    {
        var newImage = new GearModelImage()
        {
            GearModelId = gearModelImage.GearModelId,
            CreatedBy = gearModelImage.CreatedBy,
            CreatedOn = DateTime.UtcNow,
            ImageFile = gearModelImage.ImageFile,
            ImageType = gearModelImage.ImageType,
            ImageData = gearModelImage.ImageData
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
        var gearImage = await _dbContext
            .GearModelImage
            .SingleAsync(s => s.GearModelImageId == id); 

        if (gearImage != null) return false;

        gearImage.DeletedOn = DateTime.UtcNow;
        gearImage.DeletedBy = userId.ToString();

        _dbContext
            .GearModelImage
            .Update(gearImage);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    #endregion

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
            GearTypeId = gearTypeImage.GearTypeId,
            CreatedBy = gearTypeImage.CreatedBy,
            CreatedOn = DateTime.UtcNow,
            ImageFile = gearTypeImage.ImageFile,
            ImageType = gearTypeImage.ImageType,
            ImageData = gearTypeImage.ImageData
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
