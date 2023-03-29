namespace Bridge;

#region Messages (Abstractions)
// Abstraction
public abstract class Message
{
    public IMessageSender MessageSender { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public abstract void Send();
}

// Refined abstraction 1
public class SystemMessage : Message
{
    public override void Send()
    {
        MessageSender.SendMessage(Subject, Body);
    }
}

// Refined abstraction 2
public class UserMessage : Message
{
    public string UserComments { get; set; }

    public override void Send()
    {
        var fullBody = $"{Body}{Environment.NewLine}User comments: {UserComments}";
        MessageSender.SendMessage(Subject, fullBody);
    }
}
#endregion

#region MessageSenders (Implementors)
// Implementor (Bridge)
public interface IMessageSender
{
    void SendMessage(string subject, string body);
}

// Concrete implementor 1
public class EmailSender : IMessageSender
{
    public void SendMessage(string subject, string body)
    {
        Console.WriteLine(
              $"By email{Environment.NewLine}"
            + $"Subject: {subject}{Environment.NewLine}"
            + $"Body: {body}{Environment.NewLine}");
    }
}

// Concrete implementor 2
public class MqSender : IMessageSender
{
    public void SendMessage(string subject, string body)
    {
        Console.WriteLine(
              $"By MQ{Environment.NewLine}"
            + $"Subject: {subject}{Environment.NewLine}"
            + $"Body: {body}{Environment.NewLine}");
    }
}

// Concrete implementor 3
public class WebServiceSender : IMessageSender
{
    public void SendMessage(string subject, string body)
    {
        Console.WriteLine(
              $"By WebService{Environment.NewLine}"
            + $"Subject: {subject}{Environment.NewLine}"
            + $"Body: {body}{Environment.NewLine}");
    }
}
#endregion