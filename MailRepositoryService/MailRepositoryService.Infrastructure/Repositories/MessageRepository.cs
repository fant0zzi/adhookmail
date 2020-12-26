namespace MailRepositoryService.Infrastructure.Services
{
    using MailRepositoryService.Core.Entities;
    using MailRepositoryService.Core.Interfaces;
    using MailRepositoryService.Infrastructure.Extensions;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class MessageRepository : IMessageRepository
    {
        private readonly DbContext dbContext;

        public MessageRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddMessage(Message message)
        {
            await this.dbContext.Messages.InsertOneAsync(message.ToMessageRecord());
        }

        public async Task<IEnumerable<Message>> FindMessagesByMessageId(string messageId)
        {
            var cursor = await this.dbContext.Messages.FindAsync(m => m.MessageId == messageId);
            var messages = await cursor.ToListAsync();
            return messages.Select(m => m.ToMessage());
        }

        public async Task<IEnumerable<Message>> FindMessagesBySubject(string subject)
        {
            var cursor = await this.dbContext.Messages.FindAsync(m => m.Subject == subject);
            var messages = await cursor.ToListAsync();
            return messages.Select(m => m.ToMessage());
        }

        public async Task<IEnumerable<Message>> FindMessagesBySender(string sender)
        {
            var cursor = await this.dbContext.Messages.FindAsync(m => m.From == sender);
            var messages = await cursor.ToListAsync();
            return messages.Select(m => m.ToMessage());
        }

        public async Task<IEnumerable<Message>> FindMessagesByRecipient(string recipient)
        {
            var cursor = await this.dbContext.Messages.FindAsync(m => m.To == recipient);
            var messages = await cursor.ToListAsync();
            return messages.Select(m => m.ToMessage());
        }

        public async Task DeleteMessage(string messageId)
        {
            await this.dbContext.Messages.DeleteManyAsync(m => m.MessageId == messageId);
        }
    }
}
