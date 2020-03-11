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
                this.logger.LogError(
                    $"Badge DB set was null when trying to get badge with id {id}.");
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
        /// Get the badges a user has.
        /// </summary>
        /// <param name="id">The users id.</param>
        /// <returns>Any badges the user has.</returns>
        public async Task<Result<IEnumerable<BadgeOutputModel>, string>> GetUserBadges(int id)
        {
            await using var context = this.databaseContextFactory.CreateDatabaseContext();

            if (context.UserBadges == null)
            {
                this.logger.LogError(
                    $"UserBadges DB set was null when trying to get UserBadge with user id {id}.");
                return "Unable to access database.";
            }

            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                return $"Unable to find user with id {id}.";
            }

            return Result.Ok(user.UserBadges
                .Select(ub => ub.Badge)
                .Select(badge => new BadgeOutputModel(
                    badge.Id,
                    badge.Name,
                    badge.Description,
                    badge.Type)));
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
                BadgeType.OptionA);

            if (context.Badges == null)
            {
                this.logger.LogError($"Badge DB set was null when trying to create badge.");
                return "Unable to access database.";
            }

            await context.Badges.AddAsync(badge);
            await context.SaveChangesAsync();

            return new CreateBadgeResultModel()
            {
                Id = badge.Id,
            };
        }

        /// <summary>
        /// Create a link between a given user and a given badge.
        /// </summary>
        /// <param name="badgeId">The badgeID to link.</param>
        /// <param name="userId">The userID to link.</param>
        /// <returns>The outcome of the operation.</returns>
        public async Task<Result<CreateUserBadgeResultModel, string>> CreateUserBadge(
            int badgeId,
            int userId)
        {
            await using var context = this.databaseContextFactory.CreateDatabaseContext();

            if (context.Badges == null)
            {
                this.logger.LogError($"Badge DB set was null when trying to create badge.");
                return "Unable to access database.";
            }

            if (context.Badges == null || context.Users == null)
            {
                this.logger.LogError(
                    $"Badge DB or User DB set was null when trying to create the Link.");
                return "Unable to access database.";
            }

            if (await context.Badges.FindAsync(badgeId) == null ||
                await context.Users.FindAsync(userId) == null)
            {
                return "Badge not found or user not found";
            }

            if (await context.UserBadges.FindAsync(userId, badgeId) != null)
            {
                return "This link already exists";
            }

            var userBadge = new UserBadgeEntity(
                userId,
                badgeId);

            await context.UserBadges.AddAsync(userBadge);
            await context.SaveChangesAsync();

            return new CreateUserBadgeResultModel()
            {
                BadgeId = badgeId,
                UserId = userId,
            };
        }
    }
}
