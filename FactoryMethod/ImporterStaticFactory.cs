namespace FactoryMethod;

public static class ImporterStaticFactory
{
    private static readonly Dictionary<string, Func<string, Importer>> _map = new();

    static ImporterStaticFactory()
    {
        _map[".json"] = (fileName) => new JsonImporter(fileName);
        _map[".xml"] = (fileName) => new XmlImporter(fileName);
    }

    public static Importer Create(string fileName)
    {
        var extension = Path.GetExtension(fileName);
        _map.TryGetValue(extension, out var creator);

        if (creator is null)
        {
            throw new Exception(extension);
        }

        return creator(fileName);
    }
}