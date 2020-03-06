using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence
{
    /// <inheritdoc />
    public partial class DatabaseContext : DbContext
    {
        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigurePrimary(modelBuilder);
            this.ConfigureRelationships(modelBuilder);
        }

        /// <summary>
        /// Configures the database model by setting up primary keys for all entities.
        /// </summary>
        /// <param name="modelBuilder">The model builder for construction of the model.</param>
        private void ConfigurePrimary(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
            modelBuilder.Entity<TournamentEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<BadgeEntity>().HasKey(b => b.Id);

            modelBuilder.Entity<UserTournamentEntity>()
                .HasKey(ut => new { ut.UserId, ut.TournamentId });

            modelBuilder.Entity<UserBadgeEntity>()
                .HasKey(ub => new { ub.UserId, ub.BadgeId });
        }

        /// <summary>
        /// Configures the database model by setting up relationships between entities.
        /// </summary>
        /// <param name="modelBuilder">The model builder for construction of the model.</param>
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

            modelBuilder.Entity<UserBadgeEntity>()
                .HasOne(ub => ub.Badge)
                .WithMany(b => b!.UserBadges)
                .HasForeignKey(ub => ub.BadgeId);

            modelBuilder.Entity<UserBadgeEntity>()
                .HasOne(ub => ub.User)
                .WithMany(u => u!.UserBadges)
                .HasForeignKey(ub => ub.UserId);
        }
    }
}