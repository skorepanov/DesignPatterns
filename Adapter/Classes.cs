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

public class SqlServerAsyncLogSaverAdapter : IAsyncLogSaver
{
    private readonly SqlServerLogSaver _sqlServerLogSaver = new SqlServerLogSaver();

    public Task SaveAsync(LogEntry logEntry)
    {
        switch (logEntry)
        {
            case SimpleLogEntry simpleLogEntry:
                return Task.Run(() => _sqlServerLogSaver.Save(simpleLogEntry.EntryDateTime,
                    simpleLogEntry.Severity.ToString(), simpleLogEntry.Message));
            case ExceptionLogEntry exceptionEntry:
                return Task.Run(() => _sqlServerLogSaver.SaveException(exceptionEntry.EntryDateTime,
                    exceptionEntry.Message, exceptionEntry.Exception));
        }

        throw new ArgumentException();
    }
}

public class SqlServerLogSaver
{
    public void Save(DateTime dateTime, string severity, string message)
    {
        Console.WriteLine($"Saving log entry: dateTime: {dateTime}, severity: {severity}, message: {message}.");
    }

    public void SaveException(DateTime dateTime, string message, Exception exception)
    {
        Console.WriteLine($"Saving exception log entry: dateTime: {dateTime}, message: {message}, exception: {exception.Message}.");
    }
}
#endregion
