using Bridge;

IMessageSender email = new EmailSender();
IMessageSender mq = new MqSender();
IMessageSender webService = new WebServiceSender();

Message systemMessage = new SystemMessage();
systemMessage.Subject = "System subject";
systemMessage.Body = "System body";

systemMessage.MessageSender = email;
systemMessage.Send();

systemMessage.MessageSender = mq;
systemMessage.Send();

systemMessage.MessageSender = webService;
systemMessage.Send();

UserMessage userMessage = new UserMessage();
userMessage.Subject = "User subject";
userMessage.Body = "User body";
userMessage.UserComments = "Some comments";

userMessage.MessageSender = email;
userMessage.Send();