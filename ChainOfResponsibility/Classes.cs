namespace ChainOfResponsibility;

public abstract class EmployeeLeaveHandler
{
    protected EmployeeLeaveHandler? Supervisor { get; set; }

    public void SetNextSupervisor(EmployeeLeaveHandler supervisor)
    {
        this.Supervisor = supervisor;
    }

    public abstract void ApplyLeave(string employeeName, int numberOfDaysLeave);
}

public class TeamLeader : EmployeeLeaveHandler
{
    private const int MAX_NUMBER_OF_DAYS_LEAVE_CAN_APPROVE = 10;

    public override void ApplyLeave(string employeeName, int numberOfDaysLeave)
    {
        if (numberOfDaysLeave <= MAX_NUMBER_OF_DAYS_LEAVE_CAN_APPROVE)
        {
            Console.WriteLine(
                $"TeamLeader approved {numberOfDaysLeave} days leave for the employee {employeeName}");

            return;
        }

        Supervisor?.ApplyLeave(employeeName, numberOfDaysLeave);
    }
}

public class ProjectLeader : EmployeeLeaveHandler
{
    private const int MAX_NUMBER_OF_DAYS_LEAVE_CAN_APPROVE = 20;

    public override void ApplyLeave(string employeeName, int numberOfDaysLeave)
    {
        if (numberOfDaysLeave <= MAX_NUMBER_OF_DAYS_LEAVE_CAN_APPROVE)
        {
            Console.WriteLine(
                $"ProjectLeader approved {numberOfDaysLeave} days leave for the employee {employeeName}");

            return;
        }

        Supervisor?.ApplyLeave(employeeName, numberOfDaysLeave);
    }
}

public class HR : EmployeeLeaveHandler
{
    private const int MAX_NUMBER_OF_DAYS_LEAVE_CAN_APPROVE = 30;

    public override void ApplyLeave(string employeeName, int numberOfDaysLeave)
    {
        if (numberOfDaysLeave <= MAX_NUMBER_OF_DAYS_LEAVE_CAN_APPROVE)
        {
            Console.WriteLine(
                $"HR approved {numberOfDaysLeave} days leave for the employee {employeeName}");

            return;
        }

        Console.WriteLine($"Leave application suspended for the employee {employeeName}, "
            + "please contact HR");
    }
}