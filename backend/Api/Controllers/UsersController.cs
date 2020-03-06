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
    /// Provides an interface to performing operations on and retrieving information about users.
    /// </summary>
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Create a new user with the provided details.
        /// </summary>
        /// <param name="user">Details of the user to create.</param>
        /// <returns>The result of the creation of the user.</returns>
        [HttpPost]
        public async Task<ActionResult<Result<CreateUserResultType, string>>> CreateUser(
            [FromBody] CreateUserInputType user)
        {
            return (await this.userService.CreateUserAsync(user.Email, user.Name, user.Password))
                .Map(CreateUserResultType.FromModel);
        }

        /// <summary>
        /// Get the details of the user with the provided ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The details of the user.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<UserOutputType, string>>> GetUser(int id)
        {
            return (await this.userService.GetUserAsync(id))
                .Map(UserOutputType.FromModel)
                .WrapSplit<ActionResult>(this.Ok, this.NotFound);
        }
    }
}