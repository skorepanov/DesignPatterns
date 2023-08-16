using Visitor;

var cart = new Cart();

cart.Add(new Phone { Model = "Redmi Note 9", Price = 14999.99m });
cart.Add(new Jacket { Size = 50, Cost = 8000m });

var jsonSerializerVisitor = new JsonSerializerVisitor();
cart.Accept(jsonSerializerVisitor);
Console.WriteLine();

var sumVisitor = new SumVisitor();
cart.Accept(sumVisitor);
Console.WriteLine($"Total: {sumVisitor.TotalCost}");
