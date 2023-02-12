namespace Facade;

public class ReportGeneratorFacade
{
    public void GenerateReport(ReportType type, object data, string location)
    {
        var report = new Report();
        report.Header = new ReportHeader();
        report.Data = new ReportData(data);
        report.Footer = new ReportFooter();

        var writer = new ReportWriter();

        switch (type)
        {
            case ReportType.Docx:
                writer.WriteDocxReport(report, location);
                break;
            case ReportType.Pdf:
                writer.WritePdfReport(report, location);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, message: null);
        }
    }
}
