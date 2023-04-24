namespace State;

#region State
public interface IState
{
    AccountContext AccountContext { get; set; }
    decimal Balance { get; }
    string StateInfo { get; }
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
}

public abstract class StateBase : IState
{
    public decimal Balance { get; private set; }
    public AccountContext AccountContext { get; set; }

    public string StateInfo
        => this.GetType().Name;

    protected StateBase(decimal balance)
    {
        Balance = balance;
    }

    protected abstract void UpdateState();

    public void Deposit(decimal amount)
    {
        Balance += amount;
        UpdateState();
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
        UpdateState();
    }
}
#endregion

#region Context
public class AccountContext
{
    public IState State { get; set; }

    public AccountContext(IState state)
    {
        State = state;
        State.AccountContext = this;
    }

    public void Deposit(decimal amount)
    {
        State.Deposit(amount);

        Console.WriteLine($"Положили {amount}");
        Console.WriteLine($"Текущий баланс:    {State.Balance}");
        Console.WriteLine($"Текущее состояние: {State.StateInfo}");
        Console.WriteLine();
    }

    public void Withdraw(decimal amount)
    {
        State.Withdraw(amount);

        Console.WriteLine($"Сняли {amount}");
        Console.WriteLine($"Текущий баланс:    {State.Balance}");
        Console.WriteLine($"Текущее состояние: {State.StateInfo}");
        Console.WriteLine();
    }
}
#endregion

#region Concrete states
// balance < 0 => RedState
// 0 <= balance <= 100000 => SilverState
// balance > 100000 => GoldState

public class SilverState : StateBase
{
    public SilverState(IState state) : this(state.Balance)
    {
        AccountContext = state.AccountContext;
    }

    public SilverState(decimal balance) : base(balance) { }

    protected override void UpdateState()
    {
        if (Balance < 0)
        {
            AccountContext.State = new RedState(this);
        }
        else if (Balance > 100000)
        {
            AccountContext.State = new GoldState(this);
        }
    }
}

public class RedState : StateBase
{
    public RedState(IState state) : this(state.Balance)
    {
        AccountContext = state.AccountContext;
    }

    public RedState(decimal balance) : base(balance) { }

    protected override void UpdateState()
    {
        if (Balance >= 0)
        {
            AccountContext.State = new SilverState(this);
        }
    }
}

public class GoldState : StateBase
{
    public GoldState(IState state) : this(state.Balance)
    {
        base.AccountContext = state.AccountContext;
    }

    public GoldState(decimal balance) : base(balance) { }

    protected override void UpdateState()
    {
        if (Balance < 0)
        {
            AccountContext.State = new RedState(this);
        }
        else if (Balance <= 100000)
        {
            AccountContext.State = new SilverState(this);
        }
    }
}
#endregion