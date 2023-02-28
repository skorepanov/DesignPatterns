namespace CompositePattern;

public interface IComponent
{
    void DisplayPrice();
    int GetTotalPrice();
}

public class Leaf : IComponent
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Leaf(string name, int price)
    {
        this.Name = name;
        this.Price = price;
    }

    public void DisplayPrice()
    {
        Console.WriteLine($"{Name}: {Price}");
    }

    public int GetTotalPrice()
    {
        return Price;
    }
}

public class Composite : IComponent
{
    public string Name { get; set; }
    public int Price { get; set; }
    private List<IComponent> _components = new List<IComponent>();

    public Composite(string name, int price)
    {
        this.Name = name;
        this.Price = price;
    }

    public void AddComponent(IComponent component)
    {
        _components.Add(component);
    }

    public void DisplayPrice()
    {
        Console.WriteLine($"{Name}: {Price} (total price: {GetTotalPrice()})");

        foreach (var component in _components)
        {
            component.DisplayPrice();
        }
    }

    public int GetTotalPrice()
    {
        return Price + _components.Sum(c => c.GetTotalPrice());
    }
}