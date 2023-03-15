namespace Proxy;

public interface IHeavyweight
{
    void Foo();
}

// стоимость создания класса очень высока
public class Heavyweight : IHeavyweight
{
    public Heavyweight()
    {
        Console.WriteLine("Heavyweight.ctor");
    }

    public void Foo()
    {
        Console.WriteLine("Heavyweight.Foo()");
    }
}

// виртуальный заместитель:
// будет создавать тяжеловесный объект лишь при необходимости
public class HeavyweightProxy : IHeavyweight
{
    private readonly Lazy<Heavyweight> _heavyweight = new Lazy<Heavyweight>();

    public HeavyweightProxy()
    {
        Console.WriteLine("Proxy.ctor");
    }

    public void Foo()
    {
        Console.WriteLine("Proxy.Foo() before Heavyweight.Foo()");
        _heavyweight.Value.Foo();
        Console.WriteLine("Proxy.Foo() after Heavyweight.Foo()");
    }
}