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

    public async Task<GearModel> Get(int GearModelId)
    {
        return await _dbContext.GearModel
            .SingleAsync(x =>
                x.GearModelId == GearModelId &&
                x.DeletedOn == null);
    }

    /// <summary>
    /// The nullable manufacturerId value allows us to look up both by name and use manufacturer as a filter.
    /// </summary>
    /// <param name="manufacturerId"></param>
    /// <param name="startsWith"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageCount"></param>
    /// <returns></returns>
    public async Task<List<GearModel>> GetMany(CommonSearchEntity searchEntity)
    {
        return await _dbContext.GearModel
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
        var currentModel = _dbContext
            .GearModel
            .Single(s => s.GearModelId == GearModel.GearModelId);

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
            .SingleAsync(s => s.GearModelId == GearModelId);

        if (currentModel == null) return false;

        currentModel.Active = false;
        currentModel.DeletedBy = userId.ToString();
        currentModel.DeletedOn = DateTime.UtcNow;

        _dbContext.GearModel.Update(currentModel);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
