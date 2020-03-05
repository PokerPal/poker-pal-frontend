// <copyright file="BadgeEntity.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Persistence.Entities
{
    /// <summary>
    /// Represents a Badge in the database.
    /// </summary>
    public class BadgeEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeEntity"/> class.
        /// </summary>
        /// <param name="id">The badge's unique identifier.</param>
        /// <param name="name">The badge's Name.</param>
        /// <param name="description">The badge's Description.</param>
        /// <param name="type">The badge's type.</param>
        public BadgeEntity(Guid id, string name, string description, int type)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets this badge's unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets this badge's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets this badge's Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of this badge.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the user-badge relations this badge belongs to; autofilled when fetched from the
        /// database, null otherwise.
        /// </summary>
        public List<UserBadgeEntity>? UserBadges { get; set; } = null;
    }
}