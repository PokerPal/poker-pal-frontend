using System;
using System.Globalization;

using Application.Models.Output;

namespace Api.ModelTypes.Output
{
    /// <summary>
    /// Details about a Tournament.
    /// </summary>
    public class TournamentOutputType
    {
        /// <summary>
        /// Converts an instance of the model <see cref="TournamentOutputModel"/> to this output
        /// type.
        /// </summary>
        public static readonly Func<TournamentOutputModel, TournamentOutputType> FromModel
            = model => new TournamentOutputType { Model = model };

        /// <summary>
        /// The tournament's unique identifier.
        /// </summary>
        public int Id => this.Model.Id;

        /// <summary>
        /// The tournament's start date.
        /// </summary>
        public DateTime StartDate => this.Model.StartDate;

        /// <summary>
        /// the tournament's end date.
        /// </summary>
        public DateTime EndDate => this.Model.EndDate;

        /// <summary>
        /// The tournament Frequency.
        /// </summary>
        public int? Frequency => this.Model.Frequency;

        /// <summary>
        /// The tournament's venue.
        /// </summary>
        public string Venue => this.Model.Venue;

        internal TournamentOutputModel Model { get; set; }
    }
}
