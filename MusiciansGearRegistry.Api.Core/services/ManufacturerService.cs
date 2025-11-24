using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.dto;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class ManufacturerService : ServiceBase, IManufacturerService
{
    private readonly IManufacturerRepository _MfrRepo;

    public ManufacturerService(IManufacturerRepository ManufacturerRepository
        , ILoggingService logSvc
        , ILogger<ManufacturerService> log
        , TelemetryClient telemetryClient
        ) 
        : base(logSvc, log, telemetryClient)
    {
        _MfrRepo = ManufacturerRepository;
    }

    public async Task<Manufacturer> Add(dto_Manufacturer newManufacturer, int userId)
    {
        return await ProcessRepoRequest<Manufacturer>(_MfrRepo.Add(newManufacturer, userId));
    }

    public async Task<bool> Delete(int manufacturerId, int userId)
    {
        return await _MfrRepo.Delete(manufacturerId, userId);
    }

    public async Task<Manufacturer> Get(int manufacturerId)
    {
        return await _MfrRepo.Get(manufacturerId);
    }

    public async Task<List<KeyValuePair<Guid, Manufacturer>>> GetMany(CommonSearchEntity manufacturerSearch)
    {
        var response = await _MfrRepo.GetMany(manufacturerSearch);
        return response;
    }

    public async Task<Manufacturer> Update(dto_Manufacturer manufacturer, int userId)
    {
        return await _MfrRepo.Update(manufacturer, userId);
    }
}
