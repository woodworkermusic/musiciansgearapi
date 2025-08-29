using MusiciansGearRegistry.Api.Logging.interfaces;

namespace MusiciansGearRegistry.Api.Core.services;

public abstract class ServiceBase
{
    protected readonly ILoggingService _logSvc;

    public ServiceBase(ILoggingService logSvc
        ,string logSvcId)
    {
        _logSvc = logSvc;
    }

}
