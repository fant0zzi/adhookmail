namespace MailRepositoryService.Core.Interfaces
{
    using MailRepositoryService.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessageRepository
    {
        Task AddMessage(Message message);

        Task<IEnumerable<Message>> FindMessagesByMessageId(string messageId);

        Task<IEnumerable<Message>> FindMessagesBySubject(string subject);

        Task<IEnumerable<Message>> FindMessagesBySender(string sender);

        Task<IEnumerable<Message>> FindMessagesByRecipient(string recipient);

        Task DeleteMessage(string messageId);
    }
}
