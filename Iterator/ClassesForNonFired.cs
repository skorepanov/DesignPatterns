namespace Iterator;

public class AggregateForNonFired : IAggregate
{
    private readonly List<Employee> _items;

    public AggregateForNonFired(List<Employee> items)
    {
        _items = items;
    }

    public IIterator CreateIterator()
    {
        return new IteratorForNonFired(this);
    }

    public int Count => _items.Count;

    public Employee this[int index] => _items[index];
}

public class IteratorForNonFired : IIterator
{
    private readonly IAggregate _aggregate;
    private int _currentIndex;

    public IteratorForNonFired(IAggregate aggregate)
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

        while (_currentIndex < _aggregate.Count)
        {
            var employee = _aggregate[_currentIndex];

            if (employee.IsFired)
            {
                _currentIndex++;
            }
            else
            {
                return employee;
            }
        }

        return null;
    }

    public Employee CurrentItem()
    {
        return _aggregate[_currentIndex];
    }

    public bool HasNext()
    {
        var currentIndex = _currentIndex;

        while (currentIndex < _aggregate.Count)
        {
            var employee = _aggregate[currentIndex];

            if (!employee.IsFired)
            {
                return true;
            }

            currentIndex++;
        }

        return false;
    }

    public void Reset()
    {
        _currentIndex = 0;
    }
}
