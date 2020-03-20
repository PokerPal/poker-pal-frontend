using Microsoft.EntityFrameworkCore;

using Persistence.Entities;

namespace Persistence
{
    /// <inheritdoc />
    public partial class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuration of this context.</param>
        internal DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the set of all users in the database.
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// Gets or sets the set of all tournaments in the database.
        /// </summary>
        public DbSet<TournamentEntity> Tournaments { get; set; }

        /// <summary>
        /// Gets or sets the set of all badges in the database.
        /// </summary>
        public DbSet<BadgeEntity> Badges { get; set; }

        /// <summary>
        /// Gets or sets the set of all user-tournament link entities in the database.
        /// </summary>
        public DbSet<UserTournamentEntity> UserTournaments { get; set; }

        /// <summary>
        /// Gets or sets the set of all user-badge link entities in the database.
        /// </summary>
        public DbSet<UserBadgeEntity> UserBadges { get; set; }
    }
}
