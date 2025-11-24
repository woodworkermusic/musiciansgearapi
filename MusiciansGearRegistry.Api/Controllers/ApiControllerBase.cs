using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Logging.Services;

namespace MusiciansGearRegistry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MusiciansGearRegistryApi")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly ILoggingService _log;
        private readonly ILogger _logger;
        private readonly TelemetryClient _telemetryClient;

        public ApiControllerBase(ILogger logger
            , TelemetryClient telemetryClient)
        {
            var loggerFactory = new NLogLogger();
            this._log = loggerFactory.GetLoggingService("api");

            this._logger = logger;
            this._telemetryClient = telemetryClient;
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
                throw;
                //_log.Error(ex.ToString());
                //_logger.LogError(ex.ToString());
                //_telemetryClient.TrackEvent("ServiceRequest");

                //return BadRequest(ex.ToString());
            }
        }
    }
}
