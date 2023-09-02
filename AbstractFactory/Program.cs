using AbstractFactory;

var logEntries = new List<LogEntry>();

var postgresqlFactory = new PostgresqlFactory();
var postgresqlLogSaver = new LogSaver(postgresqlFactory);
postgresqlLogSaver.Save(logEntries);

Console.WriteLine();

var msSqlFactory = new MsSqlFactory();
var msSqlLogSaver = new LogSaver(msSqlFactory);
msSqlLogSaver.Save(logEntries);
