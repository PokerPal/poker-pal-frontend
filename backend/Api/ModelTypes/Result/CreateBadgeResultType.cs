using System;

using Application.Models.Result;

namespace Api.ModelTypes.Result
{
    /// <summary>
    /// Data returned as the result of a Badge creation operation.
    /// </summary>
    public class CreateBadgeResultType
    {
        private readonly CreateBadgeResultModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBadgeResultType"/> class.
        /// </summary>
        /// <param name="model">The model to wrap.</param>
        public CreateBadgeResultType(CreateBadgeResultModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Converts an instance of the model <see cref="CreateBadgeResultModel"/> to this model badgeType.
        /// </summary>
        public static Func<CreateBadgeResultModel, CreateBadgeResultType> FromModel { get; } =
            model => new CreateBadgeResultType(model);

        /// <summary>
        /// The unique identifier of the newly created badge.
        /// </summary>
        public int Id => this.model.Id;
    }
}