using Persistence.Entities;

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
        /// <param name="type">The type of the league.</param>
        public LeagueOutputModel(int id, string name, LeagueType type)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
        }

        /// <summary>
        /// The unique identifier of the league.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The name of the league.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The type of the league.
        /// </summary>
        public LeagueType Type { get; }
    }
}
