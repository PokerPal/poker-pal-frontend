using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Cryptography.Services;
using Application.Models.Output;
using Application.Models.Result;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Persistence;
using Persistence.Entities;
using Persistence.Interfaces;

using Utility.ResultModel;

namespace Application.Services
{
    /// <summary>
    /// Service for performing operations on users.
    /// </summary>
    public class UserService
    {
        private readonly ILogger<UserService> logger;
        private readonly IDatabaseContextFactory<DatabaseContext> databaseContextFactory;
        private readonly CryptoService cryptoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="logger">Logger for messages.</param>
        /// <param name="databaseContextFactory">Factory for the database context.</param>
        /// <param name="cryptoService">The cryptography service.</param>
        public UserService(
            ILogger<UserService> logger,
            IDatabaseContextFactory<DatabaseContext> databaseContextFactory,
            CryptoService cryptoService)
        {
            this.logger = logger;
            this.databaseContextFactory = databaseContextFactory;
            this.cryptoService = cryptoService;
        }

        /// <summary>
        /// Get the details of a user in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The user's details, if found.</returns>
        public async Task<Result<UserOutputModel, string>> GetUserAsync(int id)
        {
            using (this.logger.BeginScope($"Getting user with id {id}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                return Result<UserEntity, string>
                    .FromNullableOr(
                        await context.Users.FindAsync(id),
                        $"User with id {id} not found.")
                    .OnErr(e => this.logger.LogWarning(e))
                    .Map(u => new UserOutputModel(
                        u.Id, u.Email, u.Email, u.Joined, u.AuthLevel));
            }
        }

        /// <summary>
        /// Create a new user entity in the database.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="name">The new user's full name.</param>
        /// <param name="password">The user's chosen password.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.
        /// </returns>
        public async Task<Result<CreateUserResultModel, string>> CreateUserAsync(
            string email,
            string name,
            string password)
        {
            using (this.logger.BeginScope($"Creating new user with name {name}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                var salt = this.cryptoService.GenerateSalt();
                var hash = this.cryptoService.CalculateHash(password, salt);
                var compressedHash = this.cryptoService.CompressHash(salt, hash);

                var user = new UserEntity(
                    default,
                    email,
                    name,
                    DateTime.Now,
                    AuthLevel.User,
                    compressedHash);

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return new CreateUserResultModel
                {
                    Id = user.Id,
                };
            }
        }

        /// <summary>
        /// Get all of a user's badges.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>All of the user's badges.</returns>
        public async Task<Result<IEnumerable<BadgeOutputModel>, string>> GetUserBadges(int id)
        {
            using (this.logger.BeginScope($"Getting badges for user with id {id}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                var user = await context.Users
                    .Include(u => u.UserBadges)
                    .ThenInclude(ub => ub.Badge)
                    .SingleOrDefaultAsync(u => u.Id == id);

                return Result<UserEntity, string>
                    .FromNullableOr(user, $"User with id {id} not found.")
                    .OnErr(e => this.logger.LogWarning(e))
                    .Map(u => u.UserBadges
                        .Select(ub => ub.Badge)
                        .Select(b => new BadgeOutputModel(
                            b.Id, b.Name, b.Description, b.Type)));
            }
        }

        /// <summary>
        /// Create a link between a given user and a given badge.
        /// </summary>
        /// <param name="userId">The userID to link.</param>
        /// <param name="badgeId">The badgeID to link.</param>
        /// <returns>The outcome of the operation.</returns>
        public async Task<Result<CreateUserBadgeResultModel, string>> AddBadge(
            int userId,
            int badgeId)
        {
            using (this.logger.BeginScope(
                $"Giving badge with id {badgeId} to user with id {userId}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                if (await context.Users.FindAsync(userId) == null)
                {
                    return Result
                        .Err($"User with id {userId} not found.")
                        .OnErr(e => this.logger.LogWarning(e));
                }

                if (await context.Badges.FindAsync(badgeId) == null)
                {
                    return Result
                        .Err($"Badge with id {badgeId} not found.")
                        .OnErr(e => this.logger.LogWarning(e));
                }

                if (await context.UserBadges.FindAsync(userId, badgeId) != null)
                {
                    return Result
                        .Err($"User with id {userId} already has badge with id {badgeId}.")
                        .OnErr(e => this.logger.LogWarning(e));
                }

                await context.UserBadges.AddAsync(new UserBadgeEntity(userId, badgeId));
                await context.SaveChangesAsync();

                return new CreateUserBadgeResultModel
                {
                    BadgeId = badgeId,
                    UserId = userId,
                };
            }
        }
    }
}
