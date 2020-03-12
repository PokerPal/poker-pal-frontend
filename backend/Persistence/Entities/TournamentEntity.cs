using System;
using System.Collections.Generic;

namespace Persistence.Entities
{
    /// <summary>
    /// Represents a tournament in the database.
    /// </summary>
    public class TournamentEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentEntity"/> class.
        /// </summary>
        /// <param name="id">The tournament's unique identifier.</param>
        /// <param name="startDate">The tournament's start date.</param>
        /// <param name="endDate">The tournament's end date.</param>
        /// <param name="frequency">The tournament's frequency.</param>
        /// <param name="venue">The venue of the tournament.</param>
        public TournamentEntity(Guid id, DateTime startDate, DateTime endDate, int? frequency, string venue)
        {
            this.Id = id;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Frequency = frequency;
            this.Venue = venue;
        }

        /// <summary>
        /// Gets or sets this tournament's unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets this tournament's start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets this tournament's end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the frequency of this tournament.
        /// </summary>
        public int? Frequency { get; set; }

        /// <summary>
        /// Gets or sets this tournament's venue.
        /// </summary>
        public string Venue { get; set; }

        /// <summary>
        /// Gets or sets the user-tournament relations this tournament belongs to; autofilled when fetched from the
        /// database, null otherwise.
        /// </summary>
        public virtual List<UserTournamentEntity> UserTournaments { get; set; } = null;
    }
}