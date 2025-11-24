using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Logging.Services;

namespace MusiciansGearRegistry.Api.Core.services;

public abstract class ServiceBase
{
    protected readonly ILoggingService _log;
    protected readonly ILogger _logger;
    protected readonly TelemetryClient _telemetryClient;

    public ServiceBase(ILoggingService logSvc
        , ILogger logger
        , TelemetryClient telemetryClient
        )
    {
        this._logger = logger;
        this._telemetryClient = telemetryClient;

        var loggerFactory = new NLogLogger();
        this._log = loggerFactory.GetLoggingService("ServiceLog");
    }

    protected async Task<T> ProcessRepoRequest<T>(Task<T> svcFunction)
    {
        try
        {
            var cancelToken = new CancellationToken();
            var svcResult = default(T);

            await svcFunction.WaitAsync(cancelToken);
            svcResult = svcFunction.Result;

            return svcResult;
        }
        catch (Exception ex)
        {
            _log.Error(ex.ToString());
            //_logger.LogError(ex.ToString());
            //_telemetryClient.TrackEvent("ServiceRequest");

            throw;
        }
    }

}
