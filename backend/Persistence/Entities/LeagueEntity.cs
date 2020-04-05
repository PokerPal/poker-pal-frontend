using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    /// <summary>
    /// Represents a league in the database.
    /// </summary>
    public class LeagueEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueEntity"/> class.
        /// </summary>
        /// <param name="id">The league's unique identifier.</param>
        /// <param name="name">The league's name.</param>
        public LeagueEntity(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets this league's unique identifier.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets this league's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of sessions that have occurred in this league; autofilled when
        /// fetched from the database, null otherwise.
        /// </summary>
        public virtual List<SessionEntity> Sessions { get; set; } = null;
    }
}
