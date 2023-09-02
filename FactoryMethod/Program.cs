using FactoryMethod;

#region Factory Mehod
var documents = new Document[]
{
   new Resume(),
   new Report()
};

foreach (var document in documents)
{
   Console.WriteLine(document.GetType().Name);

   var pages = document.CreatePages();

   foreach (var page in pages)
   {
      Console.WriteLine($"-{page.GetType().Name}");
   }

   Console.WriteLine();
}
#endregion

Console.WriteLine("-------------------------------------------");

#region Static Factory
var jsonImporter = ImporterStaticFactory.Create(@"d:\temp\data.json");
jsonImporter.Import();

var xmlImporter = ImporterStaticFactory.Create(@"d:\temp\data.xml");
xmlImporter.Import();
#endregion
