namespace FactoryMethod;

public abstract class Importer
{
    protected string _fileName;

    protected Importer(string fileName)
    {
        this._fileName = fileName;
    }

    public abstract void Import();
}

public class JsonImporter : Importer
{
    public JsonImporter(string fileName) : base(fileName) { }

    public override void Import()
    {
        Console.WriteLine($"JsonImporter.Import(): {_fileName}");
    }
}

public class XmlImporter : Importer
{
    public XmlImporter(string fileName) : base(fileName) { }

    public override void Import()
    {
        Console.WriteLine($"XmlImporter.Import(): {_fileName}");
    }
}