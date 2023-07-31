using Iterator;

var employees = new List<Employee>
{
    new (name: "Иванов", isFired: false),
    new (name: "Петров", isFired: false),
    new (name: "Сидоров", isFired: true),
    new (name: "Смирнов", isFired: true),
    new (name: "Александров", isFired: false),
};

IAggregate aggregate = new AggregateForAll(employees);
//IAggregate aggregate = new AggregateForNonFired(employees);

IIterator iterator = aggregate.CreateIterator();

var employee = iterator.First();

while (iterator.HasNext())
{
    Console.WriteLine($"Name = {employee.Name}, IsFired = {employee.IsFired}");
    employee = iterator.Next();
}
