using System;

using Application.Models.Output;

namespace Api.ModelTypes.Output
{
    /// <summary>
    /// Details about a Badge.
    /// </summary>
    public class BadgeOutputType
    {
        /// <summary>
        /// Converts an instance of the model <see cref="BadgeOutputModel"/> to this model badgeType.
        /// </summary>
        public static Func<BadgeOutputModel, BadgeOutputType> FromModel { get; } =
            model => new BadgeOutputType { Model = model };

        /// <summary>
        /// The badge's unique identifier.
        /// </summary>
        public string Id => this.Model.Id.ToString();

        /// <summary>
        /// The badge's name.
        /// </summary>
        public string Name => this.Model.Name.ToString();

        /// <summary>
        /// Description of the badge.
        /// </summary>
        public string Description => this.Model.Description.ToString();

        /// <summary>
        /// The badge badgeType.
        /// </summary>
        public string Type => this.Model.Type.ToString();

        internal BadgeOutputModel Model { get; set; }
    }
}