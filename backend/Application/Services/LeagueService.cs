using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    /// A service for performing operations on leagues.
    /// </summary>
    public class LeagueService
    {
        private readonly ILogger<LeagueService> logger;
        private readonly IDatabaseContextFactory<DatabaseContext> databaseContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueService"/> class.
        /// </summary>
        /// <param name="databaseContextFactory">Factory for the database context.</param>
        /// <param name="logger">Logger for messages.</param>
        public LeagueService(
            ILogger<LeagueService> logger,
            IDatabaseContextFactory<DatabaseContext> databaseContextFactory)
        {
            this.logger = logger;
            this.databaseContextFactory = databaseContextFactory;
        }

        /// <summary>
        /// Get the details of a league in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the league.</param>
        /// <returns>The league's information, if found.</returns>
        public async Task<Result<LeagueOutputModel, string>> GetLeagueAsync(int id)
        {
            using (this.logger.BeginScope($"Getting league with id {id}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                return Result<LeagueEntity, string>
                    .FromNullableOr(
                        await context.Leagues.FindAsync(id),
                        $"League with id {id} not found.")
                    .OnErr(e => this.logger.LogWarning(e))
                    .Map(t => new LeagueOutputModel(t.Id, t.Name, t.StartingAmount, t.AllowChanges));
            }
        }

        /// <summary>
        /// Get all the user leagues within a league.
        /// </summary>
        /// <param name="id">The leagues id.</param>
        /// <returns>All of the user leagues associated with a league.</returns>
        public async Task<Result<IEnumerable<UserLeagueEntity>, string>> GetUserLeagues(int id)
        {
            using (this.logger.BeginScope($"Getting user leagues associated with league: {id}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                var league = await context.Leagues
                    .Include(l => l.UserLeagues)
                    .SingleOrDefaultAsync(l => l.Id == id);

                return Result<LeagueEntity, string>
                    .FromNullableOr(league, "league not found.")
                    .OnErr(e => this.logger.LogWarning(e))
                    .Map(l => l.UserLeagues
                        .Select(ul => new UserLeagueEntity(ul.UserId, ul.LeagueId, ul.TotalStore)));
            }
        }

        /// <summary>
        /// Get the details of a user league in the database.
        /// </summary>
        /// <param name="leagueId">The leagues unique id.</param>
        /// <param name="userId">The users unique id.</param>
        /// <returns>The user league's information, if found.</returns>
        public async Task<Result<UserLeagueOutputModel, string>> GetUserLeague(int leagueId, int userId)
        {
            using (this.logger.BeginScope($"Getting user league with league id {leagueId} and user Id {userId}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                return Result<UserLeagueEntity, string>
                    .FromNullableOr(
                        await context.UserLeagues.FindAsync(leagueId, userId),
                        $"User league with league id {leagueId} and user Id {userId} not found.")
                    .OnErr(e => this.logger.LogWarning(e))
                    .Map(ul => new UserLeagueOutputModel(ul.UserId, ul.LeagueId, ul.TotalStore));
            }
        }

        /// <summary>
        /// Create a new league entity in the database.
        /// </summary>
        /// <param name="name">The name of the league.</param>
        /// <param name="startingAmount">The starting amount for users in the league.</param>
        /// <param name="allowChanges">Whether or not entities linked to this league can be changed.</param>
        /// <returns>The result of the operation.</returns>
        public async Task<Result<CreateLeagueResultModel, string>> CreateLeague(string name, int startingAmount, bool allowChanges)
        {
            using (this.logger.BeginScope($"Creating new league \"{name}\"."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                var league = new LeagueEntity(default, name, startingAmount, allowChanges);

                await context.Leagues.AddAsync(league);
                await context.SaveChangesAsync();

                return new CreateLeagueResultModel
                {
                    Id = league.Id,
                };
            }
        }
    }
}
