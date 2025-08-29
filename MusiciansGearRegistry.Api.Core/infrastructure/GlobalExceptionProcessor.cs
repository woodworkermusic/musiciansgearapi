using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Logging.Services;
using NLog;
using System.Diagnostics;

namespace MusiciansGearRegistry.Api.Core.infrastructure;

public static class GlobalExceptionProcessor
{
    public static void ProcessException(
        ILoggingService log,
        StackTrace stackTrace,
        Exception sourceException)
    {
        if (log == null)
        {
            NLogLogger loggerService = new NLogLogger();
            log = loggerService.GetLoggingService("globalExceptionProcessor");
        }

        try
        {
            StackFrame stackFrame = stackTrace.GetFrame(0);

            log.Error(stackFrame.GetMethod().Name);
            log.Error(sourceException.Message);

            Exception logException = sourceException;

            while (logException.InnerException != null)
            {
                logException = logException.InnerException;
                log.Error(logException.Message);
            }
        }
        catch
        { }
    }

    public static void ProcessException_NonSvc(
        Logger log,
        StackTrace stackTrace,
        Exception sourceException)
    {
        if (log == null)
        {
            NLogLogger loggerService = new NLogLogger();
            log = NLog.LogManager.GetLogger("globalExceptionProcessor");
        }

        try
        {
            StackFrame stackFrame = stackTrace.GetFrame(0);

            log.Error(stackFrame.GetMethod().Name);
            log.Error(sourceException.Message);

            Exception logException = sourceException;

            while (logException.InnerException != null)
            {
                logException = logException.InnerException;
                log.Error(logException.Message);
            }
        }
        catch
        { }
    }
}