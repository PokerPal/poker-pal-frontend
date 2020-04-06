namespace Persistence.Entities
{
    /// <summary>
    /// The users status in a league
    /// </summary>
    public class UserLeagueEntity
    {
        /// <summary>
        /// Gets or sets the User ID.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the League ID.
        /// </summary>
        public int LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the total score.
        /// </summary>
        public int TotalStore { get; set; }
    }
}