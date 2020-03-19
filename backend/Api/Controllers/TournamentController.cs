using System.Threading.Tasks;

using Api.ModelTypes.Input;
using Api.ModelTypes.Output;
using Api.ModelTypes.Result;

using Application.Models.Output;
using Application.Services;

using Microsoft.AspNetCore.Mvc;

using Utility.ResultModel;

namespace Api.Controllers
{
    /// <summary>
    /// Provides an interface to performing operations on and retrieving information about
    /// tournaments.
    /// </summary>
    [ApiController]
    [Route("tournaments")]
    public class TournamentController : ControllerBase
    {
        /// <summary>
        /// Create a new tournament with the provided details.
        /// </summary>
        /// <param name="tournament">Details of the tournament to create.</param>
        /// <param name="tournamentService">The tournament service.</param>
        /// <returns>The result of the creation of the tournament.</returns>
        [HttpPost("")]
        public async Task<ActionResult<Result<CreateTournamentResultType, string>>>
            CreateTournament(
                [FromBody] CreateTournamentInputType tournament,
                [FromServices] TournamentService tournamentService)
        {
            return (await tournamentService.CreateTournament(
                    tournament.StartDate,
                    tournament.EndDate,
                    tournament.Frequency,
                    tournament.Venue))
                .Map(CreateTournamentResultType.FromModel);
        }

        /// <summary>
        /// Get the details of the tournament with provided id.
        /// </summary>
        /// <param name="id">The unique identifier of the tournament.</param>
        /// <param name="tournamentService">The tournament service.</param>
        /// <returns>The details of the tournament.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<TournamentOutputType, string>>> GetTournament(
            [FromRoute] int id,
            [FromServices] TournamentService tournamentService)
        {
            return (await tournamentService.GetTournamentAsync(id))
                .Map(TournamentOutputType.FromModel)
                .WrapSplit<ActionResult>(this.Ok, this.NotFound);
        }
    }
}
