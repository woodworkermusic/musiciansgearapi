using MusiciansGearRegistry.Api.Core.dto;
using MusiciansGearRegistry.Api.Core.Entities;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using MusiciansGearRegistry.Api.Logging.interfaces;

namespace MusiciansGearRegistry.Api.Core.services;

public class EquipmentManufacturerService : ServiceBase, IEquipmentManufacturerService
{
    private readonly IEquipmentManufacturerRepository _equipmentMfrRepo;

    public EquipmentManufacturerService(IEquipmentManufacturerRepository equipmentManufacturerRepository
        , ILoggingService logSvc) : base(logSvc, "EquipmentManufacturerService")
    {
        _equipmentMfrRepo = equipmentManufacturerRepository;
    }

    public Task<EquipmentManufacturerDto> Add(EquipmentManufacturer dtoManufacturer, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int manufacturerId, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentManufacturerDto> Get(int manufacturerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<EquipmentManufacturerDto>> GetMany(CommonSearchEntity manufacturerSearch)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentManufacturerDto> Update(EquipmentManufacturer dtoManufacturer, int userId)
    {
        throw new NotImplementedException();
    }
}
