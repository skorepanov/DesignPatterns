using Command;

var receiver = new WindowsFileSystemReceiver();
//var receiver = new LinuxFileSystemReceiver();
var openFileCommand = new OpenFileCommand(receiver);
var writeFileCommand = new WriteFileCommand(receiver);
var closeFileCommand = new CloseFileCommand(receiver);

var invoker = new FileInvoker(openFileCommand, writeFileCommand, closeFileCommand);
invoker.PressOpenFile();
invoker.PressWriteFile();
invoker.PressCloseFile();
