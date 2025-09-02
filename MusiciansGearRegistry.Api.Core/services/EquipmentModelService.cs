using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.Services;

public class EquipmentModelService : IEquipmentModelService
{
    private readonly IEquipmentModelRepository _equipmentModelRepo;

    public EquipmentModelService(IEquipmentModelRepository equipmentModelRepository)
    {
        this._equipmentModelRepo = equipmentModelRepository;
    }

    public Task<EquipmentModel> EquipmentModel_Add(EquipmentModel equipmentModel, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EquipmentModel_Delete(int equipmentModelId, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentModel> EquipmentModel_Get(int equipmentModelId)
    {
        throw new NotImplementedException();
    }

    public Task<List<EquipmentModel>> EquipmentModel_GetMany(int? manufacturerId, int? modelTypeId, string startsWith, int pageNumber, int pageCount)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentModel> EquipmentModel_Update(EquipmentModel equipmentModel, int userId)
    {
        throw new NotImplementedException();
    }
}
