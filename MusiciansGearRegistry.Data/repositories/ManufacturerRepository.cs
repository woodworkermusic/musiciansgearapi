using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public class ManufacturerRepository : RepositoryBase, IManufacturerRepository
{
    public ManufacturerRepository(MusiciansGearRegistryContext dbContext) : base(dbContext)
    {
    }

    public async Task<Manufacturer> Get(int manufacturerId)
    {
        return await _dbContext.Manufacturer.SingleOrDefaultAsync(s => s.ManufacturerId == manufacturerId && s.DeletedOn == null);
    }

    public async Task<List<KeyValuePair<Guid, Manufacturer>>> GetMany(CommonSearchEntity search)
    {
        search.startsWith = search.startsWith.Trim();

        var searchResult = await _dbContext.Manufacturer
            .Where(m =>
                (
                    string.IsNullOrEmpty(search.startsWith) ||
                    m.ManufacturerName.StartsWith(search.startsWith)
                )
                &&
                (search.includeDeleted || (m.DeletedOn == null))
                )
            .OrderBy(ob => ob.ManufacturerName)
            .Skip((search.pageNumber - 1) * search.pageSize)
            .Take(search.pageSize)
            .ToListAsync();

        var searchResponse = new List<KeyValuePair<Guid, Manufacturer>>();
        searchResult.ForEach(f => searchResponse.Add(KeyValuePair.Create(Guid.NewGuid(), f)));

        return searchResponse;
    }

    public async Task<Manufacturer> Add(
        dto_Manufacturer dto,
        int userId)
    {
        if (!this.ManufacturerExists(0, dto.ManufacturerName))
        {
            var newManufacturer = new Manufacturer()
            {
                ManufacturerName = dto.ManufacturerName,
                Active = dto.Active,
                CreatedBy = userId.ToString(),
                CreatedOn = DateTime.UtcNow
            };

            await _dbContext.Manufacturer.AddAsync(newManufacturer);
            await _dbContext.SaveChangesAsync();

            return newManufacturer;
        }
        else
        {
            throw new Exception("This manufacturer name already exists.  Please enter a different name.");
        }
    }

    public async Task<Manufacturer> Update(
        dto_Manufacturer dto,
        int userId)
    {
        var currentManufacturer = await _dbContext
            .Manufacturer
            .SingleOrDefaultAsync(x =>
                x.ManufacturerId == dto.ManufacturerId &&
                x.DeletedOn == null);

        if (currentManufacturer == null)
            return null;

        if (!this.ManufacturerExists(dto.ManufacturerId, dto.ManufacturerName))
        {
            currentManufacturer.Active = dto.Active;
            currentManufacturer.ManufacturerName = dto.ManufacturerName;
            currentManufacturer.ModifiedBy = userId.ToString();
            currentManufacturer.ModifiedOn = DateTime.UtcNow;

            _dbContext.Manufacturer.Update(currentManufacturer);
            await _dbContext.SaveChangesAsync();
        }

        return currentManufacturer;
    }

    public async Task<bool> Delete(
        int manufacturerId,
        int userId)
    {
        var existingManufacturer = await _dbContext
            .Manufacturer
            .SingleOrDefaultAsync(x =>
                x.ManufacturerId == manufacturerId &&
                x.DeletedOn == null);

        if (existingManufacturer != null)
        {
            existingManufacturer.DeletedBy = userId.ToString();
            existingManufacturer.DeletedOn = DateTime.UtcNow;

            _dbContext.Manufacturer.Update(existingManufacturer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        return false;
    }

    private bool ManufacturerExists(int manufacturerId,
        string manufacturerName)
    {
        return _dbContext.Manufacturer
            .Any(m => m.ManufacturerName == manufacturerName &&
                m.ManufacturerId != manufacturerId);
    }
}
