using System.Net.Mail;
using System.Text;

namespace Builder;

public static class MailMessageBuilderEx
{
    public static MailMessage From(this MailMessage mailMessage, string address)
    {
        mailMessage.From = new MailAddress(address);
        return mailMessage;
    }

    public static MailMessage To(this MailMessage mailMessage, string address)
    {
        mailMessage.To.Add(address);
        return mailMessage;
    }

    public static MailMessage Cc(this MailMessage mailMessage, string address)
    {
        mailMessage.CC.Add(address);
        return mailMessage;
    }

    public static MailMessage Subject(this MailMessage mailMessage, string subject)
    {
        mailMessage.Subject = subject;
        return mailMessage;
    }

    public static MailMessage Body(this MailMessage mailMessage, string body, Encoding encoding)
    {
        mailMessage.Body = body;
        mailMessage.BodyEncoding = encoding;
        return mailMessage;
    }
}