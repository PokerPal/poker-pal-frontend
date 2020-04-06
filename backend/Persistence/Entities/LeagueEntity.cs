using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    /// <summary>
    /// Represents a league in the database.
    /// </summary>
    public class LeagueEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueEntity"/> class.
        /// </summary>
        /// <param name="id">The league's unique identifier.</param>
        /// <param name="name">The league's name.</param>
        /// <param name="startingAmount">The amount of points a user starts with.</param>
        /// <param name="allowChanges">If sessions are allowed to have changes to entities.</param>
        public LeagueEntity(int id, string name, int startingAmount, bool allowChanges)
        {
            this.Id = id;
            this.Name = name;
            this.StartingAmount = startingAmount;
            this.AllowChanges = allowChanges;
        }

        /// <summary>
        /// Gets or sets this league's unique identifier.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets this league's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets this league's starting amount, the amount a user starts with.
        /// </summary>
        public int StartingAmount { get; set; }

        /// <summary>
        /// Gets or sets whether or not events in this league can be changed.
        /// </summary>
        public bool AllowChanges { get; set; }

        /// <summary>
        /// Gets or sets the list of sessions that have occurred in this league; autofilled when
        /// fetched from the database, null otherwise.
        /// </summary>
        public virtual List<SessionEntity> Sessions { get; set; } = null;

        /// <summary>
        /// Gets or sets the list of user leagues that have occurred in this league; autofilled when
        /// fetched from the database, null otherwise.
        /// </summary>
        public virtual IEnumerable<UserLeagueEntity> UserLeagues { get; set; } = null;
    }
}
