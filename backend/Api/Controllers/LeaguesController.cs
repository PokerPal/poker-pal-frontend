using System.Collections.Generic;
using System.Linq;
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
    /// Provides an interface to performing operations on and retrieving information about leagues.
    /// </summary>
    [ApiController]
    [Route("leagues")]
    public class LeaguesController : ControllerBase
    {
        /// <summary>
        /// Create a new league with the provided details.
        /// </summary>
        /// <param name="league">Details of the league to create.</param>
        /// <param name="leagueService">The league service.</param>
        /// <returns>The result of the creation of the league.</returns>
        [HttpPost]
        public async Task<ActionResult<Result<CreateLeagueResultType, string>>> CreateLeague(
            [FromBody] CreateLeagueInputType league,
            [FromServices] LeagueService leagueService)
        {
            return (await leagueService.CreateLeague(
                    league.Name, league.StartingAmount, league.AllowChanges, league.Type))
                .Map(CreateLeagueResultType.FromModel);
        }

        /// <summary>
        /// Get the details of the league with provided id.
        /// </summary>
        /// <param name="id">The unique identifier of the league.</param>
        /// <param name="leagueService">The league service.</param>
        /// <returns>The details of the league.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<LeagueOutputType, string>>> GetLeague(
            [FromRoute] int id,
            [FromServices] LeagueService leagueService)
        {
            return (await leagueService.GetLeagueAsync(id))
                .Map(LeagueOutputType.FromModel)
                .WrapSplit<ActionResult>(this.Ok, this.NotFound);
        }

        /// <summary>
        /// Get the details of the user leagues within this league.
        /// </summary>
        /// <param name="leagueId">The unique identifier of the league.</param>
        /// <param name="userId">The information of the user.</param>
        /// <param name="leagueService">The league service.</param>
        /// <returns>The details of the user leagues within the league.</returns>
        [HttpGet("{leagueId}/user/{userId}")]
        public async Task<ActionResult<Result<UserLeagueOutputType, string>>> GetUserLeague(
            [FromRoute] int leagueId,
            [FromRoute] int userId,
            [FromServices] LeagueService leagueService)
        {
            return (await leagueService.GetUserLeague(leagueId, userId))
                .Map(UserLeagueOutputType.FromModel)
                .WrapSplit<ActionResult>(this.Ok, this.NotFound);
        }

        /// <summary>
        /// Get the details of a user league within this league.
        /// </summary>
        /// <param name="id">The unique identifier of the league.</param>
        /// <param name="leagueService">The league service.</param>
        /// <returns>The details of the user leagues within the league.</returns>
        [HttpGet("{id}/users")]
        public async Task<ActionResult<Result<IEnumerable<UserLeagueOutputType>, string>>> GetUsersLeagues(
            [FromRoute] int id,
            [FromServices] LeagueService leagueService)
        {
            return (await leagueService.GetUserLeagues(id))
                .Map(models => models
                    .Select(model => UserLeagueOutputType.FromModel(model))
                    .ToList())
                .WrapSplit<ActionResult>(this.Ok, this.NotFound);
        }
    }
}
