namespace Memento_Simple;

/// <summary>
/// Originator (Создатель)
/// </summary>
public class Document
{
    private string _text = string.Empty;
    private int _style = 1;

    public void SetText(string text)
    {
        _text = text;
    }

    public void SetStyle(int style)
    {
        _style = style;
    }

    public void Print()
    {
        Console.WriteLine($"Стиль: {_style}");
        Console.WriteLine($"Текст: {_text}");
    }

    public Memento SaveState()
    {
        return new Memento(_text, _style);
    }

    public void RestoreState(Memento memento)
    {
        _text = memento.Text;
        _style = memento.Style;
    }
}

/// <summary>
/// Memento (Снимок)
/// </summary>
public class Memento
{
    public readonly string Text;
    public readonly int Style;

    public Memento(string text, int style)
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
    private readonly Stack<Memento> _history = new();
    private readonly Document _document;

    public EditorHistory(Document document)
    {
        _document = document;
    }

    public void ChangeState(int style, string text)
    {
        var state = _document.SaveState();
        _history.Push(state);

        _document.SetStyle(style);
        _document.SetText(text);
    }

    public void Undo()
    {
        var state = _history.Pop();
        _document.RestoreState(state);
    }
}