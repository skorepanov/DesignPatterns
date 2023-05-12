namespace TemplateMethod;

public abstract class ReportBase
{
    protected string FileName { get; }

    protected ReportBase(string fileName)
    {
        FileName = fileName;
    }

    public void CreateReport()
    {
        CreateFile();
        WriteReportContent();

        if (ShouldAddSignature())
        {
            AddSignature();
        }
    }

    private void CreateFile()
    {
        Console.WriteLine($"Создан файл {FileName}");
    }

    protected abstract void WriteReportContent();

    protected virtual bool ShouldAddSignature()
    {
        return false;
    }

    protected virtual void AddSignature() { }
}

public class SimpleReport : ReportBase
{
    public SimpleReport(string fileName) : base(fileName) { }

    protected override void WriteReportContent()
    {
        Console.WriteLine($"Записано содержимое простого документа (файл: {FileName})");
    }
}

public class ReportWithSignature : ReportBase
{
    public ReportWithSignature(string fileName) : base(fileName) { }

    protected override void WriteReportContent()
    {
        Console.WriteLine($"Записано содержимое документа с подписью (файл: {FileName})");
    }

    protected override bool ShouldAddSignature()
    {
        return true;
    }

    protected override void AddSignature()
    {
        Console.WriteLine($"Добавлена подпись для документа (файл: {FileName})");
    }
}
