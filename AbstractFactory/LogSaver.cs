using System.Data.Common;

namespace AbstractFactory;

public class LogSaver
{
    private readonly DbProviderFactory _factory;

    public LogSaver(DbProviderFactory factory)
    {
        _factory = factory;
    }

    public void Save(IEnumerable<LogEntry> logEntries)
    {
        using var connection = _factory.CreateConnection();
        using var command = _factory.CreateCommand();
        SetCommandParameters(command, logEntries);
        command?.ExecuteNonQuery();
    }

    private void SetCommandParameters(DbCommand? command, IEnumerable<LogEntry> logEntries) { }
}

public class LogEntry { }