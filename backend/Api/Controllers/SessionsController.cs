using System.Threading.Tasks;

using Api.ModelTypes.Input;
using Api.ModelTypes.Output;
using Api.ModelTypes.Result;

using Application.Services;

using Microsoft.AspNetCore.Mvc;

using Utility.ResultModel;

namespace Api.Controllers
{
    /// <summary>
    /// Provides an interface to performing operations on and retrieving information about
    /// sessions.
    /// </summary>
    [ApiController]
    [Route("sessions")]
    public class SessionsController : ControllerBase
    {
        /// <summary>
        /// Create a new session with the provided details.
        /// </summary>
        /// <param name="session">Details of the session to create.</param>
        /// <param name="sessionService">The session service.</param>
        /// <returns>The result of the creation of the session.</returns>
        [HttpPost("")]
        public async Task<ActionResult<Result<CreateSessionResultType, string>>>
            CreateSession(
                [FromBody] CreateSessionInputType session,
                [FromServices] SessionService sessionService)
        {
            return (await sessionService.CreateSession(
                    session.StartDate,
                    session.EndDate,
                    session.Frequency,
                    session.Venue,
                    session.LeagueId))
                .Map(CreateSessionResultType.FromModel);
        }

        /// <summary>
        /// Get the details of the session with provided id.
        /// </summary>
        /// <param name="id">The unique identifier of the session.</param>
        /// <param name="sessionService">The session service.</param>
        /// <returns>The details of the session.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<SessionOutputType, string>>> GetSession(
            [FromRoute] int id,
            [FromServices] SessionService sessionService)
        {
            return (await sessionService.GetSessionAsync(id))
                .Map(SessionOutputType.FromModel)
                .WrapSplit<ActionResult>(this.Ok, this.NotFound);
        }
    }
}
