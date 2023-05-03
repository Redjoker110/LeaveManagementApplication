using Microsoft.Extensions.Logging;

namespace LeaveManagementApplication.Application.Services;

public interface ILoggingService<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarnings(string message, params object[] args);
}

public class LoggingService<T> : ILoggingService<T>
{
    private readonly ILogger<T> _logger;

    public LoggingService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }

    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogWarnings(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
    }
}