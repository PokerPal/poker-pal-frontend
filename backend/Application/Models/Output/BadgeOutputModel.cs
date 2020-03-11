using Persistence.Entities;

namespace Application.Models.Output
{
    /// <summary>
    /// Represents details about a badge.
    /// </summary>
    public class BadgeOutputModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeOutputModel"/> class.
        /// </summary>
        /// <param name="id">The badge's unique identifier.</param>
        /// <param name="name">The badge's name.</param>
        /// <param name="description">The badge's description.</param>
        /// <param name="type">The badge's type.</param>
        public BadgeOutputModel(int id, string name, string description, BadgeType type)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
        }

        /// <summary>
        /// The badge's unique identifier.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The badge's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Description of the badge.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The badge badgeType.
        /// </summary>
        public BadgeType Type { get; }
    }
}