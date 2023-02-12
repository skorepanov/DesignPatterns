using Facade;

var facade = new ReportGeneratorFacade();

facade.GenerateReport(ReportType.Docx, data: new object(), location: @"C:\1.docx");
facade.GenerateReport(ReportType.Pdf, data: new object(), location: @"C:\2.pdf");
