namespace FactoryMethod;

#region Importers (Products)
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
        Console.WriteLine($"Import from JSON file: {_fileName}");
    }
}

public class XmlImporter : Importer
{
    public XmlImporter(string fileName) : base(fileName) { }

    public override void Import()
    {
        Console.WriteLine($"Import from XML file: {_fileName}");
    }
}
#endregion

#region Static Factory
public static class ImporterStaticFactory
{
    private static readonly Dictionary<string, Func<string, Importer>> _importers = new();

    static ImporterStaticFactory()
    {
        _importers[".json"] = (fileName) => new JsonImporter(fileName);
        _importers[".xml"] = (fileName) => new XmlImporter(fileName);
    }

    public static Importer Create(string fileName)
    {
        var extension = Path.GetExtension(fileName);
        _importers.TryGetValue(extension, out var creator);

        if (creator is null)
        {
            throw new Exception(extension);
        }

        return creator(fileName);
    }
}
#endregion
