using Interpreter;

var context = new Context();

var x = 5;
var y = 8;
var z = 2;

context.SetVariable("x", x);
context.SetVariable("y", y);
context.SetVariable("z", z);

// x + y - z
var expression = new SubtractExpression(
    new AddExpression(new NumberExpression("x"), new NumberExpression("y")),
    new NumberExpression("z")
);

var result = expression.Interpret(context);

Console.WriteLine($"{x} + {y} - {z} = {result}");
