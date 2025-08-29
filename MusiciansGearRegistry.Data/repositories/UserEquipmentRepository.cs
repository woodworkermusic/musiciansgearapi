using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public class UserEquipmentRepository : RepositoryBase, IUserEquipmentRepository
{
    public UserEquipmentRepository(MusiciansGearRegistryContext dbContext) : base(dbContext) { }

    public Task<UserEquipment> Add(UserEquipment newEquipment, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(int userEquipmentId, int userId)
    {
        var userEquipment = await  _dbContext
            .UserEquipment
            .SingleAsync(s => s.UserEquipmentId == userEquipmentId);

        if (userEquipment == null) return false;

        userEquipment.DeletedOn = DateTime.UtcNow;
        userEquipment.DeletedBy = userId.ToString();

        _dbContext.UserEquipment.Update(userEquipment);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public Task<UserEquipment> Get(int userEquipmentId)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserEquipment>> GetMany(int userProfileId)
    {
        throw new NotImplementedException();
    }

    public Task<UserEquipment> Update(UserEquipment equipment, int userId)
    {
        throw new NotImplementedException();
    }
}
