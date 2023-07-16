using Memento_Simple;
//using Memento_NestedClass;
//using Memento_Serialization;

var document = new Document();
var history = new EditorHistory(document);

history.ChangeState(style: 2, text: "Hello, world!");
document.Print();
Console.WriteLine();

history.ChangeState(style: 3, text: "Goodbye, world!");
document.Print();
Console.WriteLine();

history.ChangeState(style: 4, text: "World!");
document.Print();
Console.WriteLine();

history.Undo(); // 4 -> 3
document.Print();
Console.WriteLine();

history.Undo(); // 3 -> 2
document.Print();
