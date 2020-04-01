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
        private readonly LeagueService leagueService;
        private readonly ILogger<SessionService> logger;
        private readonly IDatabaseContextFactory<DatabaseContext> databaseContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionService"/> class.
        /// </summary>
        /// <param name="leagueService">The league service.</param>
        /// <param name="logger">Logger for messages.</param>
        /// <param name="databaseContextFactory">Factory for the database context.</param>
        public SessionService(
            LeagueService leagueService,
            ILogger<SessionService> logger,
            IDatabaseContextFactory<DatabaseContext> databaseContextFactory)
        {
            this.leagueService = leagueService;
            this.logger = logger;
            this.databaseContextFactory = databaseContextFactory;
        }

        /// <summary>
        /// Get the details of a session in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the session.</param>
        /// <returns>The session's information, if found.</returns>
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
        /// <param name="leagueId">The ID of the league the session belongs to.</param>
        /// <returns>The result of the operation.</returns>
        public async Task<Result<CreateSessionResultModel, string>> CreateSession(
            DateTime startDate,
            DateTime endDate,
            int? frequency,
            string venue,
            int leagueId)
        {
            using (this.logger.BeginScope($"Creating new session with start date {startDate}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                return await (await this.leagueService.GetLeagueAsync(leagueId))
                    .OnErr(e => this.logger.LogWarning(e))
                    .AndThenAsync<CreateSessionResultModel>(async _ =>
                    {
                        var session = new SessionEntity(
                            default,
                            startDate,
                            endDate,
                            frequency,
                            venue,
                            leagueId);

                        await context.Sessions.AddAsync(session);
                        await context.SaveChangesAsync();

                        return new CreateSessionResultModel
                        {
                            Id = session.Id,
                        };
                    });
            }
        }

        /// <summary>
        /// Create a link between a given user and a given session.
        /// </summary>
        /// <param name="userId">The userID to link.</param>
        /// <param name="sessionId">The sessionID to link.</param>
        /// <param name="totalScore">The users score in the session.</param>
        /// <returns>The outcome of the operation.</returns>
        public async Task<Result<CreateUserSessionResultModel, string>> AddUser(
            int userId,
            int sessionId,
            int totalScore)
        {
            using (this.logger.BeginScope(
                $"Adding user with id {userId} to session with id {sessionId}."))
            {
                await using var context = this.databaseContextFactory.CreateDatabaseContext();

                if (await context.Users.FindAsync(userId) == null)
                {
                    return Result
                        .Err($"User not found.")
                        .OnErr(e => this.logger.LogWarning(e));
                }

                if (await context.Sessions.FindAsync(sessionId) == null)
                {
                    return Result
                        .Err($"Session not found.")
                        .OnErr(e => this.logger.LogWarning(e));
                }

                if (await context.UserBadges.FindAsync(userId, sessionId) != null)
                {
                    return Result
                        .Err($"User already has information within session with id {sessionId}.")
                        .OnErr(e => this.logger.LogWarning(e));
                }

                await context.UserSessions.AddAsync(new UserSessionEntity(userId, sessionId, totalScore));
                await context.SaveChangesAsync();

                return new CreateUserSessionResultModel()
                {
                    UserId = userId,
                    SessionId = sessionId,
                };
            }
        }
    }
}
