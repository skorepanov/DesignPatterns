namespace Adapter;

#region Log entry
public abstract class LogEntry
{
    public DateTime EntryDateTime { get; set; }
    public string Message { get; set; }
}

public class SimpleLogEntry : LogEntry
{
    public int Severity { get; set; }
}

public class ExceptionLogEntry : LogEntry
{
    public Exception Exception { get; set; }
}
#endregion

#region Log saver
public interface IAsyncLogSaver
{
    Task SaveAsync(LogEntry logEntry);
}

// адаптер для класса с устаревшим интерфейсом
public class SqlServerAsyncLogSaverAdapter : IAsyncLogSaver
{
    private readonly SqlServerLogSaver _sqlServerLogSaver = new SqlServerLogSaver();

    public Task SaveAsync(LogEntry logEntry)
    {
        switch (logEntry)
        {
            case SimpleLogEntry simpleLogEntry:
                return Task.Run(() => _sqlServerLogSaver.SaveMessage(simpleLogEntry.EntryDateTime,
                    simpleLogEntry.Severity.ToString(), simpleLogEntry.Message));
            case ExceptionLogEntry exceptionEntry:
                return Task.Run(() => _sqlServerLogSaver.SaveException(exceptionEntry.EntryDateTime,
                    exceptionEntry.Message, exceptionEntry.Exception));
        }

        throw new ArgumentException();
    }
}

// класс у устаревшим интерфейсом
public class SqlServerLogSaver
{
    public void SaveMessage(DateTime dateTime, string severity, string message)
    {
        Console.WriteLine("Saving log entry to SQL Server: "
                       + $"dateTime: {dateTime}, "
                       + $"severity: {severity}, "
                       + $"message: {message}.");
    }

    public void SaveException(DateTime dateTime, string message, Exception exception)
    {
        Console.WriteLine("Saving exception log entry to SQL Server: "
                       + $"dateTime: {dateTime}, "
                       + $"message: {message}, "
                       + $"exception: {exception.Message}.");
    }
}

// класс с новым интерфейсом
public class PostgresqlLogSaver : IAsyncLogSaver
{
    public Task SaveAsync(LogEntry logEntry)
    {
        switch (logEntry)
        {
            case SimpleLogEntry simpleLogEntry:
                return Task.Run(() => SaveMessage(simpleLogEntry));
            case ExceptionLogEntry exceptionEntry:
                return Task.Run(() => SaveException(exceptionEntry));
        }

        throw new ArgumentException();
    }

    private void SaveMessage(SimpleLogEntry logEntry)
    {
        Console.WriteLine("Saving log entry to Postgresql: "
                       + $"dateTime: {logEntry.EntryDateTime}, "
                       + $"severity: {logEntry.Severity}, "
                       + $"message: {logEntry.Message}.");
    }

    private void SaveException(ExceptionLogEntry logEntry)
    {
        Console.WriteLine("Saving exception log entry to Postgresql: "
                       + $"dateTime: {logEntry.EntryDateTime}, "
                       + $"message: {logEntry.Message}, "
                       + $"exception: {logEntry.Exception.Message}.");
    }
}
#endregion
