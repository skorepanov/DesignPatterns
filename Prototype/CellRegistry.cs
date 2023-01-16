namespace Prototype;

public class CellRegistry
{
    private Dictionary<string, ICell> _cells = new();

    public ICell this[string key]
    {
        get => _cells[key];
        set => _cells.Add(key, value);
    }
}