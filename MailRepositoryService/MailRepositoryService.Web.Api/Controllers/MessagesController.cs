namespace MailRepositoryService.Web.Api.Controllers
{
    using MailRepositoryService.Core.Entities;
    using MailRepositoryService.Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        [Route("{messageId}")]
        [HttpGet]
        public async Task<List<Message>> GetMessagesByMessageId(string messageId)
        {
            var messages = await this.messageRepository.FindMessagesByMessageId(messageId);
            return messages.ToList();
        }

        [Route("subject/{subject}")]
        [HttpGet]
        public async Task<List<Message>> GetMessagesBySubject(string subject)
        {
            var messages = await this.messageRepository.FindMessagesBySubject(subject);
            return messages.ToList();
        }

        [Route("from/{mailFrom}")]
        [HttpGet]
        public async Task<List<Message>> GetMessagesBySender(string mailFrom)
        {
            var messages = await this.messageRepository.FindMessagesBySender(mailFrom);
            return messages.ToList();
        }

        [Route("to/{mailTo}")]
        [HttpGet]
        public async Task<List<Message>> GetMessagesByRecipient(string mailTo)
        {
            var messages = await this.messageRepository.FindMessagesByRecipient(mailTo);
            return messages.ToList();
        }

        [Route("message")]
        [HttpPost]
        public async Task AddMessage(Message message)
        {
            await this.messageRepository.AddMessage(message);
        }

        [Route("")]
        [HttpDelete]
        public async Task DeleteMessageByMessageId(string messageId)
        {
            await this.messageRepository.DeleteMessage(messageId);
        }
    }
}
