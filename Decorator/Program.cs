using Decorator;

// использование одного декоратора
ILogSaver logSaver = new ThrottlingLogSaverDecorator(
    new PostgresqlLogSaver());

logSaver.SaveLogEntry(applicationId: "testApp", logEntry: new LogEntry());

Console.WriteLine();

// использование нескольких декораторов
logSaver = new ThrottlingLogSaverDecorator(
    new TraceLogSaverDecorator(
        new PostgresqlLogSaver()));

logSaver.SaveLogEntry(applicationId: "testApp", logEntry: new LogEntry());
