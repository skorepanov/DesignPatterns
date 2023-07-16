namespace Memento_NestedClass;

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

    /// <summary>
    /// Memento (Снимок)
    /// </summary>
    private class Memento
    {
        public readonly string Text;
        public readonly int Style;

        public Memento(Document document)
        {
            Text = document._text;
            Style = document._style;
        }
    }

    public object SaveState()
    {
        return new Memento(this);
    }

    public void RestoreState(object mementoObj)
    {
        var memento = (Memento)mementoObj;
        _text = memento.Text;
        _style = memento.Style;
    }
}

/// <summary>
/// Caretaker (Опекун)
/// </summary>
public class EditorHistory
{
    private readonly Stack<object> _history = new();
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