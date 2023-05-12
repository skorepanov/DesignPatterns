using TemplateMethod;

var simpleReport = new SimpleReport("simpleReport.txt");
simpleReport.CreateReport();

Console.WriteLine();

var reportWithSignature = new ReportWithSignature("reportWithSignature.txt");
reportWithSignature.CreateReport();
