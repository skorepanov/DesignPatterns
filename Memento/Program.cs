using Memento_Simple;

var document = new Document();
var history = new EditorHistory();

document.AddBlock("Hello, world!");
document.SetStyle(2);
document.Print();
var stateToSave = document.SaveState();
history.Push(stateToSave);

document.AddBlock("Goodbye, world!");
document.SetStyle(3);
document.Print();

var stateToRestore = history.Pop();
document.RestoreState(stateToRestore);
document.Print();
