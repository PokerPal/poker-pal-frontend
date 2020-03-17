using System;

using Application.Models.Result;

namespace Api.ModelTypes.Result
{
    /// <summary>
    /// Data returned as the result of a tournament creation operation.
    /// </summary>
    public class CreateTournamentResultType
    {
        private readonly CreateTournamentResultModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTournamentResultType"/> class.
        /// </summary>
        /// <param name="model">The model to wrap.</param>
        public CreateTournamentResultType(CreateTournamentResultModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Converts an instance of the model <see cref="CreateTournamentResultModel"/> to this model TournamentType.
        /// </summary>
        public static Func<CreateTournamentResultModel, CreateTournamentResultType> FromModel { get; } =
            model => new CreateTournamentResultType(model);

        /// <summary>
        /// The unique identifier of the newly created Tournament.
        /// </summary>
        public int Id => this.model.Id;
    }
}