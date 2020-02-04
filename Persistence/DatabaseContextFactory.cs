using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Interfaces;

namespace Persistence
{
    public class DatabaseContextFactory: IDatabaseContextFactory<DatabaseContext>
    {
        private readonly DbContextOptions _contextOptions;
        
        public DatabaseContextFactory(IOptions<DatabaseContextFactoryOptions> options, IServiceProvider serviceProvider)
        {
            if (options.Value.InMemory)
            {
                var builder = new DbContextOptionsBuilder()
                    .UseInMemoryDatabase(options.Value.InMemoryDatabaseName);

                this._contextOptions = builder.Options;
            }
            else
            {
                var connectionString =
                    Encoding.UTF8.GetString(Convert.FromBase64String(options.Value.ConnectionString));
                
                var builder = new DbContextOptionsBuilder()
                    .UseNpgsql(connectionString);
            }
        }
        
        public DatabaseContext CreateDatabaseContext()
        {
            return new DatabaseContext(this._contextOptions);
        }
    }
}