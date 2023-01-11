using FactoryMethod;

#region Factory Method
Document document1 = new Document();
DocumentManager documentManager1 = new TxtDocumentManager();
IDocumentStorage storage = documentManager1.CreateStorage();
storage.Save(document1);

Document document2 = new Document();
DocumentManager documentManager2 = new DocxDocumentManager();
documentManager2.Save(document2);
#endregion

Console.WriteLine("------------------------");

#region Static Factory
var jsonImporter = ImporterStaticFactory.Create(@"d:\temp\data.json");
jsonImporter.Import();

var xmlImporter = ImporterStaticFactory.Create(@"d:\temp\data.xml");
xmlImporter.Import();
#endregion
