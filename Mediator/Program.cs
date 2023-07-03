using Mediator;

var componentA = new ComponentA();
var componentB = new ComponentB();
var mediator = new ConcreteMediator(componentA, componentB);

Console.WriteLine("Выполняем операцию 1");
componentA.DoOperation1();

Console.WriteLine();
Console.WriteLine("Выполняем операцию 4");
componentB.DoOperation4();
