using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public class UserGearRepository : RepositoryBase, IUserGearRepository
{
    public UserGearRepository(MusiciansGearRegistryContext dbContext) : base(dbContext) { }

    public Task<UserGear> Add(UserGear newGear, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(int userGearId, int userId)
    {
        var userGear = await  _dbContext
            .UserGear
            .SingleAsync(s => s.UserGearId == userGearId);

        if (userGear == null) return false;

        userGear.DeletedOn = DateTime.UtcNow;
        userGear.DeletedBy = userId.ToString();

        _dbContext.UserGear.Update(userGear);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public Task<UserGear> Get(int userGearId)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserGear>> GetMany(int userProfileId)
    {
        throw new NotImplementedException();
    }

    public Task<UserGear> Update(UserGear Gear, int userId)
    {
        throw new NotImplementedException();
    }
}
