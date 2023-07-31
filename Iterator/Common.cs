namespace Iterator;

public class Employee
{
    public readonly string Name;
    public readonly bool IsFired;

    public Employee(string name, bool isFired)
    {
        Name = name;
        IsFired = isFired;
    }
}

public interface IAggregate
{
    IIterator CreateIterator();
    int Count { get; }
    Employee this[int index] { get; }
}

public interface IIterator
{
    Employee First();
    Employee Next();
    Employee CurrentItem();
    bool HasNext();
    void Reset();
}
