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
        , ILoggingService logSvc) : base(logSvc, "ManufacturerService")
    {
        _MfrRepo = ManufacturerRepository;
    }

    public async Task<Manufacturer> Add(dtoManufacturer newManufacturer, int userId)
    {
        return await _MfrRepo.Add(newManufacturer, userId);
    }

    public async Task<bool> Delete(int manufacturerId, int userId)
    {
        return await _MfrRepo.Delete(manufacturerId, userId);
    }

    public async Task<Manufacturer> Get(int manufacturerId)
    {
        return await _MfrRepo.Get(manufacturerId);
    }

    public async Task<List<Manufacturer>> GetMany(CommonSearchEntity manufacturerSearch)
    {
        return await _MfrRepo.GetMany(manufacturerSearch);
    }

    public async Task<Manufacturer> Update(dtoManufacturer manufacturer, int userId)
    {
        return await _MfrRepo.Update(manufacturer, userId);
    }
}
