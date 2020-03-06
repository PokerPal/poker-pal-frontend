// <copyright file="UserBadgeEntity.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using System;

namespace Persistence.Entities
{
    /// <summary>
    /// Represents a link between a user and a badge in the database.
    /// </summary>
    public class UserBadgeEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserBadgeEntity"/> class.
        /// </summary>
        /// <param name="userId">The unique identifier of the linked user.</param>
        /// <param name="badgeId">The unique identifier of the linked badge.</param>
        public UserBadgeEntity(int userId, Guid badgeId)
        {
            this.UserId = userId;
            this.BadgeId = badgeId;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the linked user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the linked badge.
        /// </summary>
        public Guid BadgeId { get; set; }

        /// <summary>
        /// Gets or sets the user entity linked to this entity; autofilled when fetched from the database, null
        /// otherwise.
        /// </summary>
        public UserEntity User { get; set; } = null;

        /// <summary>
        /// Gets or sets the badge entity linked to this entity; autofilled when fetched from the database, null
        /// otherwise.
        /// </summary>
        public BadgeEntity Badge { get; set; } = null;
    }
}