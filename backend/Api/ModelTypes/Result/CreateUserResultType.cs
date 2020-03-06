// <copyright file="CreateUserResultType.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using System;
using Application.Models.Result;

namespace Api.ModelTypes.Result
{
    /// <summary>
    /// Data returned as the result of a user creation operation.
    /// </summary>
    public class CreateUserResultType
    {
        private readonly CreateUserResultModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserResultType"/> class.
        /// </summary>
        /// <param name="model">The model to wrap.</param>
        public CreateUserResultType(CreateUserResultModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Converts an instance of the model <see cref="CreateUserResultModel"/> to this model type.
        /// </summary>
        public static Func<CreateUserResultModel, CreateUserResultType> FromModel { get; } =
            model => new CreateUserResultType(model);

        /// <summary>
        /// The unique identifier of the newly created user.
        /// </summary>
        public int Id => this.model.Id;
    }
}