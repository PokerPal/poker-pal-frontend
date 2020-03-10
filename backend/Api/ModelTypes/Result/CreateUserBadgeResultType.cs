using System;

using Application.Models.Result;

namespace Api.ModelTypes.Result
{
    /// <summary>
    /// Data returned as the result of a Badge creation operation.
    /// </summary>
    public class CreateUserBadgeResultType
    {
        private readonly CreateUserBadgeResultModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserBadgeResultType"/> class.
        /// </summary>
        /// <param name="model">The model to wrap.</param>
        public CreateUserBadgeResultType(CreateUserBadgeResultModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Converts an instance of the model <see cref="CreateUserBadgeResultModel"/> to this model type.
        /// </summary>
        public static Func<CreateUserBadgeResultModel, CreateUserBadgeResultType> FromModel { get; } =
            model => new CreateUserBadgeResultType(model);

        /// <summary>
        /// The unique identifier of the badge.
        /// </summary>
        public int BadgeId => this.model.BadgeId;

        /// <summary>
        /// The unique identifier of the User.
        /// </summary>
        public int UserId => this.model.UserId;
    }
}