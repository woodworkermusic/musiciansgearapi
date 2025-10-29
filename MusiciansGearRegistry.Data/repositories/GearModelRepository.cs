using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public class GearModelRepository : RepositoryBase, IGearModelRepository
{
    public GearModelRepository(MusiciansGearRegistryContext dbContext) : base(dbContext)
    {
    }

    public async Task<GearModel> Get(int gearModelId)
    {
        var gearModel = await _dbContext.GearModel
            .SingleOrDefaultAsync(x =>
                x.GearModelId == gearModelId &&
                x.DeletedOn == null);

        var imageIdList = await _dbContext
            .GearModelImage
            .Where(w => w.GearModelId == gearModelId)
            .Select(s => s.GearModelImageId)
            .ToListAsync();

        gearModel.ImageIdList.AddRange(imageIdList);
        return gearModel;
    }

    /// <summary>
    /// The nullable manufacturerId value allows us to look up both by name and use manufacturer as a filter.
    /// </summary>
    /// <param name="manufacturerId"></param>
    /// <param name="startsWith"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageCount"></param>
    /// <returns></returns>
    public async Task<List<KeyValuePair<Guid,  GearModel>>> GetMany(CommonSearchEntity searchEntity)
    {
        var searchResult = await _dbContext.GearModel
            .Where(m =>
                (
                    string.IsNullOrWhiteSpace(searchEntity.startsWith) ||
                    (!string.IsNullOrWhiteSpace(searchEntity.startsWith) && m.ModelName.StartsWith(searchEntity.startsWith))
                ) 
                //&& m.ManufacturerId == (manufacturerId != null ? manufacturerId.Value : m.ManufacturerId) 
                && m.DeletedOn == null)
            .Skip((searchEntity.pageNumber - 1) * searchEntity.pageSize)
            .Take(searchEntity.pageSize)
            .ToListAsync();

        var searchResponse = new List<KeyValuePair<Guid,  GearModel>>();
        searchResult.ForEach(f => searchResponse.Add(KeyValuePair.Create(Guid.NewGuid(), f)));

        return searchResponse;

    }

    public async Task<List<KeyValuePair<Guid, GearModel>>> GetByManufacturerAndType(int manufacturerId
        , int gearTypeId)
    {
        var searchResult = await _dbContext.Procedures.sp_GearModelsByManufacturerAndTypeAsync(manufacturerId, gearTypeId);

        var searchResponse = new List<KeyValuePair<Guid, GearModel>>();
        searchResult.ForEach(f => searchResponse.Add(KeyValuePair.Create(Guid.NewGuid(),
            new GearModel()
            {
                Active = f.Active,
                GearModelId = f.GearModelId,
                ModelName = f.ModelName,
                StartingDate = f.StartingDate,
                EndingDate = f.EndingDate
            })));

        return searchResponse;
    }

    public async Task<GearModel?> Add(
        GearModel GearModel,
        int userId)
    {
        if (!_dbContext.GearModel.Any(a => a.ModelName == GearModel.ModelName && a.ManufacturerId == GearModel.ManufacturerId))
        {
            GearModel.CreatedBy = userId.ToString();
            GearModel.CreatedOn = DateTime.UtcNow;

            _dbContext.GearModel.Add(GearModel);
            await _dbContext.SaveChangesAsync();

            return GearModel;
        }
        return null;
    }

    public async Task<GearModel?> Update(
        GearModel GearModel,
        int userId)
    {
        var currentModel = await _dbContext
            .GearModel
            .SingleOrDefaultAsync(s => s.GearModelId == GearModel.GearModelId);

        if (currentModel == null) return null;

        if (!_dbContext.GearModel.Any(a => a.ModelName == currentModel.ModelName && a.ManufacturerId == currentModel.ManufacturerId))
        {
            currentModel.ModelName = GearModel.ModelName;
            currentModel.Active = GearModel.Active;
            currentModel.StartingDate = GearModel.StartingDate;
            currentModel.EndingDate = GearModel.EndingDate;
            currentModel.ModifiedBy = userId.ToString();
            currentModel.ModifiedOn = DateTime.UtcNow;

            _dbContext.GearModel.Update(currentModel);
            await _dbContext.SaveChangesAsync();

            return currentModel;
        }

        return null;
    }

    public async Task<bool> Delete(
        int GearModelId,
        int userId)
    {
        var currentModel = await _dbContext
            .GearModel
            .SingleOrDefaultAsync(s => s.GearModelId == GearModelId);

        if (currentModel == null) return false;

        currentModel.Active = false;
        currentModel.DeletedBy = userId.ToString();
        currentModel.DeletedOn = DateTime.UtcNow;

        _dbContext.GearModel.Update(currentModel);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
