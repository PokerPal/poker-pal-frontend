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
    /// A service for performing operations on sessions.
    /// </summary>
    public class SessionService
    {
        private readonly ILogger<SessionService> logger;
        private readonly IDatabaseContextFactory<DatabaseContext> databaseContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionService"/> class.
        /// </summary>
        /// <param name="databaseContextFactory">Factory for the database context.</param>
        /// <param name="logger">Logger for messages.</param>
        public SessionService(
            ILogger<SessionService> logger,
            IDatabaseContextFactory<DatabaseContext> databaseContextFactory)
        {
            this.logger = logger;
            this.databaseContextFactory = databaseContextFactory;
        }

        /// <summary>
        /// Get the details of a session in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the badge.</param>
        /// <returns>The badge's information, if found.</returns>
        public async Task<Result<SessionOutputModel, string>> GetSessionAsync(int id)
        {
            using (this.logger.BeginScope($"Getting session with id {id}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                return Result<SessionEntity, string>
                    .FromNullableOr(
                        await context.Sessions.FindAsync(id),
                        $"Session with id {id} not found.")
                    .OnErr(e => this.logger.LogWarning(e))
                    .Map(t => new SessionOutputModel(
                        t.Id, t.StartDate, t.EndDate, t.Frequency, t.Venue));
            }
        }

        /// <summary>
        /// Create a new session entity in the database.
        /// </summary>
        /// <param name="startDate">The starting date of the session.</param>
        /// <param name="endDate">The ending date of the session.</param>
        /// <param name="frequency">How often the session occurs.</param>
        /// <param name="venue">The venue of the session.</param>
        /// <returns>The result of the operation.</returns>
        public async Task<Result<CreateSessionResultModel, string>> CreateSession(
            DateTime startDate,
            DateTime endDate,
            int? frequency,
            string venue)
        {
            using (this.logger.BeginScope($"Creating new session with start date {startDate}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();
                var session = new SessionEntity(
                    default,
                    startDate,
                    endDate,
                    frequency,
                    venue);
                await context.Sessions.AddAsync(session);
                await context.SaveChangesAsync();

                return new CreateSessionResultModel()
                {
                    Id = session.Id,
                };
            }
        }
    }
}
