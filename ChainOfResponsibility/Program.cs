using ChainOfResponsibility;

var teamLeader = new TeamLeader();
var projectLeader = new ProjectLeader();
var hr = new HR();

teamLeader.SetNextSupervisor(projectLeader);
projectLeader.SetNextSupervisor(hr);

teamLeader.ApplyLeave("Anna", 5);
Console.WriteLine();

teamLeader.ApplyLeave("Natalie", 15);
Console.WriteLine();

teamLeader.ApplyLeave("Victoria", 25);
Console.WriteLine();

teamLeader.ApplyLeave("John", 50);
Console.WriteLine();
