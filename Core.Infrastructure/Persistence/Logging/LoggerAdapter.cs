using Core.Application.Common.Logging;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Persistence.Logging;

public class LoggerAdapter<T> : Application.Common.Logging.ILogger<T>
{
    private readonly Microsoft.Extensions.Logging.ILogger<T> _logger;
    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }
    public void LogInformation(string message, params object[] args)
    {
        throw new NotImplementedException();
    }

    public void LogWarning(string message, params object[] args)
    {
        throw new NotImplementedException();
    }
}
