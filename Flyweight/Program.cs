using Flyweight;

var latitude = 10.0m;
var longitude = 20.0m;
var houseFactory = new HouseFactory();

for (var i = 0; i < 5; i++)
{
    var panelHouse = houseFactory.GetHouse("Panel");
    panelHouse.Build(latitude, longitude);

    latitude += 0.1m;
    longitude += 0.2m;
}

Console.WriteLine();

for (var i = 0; i < 5; i++)
{
    var brickHouse = houseFactory.GetHouse("Brick");
    brickHouse.Build(latitude, longitude);

    latitude += 0.1m;
    longitude += 0.2m;
}
