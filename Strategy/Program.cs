using Strategy;

#region Пример с методами оплаты
var paymentContext = new PaymentContext();
paymentContext.SetPaymentStrategy(new CardPaymentStrategy());
paymentContext.Pay(amount: 100500);

paymentContext.SetPaymentStrategy(new CashPaymentStrategy());
paymentContext.Pay(amount: 666);
#endregion

#region Пример с сортировками
var employees = new List<Employee>
{
    new Employee(id: 2, name: "Вася"),
    new Employee(id: 3, name: "Алекс"),
    new Employee(id: 1, name: "Боря")
};

// стратегия на основе наследования
var comparer = new EmployeeByNameComparer();
employees.Sort(comparer);
Console.WriteLine("Сортировка по имени:");
writeEmployees(employees);

Console.WriteLine();

// стратегия на основе делегата (функциональная стратегия)
employees.Sort((e1, e2) => e1.Id.CompareTo(e2.Id));
Console.WriteLine("Сортировка по id:");
writeEmployees(employees);

void writeEmployees(List<Employee> employees)
{
    employees.ForEach(e => Console.WriteLine(e));
}
#endregion