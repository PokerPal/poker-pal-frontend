// <copyright file="BadgeService.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Models.Output;
using Application.Models.Result;
using Microsoft.Extensions.Logging;
using Persistence;
using Persistence.Entities;
using Persistence.Interfaces;

using Utility.ResultModel;

namespace Application.Services
{
    /// <summary>
    /// A service for performing operations on badges.
    /// </summary>
    public class BadgeService
    {
        private readonly IDatabaseContextFactory<DatabaseContext> databaseContextFactory;
        private readonly ILogger<UserService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeService"/> class.
        /// </summary>
        /// <param name="databaseContextFactory">Factory for the database context.</param>
        /// <param name="logger">Logger for messages.</param>
        public BadgeService(
            IDatabaseContextFactory<DatabaseContext> databaseContextFactory,
            ILogger<UserService> logger)
        {
            this.databaseContextFactory = databaseContextFactory;
            this.logger = logger;
        }

        /// <summary>
        /// Get the details of a Badge in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Badge.</param>
        /// <returns>The badge's information, if found.</returns>
        public async Task<Result<BadgeOutputModel, string>> GetBadgeAsync(int id)
        {
            await using var context = this.databaseContextFactory.CreateDatabaseContext();

            if (context.Badges == null)
            {
                this.logger.LogError($"Badge DB set was null when trying to get badge with id {id}.");
                return "Unable to access database.";
            }

            var badge = context.Badges.Find(id);

            if (badge == null)
            {
                return $"Badge with id {id} not found.";
            }

            return new BadgeOutputModel(badge.Id, badge.Name, badge.Description, badge.Type);
        }

        /// <summary>
        /// Get the badges a user has
        /// </summary>
        /// <param name="id">The users id.</param>
        /// <returns>Any badges the user has.</returns>
        public async Task<Result<List<BadgeOutputModel>, string>> GetUserBadges(int id)
        {
            await using var context = this.databaseContextFactory.CreateDatabaseContext();

            if (context.UserBadges == null)
            {
                this.logger.LogError($"UserBadges DB set was null when trying to get UserBadge with user id {id}.");
                return "Unable to access database.";
            }

            var badges = context.UserBadges.Where(ub => ub.UserId == id).ToList(); 
            if (badges.Count == 0)
            {
                return $"User with id {id} didnt have any badges.";
            }

            // var userBadges = new List<BadgeOutputModel>();
            // foreach (var badge in badges)
            //       {
            //            userBadges.Add(this.GetBadgeAsync(badge.BadgeId).Result.Value);
            //       }
            var userBadges = badges.Select(badge => this.GetBadgeAsync(badge.BadgeId).Result.Value).ToList();

            return userBadges;
        }

        /// <summary>
        /// Create a new badge entity in the database.
        /// </summary>
        /// <param name="name">The badge's name.</param>
        /// <param name="description">The badge's description.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Result<CreateBadgeResultModel, string>> CreateBadge(
            string name,
            string description)
        {
            await using var context = this.databaseContextFactory.CreateDatabaseContext();

            var badge = new BadgeEntity(
                0,
                name,
                description,
                Type.OptionA);

            if (context.Badges == null)
            {
                this.logger.LogError($"Badge DB set was null when trying to create badge.");
                return "Unable to access database.";
            }

            context.Badges.Add(badge);
            await context.SaveChangesAsync();

            return new CreateBadgeResultModel()
            {
                Id = badge.Id,
            };
        }
    }
}