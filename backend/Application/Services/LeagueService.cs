using System;
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
                    .Map(l => new LeagueOutputModel(l.Id, l.Name, l.Type));
            }
        }

        /// <summary>
        /// Create a new league entity in the database.
        /// </summary>
        /// <param name="name">The name of the league.</param>
        /// <param name="type">The type of the league.</param>
        /// <returns>The result of the operation.</returns>
        public async Task<Result<CreateLeagueResultModel, string>> CreateLeague(string name, LeagueType type)
        {
            using (this.logger.BeginScope($"Creating new league \"{name}\"."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                var league = new LeagueEntity(default, name, type);

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
