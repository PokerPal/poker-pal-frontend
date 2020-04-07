namespace Application.Models.Output
{
    /// <summary>
    /// Represents details of a user league.
    /// </summary>
    public class UserLeagueOutputModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLeagueOutputModel"/> class.
        /// </summary>
        /// <param name="userId">The users unique id.</param>
        /// <param name="leagueId">The sessions unique id.</param>
        /// <param name="totalScore">The users total score for the league.</param>
        public UserLeagueOutputModel(int userId, int leagueId, int totalScore)
        {
            this.UserId = userId;
            this.LeagueId = leagueId;
            this.TotalScore = totalScore;
        }

        /// <summary>
        /// The unique identifier of the linked user.
        /// </summary>
        public int UserId { get; }

        /// <summary>
        /// The unique identifier of the linked league.
        /// </summary>
        public int LeagueId { get; }

        /// <summary>
        /// The total score of the user in this league.
        /// </summary>
        public int TotalScore { get; }
    }
}