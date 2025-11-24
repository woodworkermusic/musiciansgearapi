using Microsoft.ApplicationInsights;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using Microsoft.Extensions.Logging;

namespace MusiciansGearRegistry.Api.Core.services;

public class GearTypeService : ServiceBase, IGearTypeService
{
    private readonly IGearTypeRepository _GearTypeRepo;

    public GearTypeService(IGearTypeRepository GearTypeRepo
        , ILoggingService logSvc
        , ILogger<GearTypeService> log
        , TelemetryClient telemetryClient
        ) 
        : base(logSvc, log, telemetryClient)
    {

        _GearTypeRepo = GearTypeRepo;
    }

    public async Task<GearType> Add(dto_GearType GearType, int userId)
    {
        return await _GearTypeRepo.Add(GearType, userId);
    }

    public async Task<bool> Delete(int GearTypeId, int userId)
    {
        return await _GearTypeRepo.Delete(GearTypeId, userId);
    }

    public async Task<GearType> Get(int GearTypeId)
    {
        return await _GearTypeRepo.Get(GearTypeId);
    }

    public async Task<List<KeyValuePair<Guid,  GearType>>> Get()
    {
        return await _GearTypeRepo.Get();
    }

    public async Task<List<KeyValuePair<Guid, GearType>>> GetMany(CommonSearchEntity GearTypeSearch)
    {
        return await _GearTypeRepo.GetMany(GearTypeSearch);
    }

    public async Task<List<KeyValuePair<Guid, GearType>>> GetByManufacturer(int manufacturerId)
    {
        return await _GearTypeRepo.GetByManufacturerId(manufacturerId);
    }

    public async Task<GearType> Update(GearType GearType, int userId)
    {
        return await _GearTypeRepo.Update(GearType, userId);
    }
}
