using MusiciansGearRegistry.Api.Core.dto;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.services;

public class UserEquipmentService : ServiceBase, IUserEquipmentService
{
    private readonly IUserEquipmentRepository _userEquipmentRepo;

    public UserEquipmentService(IUserEquipmentRepository userEquipmentRepo
        , ILoggingService logSvc)
        :base(logSvc, "UserGearService")
    {
        _userEquipmentRepo = userEquipmentRepo;
    }

    public async Task<UserEquipmentDto> Get(int userEquipmentId)
    {
        await _userEquipmentRepo.Get(userEquipmentId);
        return null;
    }

    public async Task<List<UserEquipmentDto>> GetMany(int userProfileId)
    {
        await _userEquipmentRepo.GetMany(userProfileId);
        return null;
    }

    public async Task<UserEquipmentDto> Add(UserEquipment newEquipment
        , int userId)
    {
        await _userEquipmentRepo.Add(newEquipment, userId);
        return null;
    }

    public async Task<UserEquipmentDto> Update(UserEquipment equipment
        , int userId)
    {
        await _userEquipmentRepo.Update(equipment, userId);
        return null;
    }

    public async Task<bool> Delete(
        int userEquipmentId,
        int userId)
    {
        return await _userEquipmentRepo.Delete(userEquipmentId, userId);
    }
}
