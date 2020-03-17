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
        /// Converts an instance of the model <see cref="TournamentOutputModel"/> to this model tournament type.
        /// </summary>
        public static Func<TournamentOutputModel, TournamentOutputType> FromModel { get; } =
            model => new TournamentOutputType() { Model = model };

        /// <summary>
        /// The tournament's unique identifier.
        /// </summary>
        public string Id => this.Model.Id.ToString();

        /// <summary>
        /// The tournament's start date.
        /// </summary>
        public string StartDate => this.Model.StartDate.ToString(CultureInfo.CurrentCulture);

        /// <summary>
        /// the tournament's end date.
        /// </summary>
        public string EndDate => this.Model.EndDate.ToString(CultureInfo.CurrentCulture);

        /// <summary>
        /// The tournament Frequency.
        /// </summary>
        public string Frequency => this.Model.Frequency.ToString();

        /// <summary>
        /// The tournament's venue.
        /// </summary>
        public string Venue => this.Model.Venue.ToString();

        internal TournamentOutputModel Model { get; set; }
    }
}