namespace Iterator;

public class AggregateForAll : IAggregate
{
    private readonly List<Employee> _items;

    public AggregateForAll(List<Employee> items)
    {
        _items = items;
    }

    public IIterator CreateIterator()
    {
        return new IteratorForAll(this);
    }

    public int Count => _items.Count;

    public Employee this[int index] => _items[index];
}


public class IteratorForAll : IIterator
{
    private readonly IAggregate _aggregate;
    private int _currentIndex;

    public IteratorForAll(IAggregate aggregate)
    {
        _aggregate = aggregate;
    }

    public Employee First()
    {
        return _aggregate[0];
    }

    public Employee Next()
    {
        _currentIndex++;
        return _currentIndex < _aggregate.Count
            ? _aggregate[_currentIndex]
            : null;
    }

    public Employee CurrentItem()
    {
        return _aggregate[_currentIndex];
    }

    public bool HasNext()
    {
        return _currentIndex < _aggregate.Count;
    }

    public void Reset()
    {
        _currentIndex = 0;
    }
}