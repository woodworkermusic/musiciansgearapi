using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MusiciansGearRegistry.Data.repositories;

public class EquipmentManufacturerRepository : RepositoryBase, IEquipmentManufacturerRepository
{
    public EquipmentManufacturerRepository(MusiciansGearRegistryContext dbContext) : base(dbContext)
    {
    }

    public async Task<EquipmentManufacturer> Get(int manufacturerId)
    {
        return await _dbContext.EquipmentManufacturer.SingleAsync(s => s.ManufacturerId == manufacturerId && s.DeletedOn != null);
    }

    public async Task<List<EquipmentManufacturer>> GetMany(CommonSearchEntity manufacturerSearch)
    {
        manufacturerSearch.startsWith = manufacturerSearch.startsWith.Trim();

        if (string.IsNullOrEmpty(manufacturerSearch.startsWith))
            return new List<EquipmentManufacturer>();

        return await _dbContext.EquipmentManufacturer
            .Where(m =>
                m.ManufacturerName.StartsWith(manufacturerSearch.startsWith)
                && m.DeletedOn == null
                )
            .OrderBy(ob => ob.ManufacturerName)
            .Skip((manufacturerSearch.pageNumber - 1) * manufacturerSearch.pageSize)
            .Take(manufacturerSearch.pageSize)
            .ToListAsync();
    }

    public async Task<EquipmentManufacturer> Add(
        EquipmentManufacturer newManufacturer,
        int userId)
    {
        if (!this.ManufacturerExists(0, newManufacturer.ManufacturerName))
        {
            newManufacturer.CreatedBy = userId.ToString();
            newManufacturer.CreatedOn = DateTime.UtcNow;
            _dbContext.EquipmentManufacturer.Add(newManufacturer);
            await _dbContext.SaveChangesAsync();

            return newManufacturer;
        }
        else
        {
            throw new Exception("This manufacturer name already exists.  Please enter a different name.");
        }
    }

    public async Task<EquipmentManufacturer> Update(
        EquipmentManufacturer manufacturer,
        int userId)
    {
        var currentManufacturer = await _dbContext
            .EquipmentManufacturer
            .SingleAsync(x =>
                x.ManufacturerId == manufacturer.ManufacturerId &&
                x.DeletedOn == null);

        if (currentManufacturer == null)
            return null;

        if (!this.ManufacturerExists(manufacturer.ManufacturerId, manufacturer.ManufacturerName))
        {
            currentManufacturer.Active = manufacturer.Active;
            currentManufacturer.ManufacturerName = manufacturer.ManufacturerName;
            currentManufacturer.ModifiedBy = userId.ToString();
            currentManufacturer.ModifiedOn = DateTime.UtcNow;

            _dbContext.EquipmentManufacturer.Update(currentManufacturer);
            await _dbContext.SaveChangesAsync();
        }

        return manufacturer;
    }

    public async Task<bool> Delete(
        int manufacturerId,
        int userId)
    {
        var existingManufacturer = await _dbContext
            .EquipmentManufacturer
            .SingleAsync(x =>
                x.ManufacturerId == manufacturerId &&
                x.DeletedOn == null);

        if (existingManufacturer != null)
        {
            existingManufacturer.DeletedBy = userId.ToString();
            existingManufacturer.DeletedOn = DateTime.UtcNow;

            _dbContext.EquipmentManufacturer.Update(existingManufacturer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        return false;
    }

    private bool ManufacturerExists(int manufacturerId,
        string manufacturerName)
    {
        return _dbContext.EquipmentManufacturer
            .Any(m => m.ManufacturerName == manufacturerName &&
                m.ManufacturerId != manufacturerId);
    }
}
