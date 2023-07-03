namespace Mediator;

#region Components
public abstract class Component
{
    protected IMediator _mediator;

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }
}

public class ComponentA : Component
{
    public void DoOperation1()
    {
        Console.WriteLine("Компонент A выполнил операцию 1");
        _mediator.Notify(this, "1");
    }

    public void DoOperation2()
    {
        Console.WriteLine("Компонент A выполнил операцию 2");
        _mediator.Notify(this, "2");
    }
}

public class ComponentB : Component
{
    public void DoOperation3()
    {
        Console.WriteLine("Компонент B выполнил операцию 3");
        _mediator.Notify(this, "3");
    }

    public void DoOperation4()
    {
        Console.WriteLine("Компонент B выполнил операцию 4");
        _mediator.Notify(this, "4");
    }
}
#endregion

#region Mediator
public interface IMediator
{
    void Notify(Component sender, string message);
}

public class ConcreteMediator : IMediator
{
    private readonly ComponentA _componentA;
    private readonly ComponentB _componentB;

    public ConcreteMediator(ComponentA componentA, ComponentB componentB)
    {
        _componentA = componentA;
        _componentA.SetMediator(this);

        _componentB = componentB;
        _componentB.SetMediator(this);
    }

    public void Notify(Component sender, string message)
    {
        if (message == "1")
        {
            Console.WriteLine("Выполнена операция 1, выполняем операцию 3");
            _componentB.DoOperation3();
        }
        else if (message == "4")
        {
            Console.WriteLine("Выполнена операция 4, выполняем операции 2 и 3");
            _componentA.DoOperation2();
            _componentB.DoOperation3();
        }
    }
}
#endregion
