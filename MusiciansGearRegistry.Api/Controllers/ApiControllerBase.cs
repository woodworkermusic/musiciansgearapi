using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Logging.interfaces;

namespace MusiciansGearRegistry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MusiciansGearRegistryApi")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly ILoggingService log;
        protected readonly ILogger _logger;
        protected readonly TelemetryClient _telemetryClient;

        public ApiControllerBase(ILoggingService log, 
            string logName,
            ILogger logger,
            TelemetryClient telemetry)
        {
            this.log = log.GetLoggingService(logName);
            this._logger = logger;
            this._telemetryClient = telemetry;
        }

        protected async Task<IActionResult> ProcessSvcRequest<T>(Task<T> svcFunction)
        {
            try
            {
                var cancelToken = new CancellationToken();
                var svcResult = default(T);

                await svcFunction.WaitAsync(cancelToken);
                svcResult = svcFunction.Result;

                return Ok(svcResult);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                _logger.LogError(ex.ToString());
                _telemetryClient.TrackEvent("ServiceRequest");

                return BadRequest(ex.ToString());
            }
        }
    }
}
