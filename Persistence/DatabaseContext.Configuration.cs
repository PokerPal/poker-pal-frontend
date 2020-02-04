using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence
{
    public partial class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigurePrimary(modelBuilder);
            this.ConfigureRelationships(modelBuilder);
        }

        private void ConfigurePrimary(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
            modelBuilder.Entity<TournamentEntity>().HasKey(t => t.Id);

            modelBuilder.Entity<UserTournamentEntity>()
                .HasKey(ut => new {ut.UserId, ut.TournamentId});
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTournamentEntity>()
                .HasOne(ut => ut.User)
                .WithMany(u => u!.UserTournaments)
                .HasForeignKey(ut => ut.UserId);

            modelBuilder.Entity<UserTournamentEntity>()
                .HasOne(ut => ut.Tournament)
                .WithMany(t => t!.UserTournaments)
                .HasForeignKey(ut => ut.TournamentId);
        }
    }
}