using Adapter;

IAsyncLogSaver sqlServerAdapter = new SqlServerAsyncLogSaverAdapter();
IAsyncLogSaver postgresqlLogSaver = new PostgresqlLogSaver();

var simpleLogEntry = new SimpleLogEntry
{
    EntryDateTime = DateTime.Now,
    Message = "Log message",
    Severity = 1,
};
await sqlServerAdapter.SaveAsync(simpleLogEntry);
await postgresqlLogSaver.SaveAsync(simpleLogEntry);

var exceptionLogEntry = new ExceptionLogEntry
{
    EntryDateTime = DateTime.Now,
    Exception = new Exception("Test exception"),
    Message = "Exception message",
};
await sqlServerAdapter.SaveAsync(exceptionLogEntry);
await postgresqlLogSaver.SaveAsync(exceptionLogEntry);
