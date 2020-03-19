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
    /// A service for performing operations on Tournaments.
    /// </summary>
    public class TournamentService
    {
        private readonly ILogger<TournamentService> logger;
        private readonly IDatabaseContextFactory<DatabaseContext> databaseContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentService"/> class.
        /// </summary>
        /// <param name="databaseContextFactory">Factory for the database context.</param>
        /// <param name="logger">Logger for messages.</param>
        public TournamentService(
            ILogger<TournamentService> logger,
            IDatabaseContextFactory<DatabaseContext> databaseContextFactory)
        {
            this.logger = logger;
            this.databaseContextFactory = databaseContextFactory;
        }

        /// <summary>
        /// Get the details of a tournament in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the badge.</param>
        /// <returns>The badge's information, if found.</returns>
        public async Task<Result<TournamentOutputModel, string>> GetTournamentAsync(int id)
        {
            using (this.logger.BeginScope($"Getting Tournament with id {id}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                return Result<TournamentEntity, string>
                    .FromNullableOr(
                        await context.Tournaments.FindAsync(id),
                        $"Tournament with id {id} not found.")
                    .OnErr(e => this.logger.LogWarning(e))
                    .Map(t => new TournamentOutputModel(
                        t.Id, t.StartDate, t.EndDate, t.Frequency, t.Venue));
            }
        }

        /// <summary>
        /// Create a new tournament entity in the database.
        /// </summary>
        /// <param name="startDate">The starting date of the tournament.</param>
        /// <param name="endDate">The ending date of the tournament.</param>
        /// <param name="frequency">How often the tournament occurs.</param>
        /// <param name="venue">The venue of the tournament.</param>
        /// <returns>The result of the operation.</returns>
        public async Task<Result<CreateTournamentResultModel, string>> CreateTournament(
            DateTime startDate,
            DateTime endDate,
            int? frequency,
            string venue)
        {
            using (this.logger.BeginScope($"Creating new tournament with start date {startDate}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();
                var tournament = new TournamentEntity(
                    default,
                    startDate,
                    endDate,
                    frequency,
                    venue);
                await context.Tournaments.AddAsync(tournament);
                await context.SaveChangesAsync();

                return new CreateTournamentResultModel()
                {
                    Id = tournament.Id,
                };
            }
        }
    }
}
