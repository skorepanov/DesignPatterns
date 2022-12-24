using System.Net.Mail;
using System.Text;
using Builder;

#region using MailMessageBuilder
var mail = new MailMessageBuilder()
    .From("from@mail.com")
    .To("to@mail.com")
    .Cc("cc@mail.com")
    .Subject("Title")
    .Body("Mail body", Encoding.UTF8)
    .Build();

new SmtpClient().Send(mail);
#endregion

#region using MailMessageBuilderEx
var mailEx = new MailMessage()
    .From("from@mail.com")
    .To("to@mail.com")
    .Cc("cc@mail.com")
    .Subject("Title")
    .Body("Mail body", Encoding.UTF8);

new SmtpClient().Send(mailEx);
#endregion
