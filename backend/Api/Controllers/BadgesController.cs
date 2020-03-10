using System.Collections.Generic;
using System.Linq;
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
    /// Provides an interface to performing operations on and retrieving information about badges.
    /// </summary>
    [ApiController]
    [Route("/controller")]
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
        [HttpPost("/controller/b")]
        public async Task<ActionResult<Result<CreateBadgeResultType, string>>> CreateBadge(
            [FromBody] CreateBadgeInputType badge)
        {
            return (await this.badgeService.CreateBadge(badge.Name, badge.Description))
                .Map(CreateBadgeResultType.FromModel);
        }

        /// <summary>
        /// Create a new UserBadge with provided ids.
        /// </summary>
        /// <param name="badgeId">The badge id to be used.</param>
        /// <param name="userId">The user id to be used.</param>
        /// <returns>The result of the operation.</returns>
        [HttpPost("/controller/ub")]
        public async Task<ActionResult<Result<CreateUserBadgeResultType, string>>> CreateUserBadge(int badgeId, int userId)
        {
            return (await this.badgeService.CreateUserBadge(badgeId, userId))
                .Map(CreateUserBadgeResultType.FromModel);
        }

        /// <summary>
        /// Get the details of the badge with provided id.
        /// </summary>
        /// <param name="id">The unique identifier of the badge.</param>
        /// <returns>The details of the badge.</returns>
        [HttpGet("id")]
        public async Task<ActionResult<Result<BadgeOutputType, string>>> GetBadge(int id)
        {
            return (await this.badgeService.GetBadgeAsync(id))
                .Map(BadgeOutputType.FromModel)
                .WrapSplit<ActionResult>(this.Ok, this.NotFound);
        }

        /// <summary>
        /// Get the badges a user has.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The badges the user has.</returns>
        [HttpGet("uid")]
        public async Task<ActionResult<Result<List<BadgeOutputType>, string>>> GetUserBadges(int id)
        {
            return (await this.badgeService.GetUserBadges(id))
                .Map(tValue =>
                {
                    var uValue = new List<BadgeOutputType>();
                    foreach (var val in tValue)
                    {
                        uValue.Add(BadgeOutputType.FromModel(val));
                    }

                    return uValue;
                })
                .WrapSplit<ActionResult>(this.Ok, this.NotFound);
        }
    }
}