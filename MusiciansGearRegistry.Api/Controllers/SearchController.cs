using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Data.entities;

namespace MusiciansGearRegistry.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ApiControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService
        , ILogger<SearchController> logger
        , TelemetryClient telemetryClient)
        : base(logger, telemetryClient)
    {
        _searchService = searchService;
    }

    [HttpPost("Model/Manufacturer")]
    public async Task<IActionResult> ModelSearch_Manufacturer([FromBody] CommonSearchEntity searchEntity)
    {
        return await ProcessSvcRequest(_searchService.ByManufacturer(searchEntity));
    }

    [HttpPost("Model/GearType")]
    public async Task<IActionResult> ModelSearch_GearType([FromBody] CommonSearchEntity searchEntity)
    {
        return await ProcessSvcRequest(_searchService.ByGearType(searchEntity));
    }

    [HttpPost("Model/Model")]
    public async Task<IActionResult> ModelSearch_Model([FromBody] CommonSearchEntity searchEntity)
    {
        return await ProcessSvcRequest(_searchService.ByModel(searchEntity));
    }

}
