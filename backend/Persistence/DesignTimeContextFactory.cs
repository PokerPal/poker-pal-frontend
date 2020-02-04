using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence
{
    public class DesignTimeContextFactory: IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var connectionString = "Host=localhost;Port=5032;Database=poker-pal;Username=group;Password=password";
            var options = new DbContextOptionsBuilder().UseNpgsql(connectionString).Options;
            return new DatabaseContext(options);
        }
    }
}