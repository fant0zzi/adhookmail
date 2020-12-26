namespace MailRepositoryService.Infrastructure.Extensions
{
    using MailRepositoryService.Core.Entities;
    using MailRepositoryService.Infrastructure.Models;

    internal static class MessageExtenstion
    {
        public static MessageRecord ToMessageRecord(this Message message)
        {
            return new MessageRecord
            {
                MessageId = message.MessageId,
                Subject = message.Subject,
                From = message.From,
                To = message.To,
                Content = message.Content,
                TimeStamp = message.TimeStamp
            };
        }
    }
}
