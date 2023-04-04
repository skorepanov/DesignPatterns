namespace Strategy;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Employee(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public override string ToString()
    {
        return $"Id = {Id}, Name = {Name}.";
    }
}

// Concrete strategy
public class EmployeeByNameComparer : IComparer<Employee>
{
    public int Compare(Employee e1, Employee e2)
    {
        return string.Compare(e1.Name, e2.Name, StringComparison.Ordinal);
    }
}
