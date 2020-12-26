namespace MailRepositoryService.Core.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [Required]
        public string MessageId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string TimeStamp { get; set; }
    }
}
