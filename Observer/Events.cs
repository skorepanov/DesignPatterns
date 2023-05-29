namespace Observer.Events;

public class StateChangeEventArgs : EventArgs
{
    public int State { get; }

    public StateChangeEventArgs(int state)
    {
        State = state;
    }
}

public class Subject
{
    private int _state;
    public event EventHandler<StateChangeEventArgs> StateChange;

    public int State
    {
        get => _state;
        private set
        {
            _state = value;
            var eventArgs = new StateChangeEventArgs(_state);
            OnStateChange(eventArgs);
        }
    }

    public void MakeBusinessLogic()
    {
        Console.WriteLine("Выполняется бизнес-логика");
        State = new Random().Next(100);
    }

    private void OnStateChange(StateChangeEventArgs e)
    {
        if (StateChange != null)
        {
            StateChange(this, e);
        }
    }
}

public class Observer1 : IDisposable
{
    private readonly Subject _subject;

    public Observer1(Subject subject)
    {
        _subject = subject;
        _subject.StateChange += SubjectStateChange;
    }

    private void SubjectStateChange(object sender, StateChangeEventArgs e)
    {
        Console.WriteLine($"Обработка обновления наблюдателем №1. Значение {e.State}");
    }

    public void Dispose()
    {
        _subject.StateChange -= SubjectStateChange;
    }
}

public class Observer2 : IDisposable
{
    private readonly Subject _subject;

    public Observer2(Subject subject)
    {
        _subject = subject;
        _subject.StateChange += SubjectStateChange;
    }

    private void SubjectStateChange(object sender, StateChangeEventArgs e)
    {
        Console.WriteLine($"Обработка обновления наблюдателем №2. Значение {e.State}");
    }

    public void Dispose()
    {
        _subject.StateChange -= SubjectStateChange;
    }
}
