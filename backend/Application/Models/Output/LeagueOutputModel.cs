namespace Application.Models.Output
{
    /// <summary>
    /// Represents details about a league.
    /// </summary>
    public class LeagueOutputModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueOutputModel"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the league.</param>
        /// <param name="name">The name of the league.</param>
        public LeagueOutputModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// The unique identifier of the league.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The name of the league.
        /// </summary>
        public string Name { get; }
    }
}
