namespace Strategy;

// Strategy
public interface IPaymentStrategy
{
    public void Pay(decimal amount);
}

// Concrete strategy 1
public class CardPaymentStrategy : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата картой, сумма: {amount}.");
    }
}

// Concrete strategy 2
public class CashPaymentStrategy : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата наличными, сумма: {amount}.");
    }
}

// Context
public class PaymentContext
{
    private IPaymentStrategy PaymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        PaymentStrategy = strategy;
    }

    public void Pay(decimal amount)
    {
        PaymentStrategy.Pay(amount);
    }
}

