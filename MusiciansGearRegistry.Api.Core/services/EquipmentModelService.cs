using MusiciansGearRegistry.Api.Core.dto;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using MusiciansGearRegistry.Api.Logging.interfaces;

namespace MusiciansGearRegistry.Api.Core.Services;

public class EquipmentModelService : IEquipmentModelService
{
    private readonly IEquipmentModelRepository _equipmentModelRepo;

    public EquipmentModelService(IEquipmentModelRepository equipmentModelRepository)
    {
        this._equipmentModelRepo = equipmentModelRepository;
    }

    public Task<EquipmentModelDto> EquipmentModel_Add(EquipmentModel equipmentModelDto, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EquipmentModel_Delete(int equipmentModelId, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentModelDto> EquipmentModel_Get(int equipmentModelId)
    {
        throw new NotImplementedException();
    }

    public Task<List<EquipmentModelDto>> EquipmentModel_GetMany(int? manufacturerId, int? modelTypeId, string startsWith, int pageNumber, int pageCount)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentModelDto> EquipmentModel_Update(EquipmentModel equipmentModelDto, int userId)
    {
        throw new NotImplementedException();
    }
}
