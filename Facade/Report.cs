namespace Facade;

public class Report
{
    public ReportHeader Header { get; set; }
    public ReportData Data { get; set; }
    public ReportFooter Footer { get; set; }
}

public enum ReportType
{
    Docx,
    Pdf
}

public class ReportWriter
{
    public void WriteDocxReport(Report report, string location)
    {
        Console.WriteLine($"Writing DOCX report to {location}");
    }
    public void WritePdfReport(Report report, string location)
    {
        Console.WriteLine($"Writing PDF report to {location}");
    }
}

public class ReportHeader { }

public class ReportFooter { }

public class ReportData
{
    public ReportData(object data) { }
}