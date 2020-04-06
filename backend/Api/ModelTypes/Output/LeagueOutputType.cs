using System;

using Application.Models.Output;

using Persistence.Entities;

namespace Api.ModelTypes.Output
{
    /// <summary>
    /// Details about a league.
    /// </summary>
    public class LeagueOutputType
    {
        /// <summary>
        /// Converts an instance of the model <see cref="LeagueOutputModel"/> to this output
        /// type.
        /// </summary>
        public static readonly Func<LeagueOutputModel, LeagueOutputType> FromModel
            = model => new LeagueOutputType { Model = model };

        /// <summary>
        /// The league's unique identifier.
        /// </summary>
        public int Id => this.Model.Id;

        /// <summary>
        /// The league's name.
        /// </summary>
        public string Name => this.Model.Name;

        /// <summary>
        /// The type of the league.
        /// </summary>
        public LeagueType Type => this.Model.Type;

        internal LeagueOutputModel Model { get; set; }
    }
}
