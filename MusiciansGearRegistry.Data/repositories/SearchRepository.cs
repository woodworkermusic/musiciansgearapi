using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public class SearchRepository : RepositoryBase, ISearchRepository
{
    public SearchRepository(MusiciansGearRegistryContext dbContext) : base(dbContext) { }

    public async Task<List<GearModel>> ByManufacturer(CommonSearchEntity searchEntity)
    {
        var result = await _dbContext.GearModel
            .Where(w => w.Manufacturer.ManufacturerName.Contains(searchEntity.searchText) && w.DeletedOn == null)
            .Include(i => i.Manufacturer)
            .Include(i => i.GearType)
            .Skip((searchEntity.pageNumber - 1) * searchEntity.pageSize)
            .Take(searchEntity.pageSize)
            .ToListAsync();

        result.ForEach(f => f.GearType.GearModel.Clear());
        return result;
    }

    public async Task<List<GearModel>> ByGearType(CommonSearchEntity searchEntity)
    {
        var result = await _dbContext.GearModel
            .Where(w => w.GearType.GearTypeName.Contains(searchEntity.searchText) && w.DeletedOn == null)
            .Skip((searchEntity.pageNumber - 1) * searchEntity.pageSize)
            .Take(searchEntity.pageSize)
            .Include(i => i.Manufacturer)
            .Include(i => i.GearType)
            .ToListAsync();

        result.ForEach(f => f.GearType.GearModel.Clear());
        return result;
    }

    public async Task<List<GearModel>> ByModel(CommonSearchEntity searchEntity)
    {
        var result = await _dbContext.GearModel
            .Where(w => w.ModelName.Contains(searchEntity.searchText) && w.DeletedOn == null)
            .Include(i => i.Manufacturer)
            .Include(i => i.GearType)
            .Skip((searchEntity.pageNumber - 1) * searchEntity.pageSize)
            .Take(searchEntity.pageSize)
            .ToListAsync();

        result.ForEach(f => f.GearType.GearModel.Clear());
        return result;
    }
}
