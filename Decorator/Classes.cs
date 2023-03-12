using System.Diagnostics;

namespace Decorator;

public class LogEntry
{
    public DateTime EntryDateTime { get; set; }
    public string Message { get; set; }
}

// component
public interface ILogSaver
{
    Task SaveLogEntry(string applicationId, LogEntry logEntry);
}

// concrete component
public sealed class PostgresqlLogSaver : ILogSaver
{
    public Task SaveLogEntry(string applicationId, LogEntry logEntry)
    {
        Console.WriteLine("PostgresqlLogSaver.SaveLogEntry()");

        // сохранить переданную запись в Postgresql
        return Task.FromResult<object>(result: null);
    }
}

// base decorator
public abstract class LogSaverDecorator : ILogSaver
{
    protected readonly ILogSaver _logSaver;

    protected LogSaverDecorator(ILogSaver logSaver)
    {
        this._logSaver = logSaver;
    }

    public abstract Task SaveLogEntry(string applicationId, LogEntry logEntry);
}

// concrete decorator 1
public class ThrottlingLogSaverDecorator : LogSaverDecorator
{
    public ThrottlingLogSaverDecorator(ILogSaver logSaver)
        : base(logSaver) { }

    public override async Task SaveLogEntry(string applicationId, LogEntry logEntry)
    {
        Console.WriteLine("ThrottlingLogSaverDecorator.SaveLogEntry()");

        if (IsQuotaReached(applicationId))
        {
            // лимит приложения исчерпан, сохранение невозможно
            throw new QuotaReachedException();
        }

        IncrementUsedQuota(applicationId);

        await _logSaver.SaveLogEntry(applicationId, logEntry);
    }

    private bool IsQuotaReached(string applicationId)
    {
        // проверить, израсходована ли квота приложения
        return false;
    }

    private void IncrementUsedQuota(string applicationId)
    {
        // увеличить число поступивших запросов
    }
}

public class QuotaReachedException : Exception { }

// concrete decorator 2
public class TraceLogSaverDecorator : LogSaverDecorator
{
    public TraceLogSaverDecorator(ILogSaver logSaver)
        : base(logSaver) { }

    public override async Task SaveLogEntry(string applicationId, LogEntry logEntry)
    {
        Console.WriteLine("TraceLogSaverDecorator.SaveLogEntry()");

        var stopwatch = Stopwatch.StartNew();

        try
        {
            await _logSaver.SaveLogEntry(applicationId, logEntry);
        }
        finally
        {
            Console.WriteLine($"Операция сохранения завершена за {stopwatch.ElapsedMilliseconds} мс.");
        }
    }
}