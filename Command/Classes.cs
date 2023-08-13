namespace Command;

#region Command (Команда)
public interface ICommand
{
    void Execute();
}

public class OpenFileCommand : ICommand
{
    private readonly IFileSystemReceiver _fileSystem;

    public OpenFileCommand(IFileSystemReceiver fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Execute()
    {
        _fileSystem.OpenFile();
    }
}

public class WriteFileCommand : ICommand
{
    private readonly IFileSystemReceiver _fileSystem;

    public WriteFileCommand(IFileSystemReceiver fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Execute()
    {
        _fileSystem.WriteFile();
    }
}

public class CloseFileCommand : ICommand
{
    private readonly IFileSystemReceiver _fileSystem;

    public CloseFileCommand(IFileSystemReceiver fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Execute()
    {
        _fileSystem.CloseFile();
    }
}
#endregion

#region Receiver (Получатель)
public interface IFileSystemReceiver
{
    public void OpenFile();
    public void WriteFile();
    public void CloseFile();
}

public class WindowsFileSystemReceiver : IFileSystemReceiver
{
    public void OpenFile()
    {
        Console.WriteLine("Opening file in Windows OS");
    }

    public void WriteFile()
    {
        Console.WriteLine("Writing file in Windows OS");
    }

    public void CloseFile()
    {
        Console.WriteLine("Closing file in Windows OS");
    }
}

public class LinuxFileSystemReceiver : IFileSystemReceiver
{
    public void OpenFile()
    {
        Console.WriteLine("Opening file in Linux OS");
    }

    public void WriteFile()
    {
        Console.WriteLine("Writing file in Linux OS");
    }

    public void CloseFile()
    {
        Console.WriteLine("Closing file in Linux OS");
    }
}
#endregion

#region Invoker (Инициатор)
public class FileInvoker
{
    private readonly ICommand _openFileCommand;
    private readonly ICommand _writeFileCommand;
    private readonly ICommand _closeFileCommand;

    public FileInvoker(ICommand openFileCommand, ICommand writeFileCommand,
        ICommand closeFileCommand)
    {
        _openFileCommand = openFileCommand;
        _writeFileCommand = writeFileCommand;
        _closeFileCommand = closeFileCommand;
    }

    public void PressOpenFile()
    {
        _openFileCommand.Execute();
    }

    public void PressWriteFile()
    {
        _writeFileCommand.Execute();
    }

    public void PressCloseFile()
    {
        _closeFileCommand.Execute();
    }
}
#endregion
