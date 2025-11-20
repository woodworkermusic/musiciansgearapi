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
        protected ILoggingService log { get; set; }

        public ApiControllerBase(ILoggingService log, 
            string logName)
        {
            this.log = log.GetLoggingService(logName);
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

                return BadRequest(ex.ToString());
            }
        }
    }
}
