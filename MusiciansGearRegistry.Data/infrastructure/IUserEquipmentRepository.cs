using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface IUserEquipmentRepository
{
    Task<UserEquipment> Get(int userEquipmentId);
    Task<List<UserEquipment>> GetMany(int userProfileId);
    Task<UserEquipment> Add(UserEquipment newEquipment,
        int userId);

    Task<UserEquipment> Update(UserEquipment equipment
        , int userId);

    Task<bool> Delete(
        int userEquipmentId,
        int userId);
}
