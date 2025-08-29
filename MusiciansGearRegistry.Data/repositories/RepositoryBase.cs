using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Data.repositories;

public abstract class RepositoryBase
{
    protected readonly MusiciansGearRegistryContext _dbContext;

    protected RepositoryBase(MusiciansGearRegistryContext dbContext)
    {
        _dbContext = dbContext;
    }
}
