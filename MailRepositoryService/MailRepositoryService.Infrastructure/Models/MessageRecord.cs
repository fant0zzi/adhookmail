namespace MailRepositoryService.Infrastructure.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    internal sealed class MessageRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Message-Id")]
        public string MessageId { get; set; }

        [BsonElement("Mail From")]
        public string From { get; set; }

        [BsonElement("Mail To")]
        public string To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public string TimeStamp { get; set; }

    }
}
