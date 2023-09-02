namespace AbstractFactory;

#region Products
public abstract class Connection { }

public class PostgresqlConnection : Connection { }

public class MsSqlConnection : Connection { }


public abstract class Command { }

public class PostgresqlCommand : Command { }

public class MsSqlCommand : Command { }
#endregion

#region Abstract Factory
public abstract class DbProviderAbstractFactory
{
    public abstract Connection CreateConnection();
    public abstract Command CreateCommand();
}

public class PostgresqlFactory : DbProviderAbstractFactory
{
    public override Connection CreateConnection()
    {
        return new PostgresqlConnection();
    }

    public override Command CreateCommand()
    {
        return new PostgresqlCommand();
    }
}

public class MsSqlFactory : DbProviderAbstractFactory
{
    public override Connection CreateConnection()
    {
        return new MsSqlConnection();
    }

    public override Command CreateCommand()
    {
        return new MsSqlCommand();
    }
}
#endregion

#region Log Saver
public class LogEntry { }

public class LogSaver
{
    private readonly DbProviderAbstractFactory _factory;

    public LogSaver(DbProviderAbstractFactory factory)
    {
        _factory = factory;
    }

    public void Save(IEnumerable<LogEntry> logEntries)
    {
        var connection = _factory.CreateConnection();
        var command = _factory.CreateCommand();
        Console.WriteLine($"Connection: {connection.GetType().Name}, command: {command.GetType().Name}");
    }
}
#endregion