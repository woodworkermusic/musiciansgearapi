using Microsoft.AspNetCore.Mvc;
using MusiciansGearRegistry.Api.Core.Entities;
using MusiciansGearRegistry.Api.Logging.interfaces;

namespace MusiciansGearRegistry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected ILoggingService log { get; set; }

        public ApiControllerBase(ILoggingService log, 
            string logName)
        {
            this.log = log.GetLoggingService(logName);
        }

        /// <summary>
        /// All api calls will go through this function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="svcFunction"></param>
        /// <param name="successStatus"></param>
        /// <param name="failureStatus"></param>
        /// <returns></returns>
        protected Task<IActionResult> ProcessSvcRequest<T>(Func<MGR_SvcResponse<T>> svcFunction,
            StatusCodeResult successStatus,
            StatusCodeResult failureStatus) where T : class
        {
            MGR_SvcResponse<T> svcResponse = svcFunction();
            return null;

            //if (svcResponse.success)
            //{
            //    return Request.CreateResponse(successStatus, svcResponse.responseContent);
            //}
            //else
            //{
            //    return Request.CreateResponse(failureStatus, svcResponse.message);
            //}
        }

    }
}
