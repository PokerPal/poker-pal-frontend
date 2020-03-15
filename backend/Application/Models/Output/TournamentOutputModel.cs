using System;

namespace Application.Models.Output
{
    /// <summary>
    /// Represents details about a tournament
    /// </summary>
    public class TournamentOutputModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentOutputModel"/> class.
        /// </summary>
        /// <param name="id">The Tournaments Unique Identifier.</param>
        /// <param name="startDate">The start date of the tournament.</param>
        /// <param name="endDate">The end date of the tournament.</param>
        /// <param name="frequency">How often the tournament occurs</param>
        /// <param name="venue">Where the tournament takes place</param>
        public TournamentOutputModel(int id, DateTime startDate, DateTime endDate, int? frequency, string venue)
        {
            this.Id = id;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Frequency = frequency;
            this.Venue = venue;
        }

        /// <summary>
        /// The tournament's unique identifier.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The tournament's start date.
        /// </summary>
        public DateTime StartDate { get; }

        /// <summary>
        /// The tournament's end date.
        /// </summary>
        public DateTime EndDate { get; }

        /// <summary>
        /// The frequency of this tournament.
        /// </summary>
        public int? Frequency { get; }

        /// <summary>
        /// The tournament's venue.
        /// </summary>
        public string Venue { get; }
    }
}