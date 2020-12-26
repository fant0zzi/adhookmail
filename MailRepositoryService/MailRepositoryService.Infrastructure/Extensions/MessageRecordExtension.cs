namespace MailRepositoryService.Infrastructure.Extensions
{
    using MailRepositoryService.Core.Entities;
    using MailRepositoryService.Infrastructure.Models;

    internal static class MessageRecordExtension
    {
        public static Message ToMessage(this MessageRecord messageRecord)
        {
            return new Message
            {
                MessageId = messageRecord.MessageId,
                Subject = messageRecord.Subject,
                From = messageRecord.From,
                To = messageRecord.To,
                Content = messageRecord.Content,
                TimeStamp = messageRecord.TimeStamp
            };
        }
    }
}
