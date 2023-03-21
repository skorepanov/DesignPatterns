using System.Collections;

namespace Flyweight;

public abstract class House
{
    protected Guid _id;
    protected int FloorsCount;

    protected House()
    {
        _id = Guid.NewGuid();
    }

    public abstract void Build(decimal latitude, decimal longitude);
}

public class PanelHouse : House
{
    public PanelHouse()
    {
        FloorsCount = 16;
    }

    public override void Build(decimal latitude, decimal longitude)
    {
        Console.WriteLine($"Построен панельный дом из {FloorsCount} этажей (id = {_id}); "
            + $"координаты: {latitude} широты, {longitude} долготы.");
    }
}

public class BrickHouse : House
{
    public BrickHouse()
    {
        FloorsCount = 5;
    }

    public override void Build(decimal latitude, decimal longitude)
    {
        Console.WriteLine($"Построен кирпичный дом из {FloorsCount} этажей (id = {_id}); "
                          + $"координаты: {latitude} широты, {longitude} долготы.");
    }
}

public class HouseFactory
{
    private readonly Hashtable _houses = new Hashtable();

    public House GetHouse(string key)
    {
        var house = _houses[key] as House;

        if (house is null)
        {
            house = key switch
            {
                "Panel" => new PanelHouse(),
                "Brick" => new BrickHouse(),
                _ => house
            };
            _houses.Add(key, house);
        }

        return house;
    }
}
