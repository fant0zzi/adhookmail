namespace MailRepositoryService.Infrastructure.Services
{
    using MailRepositoryService.Core.Interfaces;
    using MailRepositoryService.Infrastructure.Models;
    using MongoDB.Driver;

    internal class DbContext
    {
        private readonly IMongoDatabase db;

        public DbContext(IRepositorySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            this.db = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<MessageRecord> Messages =>
            this.db.GetCollection<MessageRecord>("Messages");
    }
}
