namespace Interpreter;

public class Context
{
    private readonly Dictionary<string, int> _variables = new();

    public int GetVariable(string name)
    {
        return _variables[name];
    }

    public void SetVariable(string name, int value)
    {
        if (_variables.ContainsKey(name))
        {
            _variables[name] = value;
        }
        else
        {
            _variables.Add(name, value);
        }
    }
}

public interface IExpression
{
    int Interpret(Context context);
}

/// <summary>
/// Терминальное выражение
/// </summary>
public class NumberExpression : IExpression
{
    private readonly string _name;

    public NumberExpression(string name)
    {
        _name = name;
    }

    public int Interpret(Context context)
    {
        return context.GetVariable(_name);
    }
}

/// <summary>
/// Нетерминальное выражение для сложения
/// </summary>
public class AddExpression : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public AddExpression(IExpression leftExpression, IExpression rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public int Interpret(Context context)
    {
        return _leftExpression.Interpret(context) + _rightExpression.Interpret(context);
    }
}

/// <summary>
/// Нетерминальное выражение для вычитания
/// </summary>
public class SubtractExpression : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public SubtractExpression(IExpression leftExpression, IExpression rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public int Interpret(Context context)
    {
        return _leftExpression.Interpret(context) - _rightExpression.Interpret(context);
    }
}