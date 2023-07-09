namespace Memento_Simple;

/// <summary>
/// Originator (Создатель)
/// </summary>
public class Document
{
    private string _text = string.Empty;
    private int _style = 1;

    public void AddBlock(string text)
    {
        _text += text + Environment.NewLine;
    }

    public void SetStyle(int style)
    {
        _style = style;
    }

    public void Print()
    {
        Console.WriteLine($"Стиль: {_style}");
        Console.WriteLine("Текст:");
        Console.WriteLine(_text);
    }

    public DocumentMemento SaveState()
    {
        return new DocumentMemento(_text, _style);
    }

    public void RestoreState(DocumentMemento memento)
    {
        _text = memento.Text;
        _style = memento.Style;
    }
}

/// <summary>
/// Снимок
/// </summary>
public class DocumentMemento
{
    public string Text { get; }
    public int Style { get; }

    public DocumentMemento(string text, int style)
    {
        Text = text;
        Style = style;
    }
}

/// <summary>
/// Caretaker (Опекун)
/// </summary>
public class EditorHistory
{
    private readonly Stack<DocumentMemento> _history = new();

    public void Push(DocumentMemento memento)
    {
        _history.Push(memento);
    }

    public DocumentMemento Pop()
    {
        return _history.Pop();
    }
}