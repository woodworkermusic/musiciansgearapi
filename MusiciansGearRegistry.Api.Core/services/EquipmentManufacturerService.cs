using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class EquipmentManufacturerService : ServiceBase, IEquipmentManufacturerService
{
    private readonly IEquipmentManufacturerRepository _equipmentMfrRepo;

    public EquipmentManufacturerService(IEquipmentManufacturerRepository equipmentManufacturerRepository
        , ILoggingService logSvc) : base(logSvc, "EquipmentManufacturerService")
    {
        _equipmentMfrRepo = equipmentManufacturerRepository;
    }

    public async Task<EquipmentManufacturer> Add(EquipmentManufacturer newManufacturer, int userId)
    {
        return await _equipmentMfrRepo.Add(newManufacturer, userId);
    }

    public async Task<bool> Delete(int manufacturerId, int userId)
    {
        return await _equipmentMfrRepo.Delete(manufacturerId, userId);
    }

    public async Task<EquipmentManufacturer> Get(int manufacturerId)
    {
        return await _equipmentMfrRepo.Get(manufacturerId);
    }

    public async Task<List<EquipmentManufacturer>> GetMany(CommonSearchEntity manufacturerSearch)
    {
        return await _equipmentMfrRepo.GetMany(manufacturerSearch);
    }

    public async Task<EquipmentManufacturer> Update(EquipmentManufacturer manufacturer, int userId)
    {
        return await _equipmentMfrRepo.Update(manufacturer, userId);
    }
}
