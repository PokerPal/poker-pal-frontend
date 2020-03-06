// <copyright file="UserTournamentEntity.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using System;

namespace Persistence.Entities
{
    /// <summary>
    /// Represents a link between a user and a tournament in the database.
    /// </summary>
    public class UserTournamentEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserTournamentEntity"/> class.
        /// </summary>
        /// <param name="userId">The unique identifier of the linked user.</param>
        /// <param name="tournamentId">The unique identifier of the linked tournament.</param>
        /// <param name="totalScore">The total score of the user in this tournament.</param>
        public UserTournamentEntity(int userId, Guid tournamentId, int totalScore)
        {
            this.UserId = userId;
            this.TournamentId = tournamentId;
            this.TotalScore = totalScore;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the linked user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the linked tournament.
        /// </summary>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Gets or sets the total score of the user in this tournament.
        /// </summary>
        public int TotalScore { get; set; }

        /// <summary>
        /// Gets or sets the user entity linked to this entity; autofilled when fetched from the database, null
        /// otherwise.
        /// </summary>
        public UserEntity User { get; set; } = null;

        /// <summary>
        /// Gets or sets the tournament entity linked to this entity; autofilled when fetched from the database, null
        /// otherwise.
        /// </summary>
        public TournamentEntity Tournament { get; set; } = null;
    }
}