namespace MailRepositoryService.Core.Interfaces
{
    public interface IRepositorySettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
