using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class UserGearService : ServiceBase, IUserGearService
{
    private readonly IUserGearRepository _userGearRepo;

    public UserGearService(IUserGearRepository userGearRepo
        , ILoggingService logSvc
        , ILogger<UserGearService> log
        , TelemetryClient telemetryClient
        ) 
        : base(logSvc, log, telemetryClient)
    {
        _userGearRepo = userGearRepo;
    }

    public async Task<UserGear> Get(int userGearId)
    {
        await _userGearRepo.Get(userGearId);
        return null;
    }

    public async Task<List<UserGear>> GetMany(int userProfileId)
    {
        await _userGearRepo.GetMany(userProfileId);
        return null;
    }

    public async Task<UserGear> Add(UserGear newGear
        , int userId)
    {
        await _userGearRepo.Add(newGear, userId);
        return null;
    }

    public async Task<UserGear> Update(UserGear Gear
        , int userId)
    {
        await _userGearRepo.Update(Gear, userId);
        return null;
    }

    public async Task<bool> Delete(
        int userGearId,
        int userId)
    {
        return await _userGearRepo.Delete(userGearId, userId);
    }
}
