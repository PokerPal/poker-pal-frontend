using System.Threading.Tasks;

using Api.ModelTypes.Input;
using Api.ModelTypes.Output;
using Api.ModelTypes.Result;

using Application.Services;

using Microsoft.AspNetCore.Mvc;

using Persistence.Entities;

using Utility.ResultModel;

namespace Api.Controllers
{
    /// <summary>
    /// Provides an interface to performing operations on and retrieving information about badges.
    /// </summary>
    [ApiController]
    [Route("/badges")]
    public class BadgesController : ControllerBase
    {
        private readonly BadgeService badgeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BadgesController"/> class.
        /// </summary>
        /// <param name="badgeService">The badge service.</param>
        public BadgesController(BadgeService badgeService)
        {
            this.badgeService = badgeService;
        }

        /// <summary>
        /// Create a new badge with the provided details.
        /// </summary>
        /// <param name="badge">Details of the badge to create.</param>
        /// <returns>The result of the creation of the badge.</returns>
        [HttpPost]
        public async Task<ActionResult<Result<CreateBadgeResultType, string>>> CreateBadge(
            [FromBody] CreateBadgeInputType badge)
        {
            return (await this.badgeService.CreateBadge(badge.Name, badge.Description))
                .Map(CreateBadgeResultType.FromModel);
        }

        /// <summary>
        /// Get the details of the badge with provided id.
        /// </summary>
        /// <param name="id">The unique identifier of the badge.</param>
        /// <returns>The details of the badge.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<BadgeOutputType, string>>> GetBadge(int id)
        {
            return (await this.badgeService.GetBadgeAsync(id))
                .Map(BadgeOutputType.FromModel)
                .WrapSplit<ActionResult>(this.Ok, this.NotFound);
        }
    }
}