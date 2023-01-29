using Adapter;

IAsyncLogSaver adapter = new SqlServerAsyncLogSaverAdapter();

var simpleLogEntry = new SimpleLogEntry
{
    EntryDateTime = DateTime.Now,
    Message = "Log message",
    Severity = 1,
};
await adapter.SaveAsync(simpleLogEntry);

var exceptionLogEntry = new ExceptionLogEntry
{
    EntryDateTime = DateTime.Now,
    Exception = new Exception("Test exception"),
    Message = "Exception message",
};
await adapter.SaveAsync(exceptionLogEntry);
