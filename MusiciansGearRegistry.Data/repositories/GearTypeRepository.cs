using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MusiciansGearRegistry.Data.repositories;

public class GearTypeRepository : RepositoryBase, IGearTypeRepository
{
    public GearTypeRepository(MusiciansGearRegistryContext dbContext) : base(dbContext)
    {
    }

    public async Task<GearType> Get(int GearTypeId)
    {
        return await _dbContext.GearType
            .SingleAsync(x =>
                x.GearTypeId == GearTypeId &&
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
    public async Task<List<KeyValuePair<Guid,  GearType>>> GetMany(CommonSearchEntity GearTypeSearch)
    {
        string startsWith = (!string.IsNullOrWhiteSpace(GearTypeSearch.startsWith) ? GearTypeSearch.startsWith.Trim() : string.Empty);

        var searchResult = await _dbContext.GearType
            .Where(m =>
                (
                (startsWith == string.Empty) || m.GearTypeName.StartsWith(startsWith)
                ) &&
                m.DeletedOn == null)
            .Skip((GearTypeSearch.pageNumber - 1) * GearTypeSearch.pageSize)
            .Take(GearTypeSearch.pageSize)
            .OrderBy(ob => ob.GearTypeName)
            .ToListAsync();

        var searchResponse = new List<KeyValuePair<Guid,  GearType>>();
        searchResult.ForEach(f => searchResponse.Add(KeyValuePair.Create(Guid.NewGuid(), f)));

        return searchResponse;
    }

    public async Task<GearType?> Add(
        GearType GearType,
        int userId)
    {
        if (_dbContext.GearType.Any(a => a.GearTypeName == GearType.GearTypeName && a.ManufacturerId == GearType.ManufacturerId))
            return null;

        GearType.CreatedBy = userId.ToString();
        GearType.CreatedOn = DateTime.UtcNow;

        _dbContext.GearType.Add(GearType);
        await _dbContext.SaveChangesAsync();

        return GearType;
    }

    public async Task<GearType?> Update(
        GearType GearType,
        int userId)
    {
        if (!_dbContext.GearType.Any(a => a.GearTypeName == GearType.GearTypeName && a.ManufacturerId == GearType.ManufacturerId))
            return null;

        GearType.ModifiedBy = userId.ToString();
        GearType.ModifiedOn = DateTime.UtcNow;

        _dbContext.GearType.Update(GearType);
        await _dbContext.SaveChangesAsync();

        return GearType;
    }

    public async Task<bool> Delete(
        int GearTypeId,
        int userId)
    {
        var GearType = await _dbContext
            .GearType
            .SingleAsync(s => s.GearTypeId == GearTypeId);

        if (GearType == null) return false;

        GearType.DeletedBy = userId.ToString();
        GearType.DeletedOn = DateTime.UtcNow;

        _dbContext.Update(GearType);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
