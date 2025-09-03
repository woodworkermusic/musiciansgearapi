using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public class EquipmentModelRepository : RepositoryBase, IEquipmentModelRepository
{
    public EquipmentModelRepository(MusiciansGearRegistryContext dbContext) : base(dbContext)
    {
    }

    public async Task<EquipmentModel> Get(int equipmentModelId)
    {
        return await _dbContext.EquipmentModel
            .SingleAsync(x =>
                x.EquipmentModelId == equipmentModelId &&
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
    public async Task<List<EquipmentModel>> GetMany(CommonSearchEntity searchEntity)
    {
        return await _dbContext.EquipmentModel
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

    public async Task<EquipmentModel?> Add(
        EquipmentModel equipmentModel,
        int userId)
    {
        if (!_dbContext.EquipmentModel.Any(a => a.ModelName == equipmentModel.ModelName && a.ManufacturerId == equipmentModel.ManufacturerId))
        {
            equipmentModel.CreatedBy = userId.ToString();
            equipmentModel.CreatedOn = DateTime.UtcNow;

            _dbContext.EquipmentModel.Add(equipmentModel);
            await _dbContext.SaveChangesAsync();

            return equipmentModel;
        }
        return null;
    }

    public async Task<EquipmentModel?> Update(
        EquipmentModel equipmentModel,
        int userId)
    {
        var currentModel = _dbContext
            .EquipmentModel
            .Single(s => s.EquipmentModelId == equipmentModel.EquipmentModelId);

        if (currentModel == null) return null;

        if (!_dbContext.EquipmentModel.Any(a => a.ModelName == currentModel.ModelName && a.ManufacturerId == currentModel.ManufacturerId))
        {
            currentModel.ModelName = equipmentModel.ModelName;
            currentModel.Active = equipmentModel.Active;
            currentModel.StartingDate = equipmentModel.StartingDate;
            currentModel.EndingDate = equipmentModel.EndingDate;
            currentModel.ModifiedBy = userId.ToString();
            currentModel.ModifiedOn = DateTime.UtcNow;

            _dbContext.EquipmentModel.Update(currentModel);
            await _dbContext.SaveChangesAsync();

            return currentModel;
        }

        return null;
    }

    public async Task<bool> Delete(
        int equipmentModelId,
        int userId)
    {
        var currentModel = await _dbContext
            .EquipmentModel
            .SingleAsync(s => s.EquipmentModelId == equipmentModelId);

        if (currentModel == null) return false;

        currentModel.Active = false;
        currentModel.DeletedBy = userId.ToString();
        currentModel.DeletedOn = DateTime.UtcNow;

        _dbContext.EquipmentModel.Update(currentModel);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
