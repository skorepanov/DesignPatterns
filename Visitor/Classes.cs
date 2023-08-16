using System.Text.Json;

namespace Visitor;

#region Visitors
public interface IVisitor
{
    void VisitPhone(Phone phone);
    void VisitJacket(Jacket jacket);
}

public class JsonSerializerVisitor : IVisitor
{
    public void VisitPhone(Phone phone)
    {
        var json = JsonSerializer.Serialize(phone);
        Console.WriteLine(json);
    }

    public void VisitJacket(Jacket jacket)
    {
        var json = JsonSerializer.Serialize(jacket);
        Console.WriteLine(json);
    }
}

public class SumVisitor : IVisitor
{
    public decimal TotalCost { get; private set; }

    public void VisitPhone(Phone phone)
    {
        TotalCost += phone.Price;
    }

    public void VisitJacket(Jacket jacket)
    {
        TotalCost += jacket.Cost;
    }
}
#endregion

#region Elements
public interface IProduct
{
    void Accept(IVisitor visitor);
}

public class Phone : IProduct
{
    public string Model { get; set; }
    public decimal Price { get; set; }

    public void Accept(IVisitor visitor)
    {
       visitor.VisitPhone(this);
    }
}

public class Jacket : IProduct
{
    public int Size { get; set; }
    public decimal Cost { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitJacket(this);
    }
}
#endregion

public class Cart
{
    private List<IProduct> _products = new();

    public void Add(IProduct product)
    {
        _products.Add(product);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var product in _products)
        {
            product.Accept(visitor);
        }
    }
}