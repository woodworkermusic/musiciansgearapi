using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MusiciansGearRegistry.Data.repositories;

public class EquipmentTypeRepository : RepositoryBase, IEquipmentTypeRepository
{
    public EquipmentTypeRepository(MusiciansGearRegistryContext dbContext) : base(dbContext)
    {
    }

    public async Task<EquipmentType> Get(int EquipmentTypeId)
    {
        return await _dbContext.EquipmentType
            .SingleAsync(x =>
                x.EquipmentTypeId == EquipmentTypeId &&
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
    public async Task<List<EquipmentType>> GetMany(CommonSearchEntity equipmentTypeSearch)
    {
        string startsWith = (!string.IsNullOrWhiteSpace(equipmentTypeSearch.startsWith) ? equipmentTypeSearch.startsWith.Trim() : string.Empty);

        return await _dbContext.EquipmentType
            .Where(m =>
                (
                (startsWith == string.Empty) || m.EquipmentTypeName.StartsWith(startsWith)
                ) &&
                m.DeletedOn == null)
            .Skip((equipmentTypeSearch.pageNumber - 1) * equipmentTypeSearch.pageSize)
            .Take(equipmentTypeSearch.pageSize)
            .OrderBy(ob => ob.EquipmentTypeName)
            .ToListAsync();
    }

    public async Task<EquipmentType?> Add(
        EquipmentType equipmentType,
        int userId)
    {
        if (_dbContext.EquipmentType.Any(a => a.EquipmentTypeName == equipmentType.EquipmentTypeName && a.ManufacturerId == equipmentType.ManufacturerId))
            return null;

        equipmentType.CreatedBy = userId.ToString();
        equipmentType.CreatedOn = DateTime.UtcNow;

        _dbContext.EquipmentType.Add(equipmentType);
        await _dbContext.SaveChangesAsync();

        return equipmentType;
    }

    public async Task<EquipmentType?> Update(
        EquipmentType equipmentType,
        int userId)
    {
        if (!_dbContext.EquipmentType.Any(a => a.EquipmentTypeName == equipmentType.EquipmentTypeName && a.ManufacturerId == equipmentType.ManufacturerId))
            return null;

        equipmentType.ModifiedBy = userId.ToString();
        equipmentType.ModifiedOn = DateTime.UtcNow;

        _dbContext.EquipmentType.Update(equipmentType);
        await _dbContext.SaveChangesAsync();

        return equipmentType;
    }

    public async Task<bool> Delete(
        int equipmentTypeId,
        int userId)
    {
        var equipmentType = await _dbContext
            .EquipmentType
            .SingleAsync(s => s.EquipmentTypeId == equipmentTypeId);

        if (equipmentType == null) return false;

        equipmentType.DeletedBy = userId.ToString();
        equipmentType.DeletedOn = DateTime.UtcNow;

        _dbContext.Update(equipmentType);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
