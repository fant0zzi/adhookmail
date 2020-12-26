namespace MailRepositoryService.Infrastructure.Entities
{
    using MailRepositoryService.Core.Interfaces;

    public sealed class MessageRepositorySettings : IRepositorySettings
    {
        public string RepositoryName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
