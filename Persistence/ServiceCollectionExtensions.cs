using System;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;

namespace Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabaseContextFactory(this IServiceCollection services,
            Action<DatabaseContextFactoryOptions> configure)
        {
            services.Configure(configure);
            services.AddSingleton<IDatabaseContextFactory<DatabaseContext>, DatabaseContextFactory>();
        }
    }
}