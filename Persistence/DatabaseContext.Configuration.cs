using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence
{
    public partial class DatabaseContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigurePrimary(modelBuilder);
            this.ConfigureRelationships(modelBuilder);
        }

        private void ConfigurePrimary(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
        }
    }
}