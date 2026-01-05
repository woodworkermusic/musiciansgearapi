using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.entities;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class SearchService : ServiceBase, ISearchService
{
    private ISearchRepository _searchRepo;

    public SearchService(ISearchRepository searchRepo
        , ILoggingService logSvc
        , ILogger<SearchService> log
        , TelemetryClient telemetryClient
        )
        : base(logSvc, log, telemetryClient)
    {
        _searchRepo = searchRepo;
    }

    public async Task<List<GearModel>> ByManufacturer(CommonSearchEntity searchEntity)
    {
        return await _searchRepo.ByManufacturer(searchEntity);
    }

    public async Task<List<GearModel>> ByGearType(CommonSearchEntity searchEntity)
    {
        return await _searchRepo.ByGearType(searchEntity);
    }

    public async Task<List<GearModel>> ByModel(CommonSearchEntity searchEntity)
    {
        return await _searchRepo.ByModel(searchEntity);
    }
}
