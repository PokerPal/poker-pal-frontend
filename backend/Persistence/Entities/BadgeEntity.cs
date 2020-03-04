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
        /// <param name="badgeName">The badge's Name.</param>
        /// <param name="badgeDescription">The badge's Description.</param>
        /// <param name="badgeType">The badge's type.</param>
        public BadgeEntity(Guid id, string badgeName, string badgeDescription, int badgeType)
        {
            this.Id = id;
            this.BadgeName = badgeName;
            this.BadgeDescription = badgeDescription;
            this.BadgeType = badgeType;
        }

        /// <summary>
        /// Gets or sets this badge's unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets this badge's name.
        /// </summary>
        public string BadgeName { get; set; }

        /// <summary>
        /// Gets or sets this badge's Description.
        /// </summary>
        public string BadgeDescription { get; set; }

        /// <summary>
        /// Gets or sets the type of this badge.
        /// </summary>
        public int BadgeType { get; set; }

        /// <summary>
        /// Gets or sets the user-badge relations this badge belongs to; autofilled when fetched from the
        /// database, null otherwise.
        /// </summary>
        public List<UserBadgeEntity>? UserBadges { get; set; } = null;
    }
}