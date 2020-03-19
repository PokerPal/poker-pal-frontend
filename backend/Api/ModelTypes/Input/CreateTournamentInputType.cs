using System;

namespace Api.ModelTypes.Input
{
    /// <summary>
    /// Details required to make a new tournament.
    /// </summary>
    public class CreateTournamentInputType
    {
        /// <summary>
        /// The tournament's start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The tournament's end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The frequency of this tournament.
        /// How often the tournament occurs, in days.
        /// ie '7' for a week.
        /// </summary>
        public int? Frequency { get; set; }

        /// <summary>
        /// The tournament's venue.
        /// </summary>
        public string Venue { get; set; }
    }
}
