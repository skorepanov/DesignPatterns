using Microsoft.Data.SqlClient;
using Npgsql;
using System.Data.Common;
using AbstractFactory;

List<LogEntry> logEntries = new List<LogEntry>();

DbProviderFactory sqlFactory = SqlClientFactory.Instance;
LogSaver sqlLogSaver = new LogSaver(sqlFactory);
sqlLogSaver.Save(logEntries);

DbProviderFactory npgsqlFactory = NpgsqlFactory.Instance;
LogSaver npgsqlLogSaver = new LogSaver(npgsqlFactory);
npgsqlLogSaver.Save(logEntries);