// <copyright file="UsersController.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Interfaces;

namespace Api.Controllers
{
    /// <summary>
    /// Provides information about and actions on users.
    /// </summary>
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly IDatabaseContextFactory<DatabaseContext> databaseContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="databaseContextFactory">Factory for the database context.</param>
        public UsersController(IDatabaseContextFactory<DatabaseContext> databaseContextFactory)
        {
            this.databaseContextFactory = databaseContextFactory;
        }

        /// <summary>
        /// Create a new user with the provided details.
        /// </summary>
        [HttpPost("create")]
        public async void CreateUser()
        {
            await using var context = this.databaseContextFactory.CreateDatabaseContext();

            // TODO: Finish implementing CreateUser()
        }
    }
}