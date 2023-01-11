namespace FactoryMethod;

public interface IDocumentStorage
{
    void Save(Document document);
}

public abstract class DocumentManager
{
    public abstract IDocumentStorage CreateStorage();

    public void Save(Document document)
    {
        IDocumentStorage storage = this.CreateStorage();
        storage.Save(document);
    }
}

public class TxtDocumentManager : DocumentManager
{
    private class TxtDocumentStorage : IDocumentStorage
    {
        public void Save(Document document)
        {
            Console.WriteLine("TxtDocumentManager.Save()");
        }
    }

    public override IDocumentStorage CreateStorage()
    {
        return new TxtDocumentStorage();
    }
}

public class DocxDocumentManager : DocumentManager
{
    private class DocxDocumentStorage : IDocumentStorage
    {
        public void Save(Document document)
        {
            Console.WriteLine("DocxDocumentManager.Save()");
        }
    }

    public override IDocumentStorage CreateStorage()
    {
        return new DocxDocumentStorage();
    }
}

public class Document { }

