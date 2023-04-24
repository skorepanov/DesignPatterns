using State;

var state = new SilverState(balance: 0.0m);
var accountContext = new AccountContext(state);
accountContext.Deposit(1000);
accountContext.Deposit(10000);
accountContext.Deposit(90000);
accountContext.Withdraw(90000);
accountContext.Withdraw(90000);
accountContext.Deposit(90000);
accountContext.Deposit(90000);
