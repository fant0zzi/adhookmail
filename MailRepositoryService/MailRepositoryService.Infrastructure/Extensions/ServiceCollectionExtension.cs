namespace MailRepositoryService.Infrastructure.Extensions
{
    using MailRepositoryService.Core.Interfaces;
    using MailRepositoryService.Infrastructure.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddSingleton<DbContext>();
        }
    }
}
