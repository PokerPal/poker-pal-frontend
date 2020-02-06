// <copyright file="UserEntity.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Persistence.Entities
{
    /// <summary>
    /// The authorisation level of a user.
    /// </summary>
    public enum AuthLevel
    {
        /// <summary>
        /// Normal user authorisation level.
        /// </summary>
        User = 1,

        /// <summary>
        /// Administrator authorisation level.
        /// </summary>
        Admin,

        /// <summary>
        /// Super administrator authorisation level.
        /// </summary>
        SuperAdmin,
    }

    /// <summary>
    /// Represents a registered user in the database.
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserEntity"/> class.
        /// </summary>
        /// <param name="id">The user's unique identifier.</param>
        /// <param name="email">The user's registered email address.</param>
        /// <param name="name">The user's full name.</param>
        /// <param name="joined">The date and time the user joined.</param>
        /// <param name="authLevel">The user's authorisation level.</param>
        /// <param name="passwordHash">Hash of the user's password &amp; salt.</param>
        /// <param name="passwordSalt">Salt for the user's password hash.</param>
        public UserEntity(
            Guid id,
            string email,
            string name,
            DateTime joined,
            AuthLevel authLevel,
            string passwordHash,
            string passwordSalt)
        {
            this.Id = id;
            this.Email = email;
            this.Name = name;
            this.Joined = joined;
            this.AuthLevel = authLevel;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
        }

        /// <summary>
        /// Gets or sets this user's unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user's registered email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date and time the user signed up.
        /// </summary>
        public DateTime Joined { get; set; }

        /// <summary>
        /// Gets or sets the user's authorisation level within the system.
        /// </summary>
        public AuthLevel AuthLevel { get; set; }

        /// <summary>
        /// Gets or sets the hash of the user's password &amp; salt.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the salt (for computing and comparing against the user's password hash).
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the user-tournament relations this user belongs to; autofilled when fetched from the database,
        /// null otherwise.
        /// </summary>
        public IEnumerable<UserTournamentEntity>? UserTournaments { get; set; } = null;
    }
}