using Microsoft.EntityFrameworkCore;
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
            .SingleAsync(s => s.UserGearImageId == id && s.DeletedOn == null);
    }

    public async Task<UserGearImage> Add_UserGearImage(INewImage userGearImage)
    {
        var newImage = new UserGearImage()
        {
            UserGearId = userGearImage.ParentId,
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

        if (GearImage == null) return false;

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
            .Where(w => w.GearModelId == id && w.DeletedOn == null)
            .Select(s => s.GearModelImageId)
            .ToListAsync();

    }

    public async Task<GearModelImage> Get_GearModelImage(int id)
    {
        var gearModelImage = await _dbContext
            .GearModelImage
            .SingleAsync(s => s.GearModelImageId == id && s.DeletedOn == null);

        gearModelImage.ImageId = id;
        return gearModelImage;
    }

    public async Task<GearModelImage> Add_GearModelImage(INewImage gearModelImage)
    {
        var newImage = new GearModelImage()
        {
            GearModelId = gearModelImage.ParentId,
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
        var gearImage = await Get_GearModelImage(id);

        if (gearImage == null) return false;

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
        var gearTypeImage = await _dbContext
            .GearTypeImage
            .SingleAsync(s => s.GearTypeImageId == id && s.DeletedOn == null);

        gearTypeImage.ImageId = id;
        return gearTypeImage;
    }

    public async Task<GearTypeImage> Add_GearTypeImage(INewImage gearTypeImage)
    {
        var newImage = new GearTypeImage()
        {
            GearTypeId = gearTypeImage.ParentId,
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

        if (GearImage == null) return false;

        GearImage.DeletedOn = DateTime.UtcNow;
        GearImage.DeletedBy = userId.ToString();

        _dbContext
            .GearTypeImage
            .Update(GearImage);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}
