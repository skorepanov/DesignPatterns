namespace Observer.ClassicalImplementation;

public class Subject
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    public int State { get; private set; }

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }

    public void MakeBusinessLogic()
    {
        Console.WriteLine("Выполняется бизнес-логика");
        State = new Random().Next(100);
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        Console.WriteLine($"Отправка уведомлений. Кол-во наблюдателей: {_observers.Count}");
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}

public interface IObserver
{
    void Update(Subject subject);
}

public class Observer1 : IObserver
{
    public void Update(Subject subject)
    {
        Console.WriteLine($"Обработка обновления наблюдателем №1. Значение {subject.State}");
    }
}

public class Observer2 : IObserver
{
    public void Update(Subject subject)
    {
        Console.WriteLine($"Обработка обновления наблюдателем №2. Значение {subject.State}");
    }
}