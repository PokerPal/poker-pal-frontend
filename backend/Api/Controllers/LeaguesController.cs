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
                    league.Name, league.Type))
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
    }
}
