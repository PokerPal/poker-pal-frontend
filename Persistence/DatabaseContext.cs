using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence
{
    public partial class DatabaseContext: DbContext
    {
        internal DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<UserEntity> Users { get; set; }
    }
}