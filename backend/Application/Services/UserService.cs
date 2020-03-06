// <copyright file="UserService.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Application.Cryptography.Services;
using Application.Models.Output;
using Application.Models.Result;
using Microsoft.Extensions.Logging;
using Persistence;
using Persistence.Entities;
using Persistence.Interfaces;
using Utility;
using Utility.ResultModel;

namespace Application.Services
{
    /// <summary>
    /// Service for performing operations on users.
    /// </summary>
    public class UserService
    {
        private readonly CryptoService cryptoService;
        private readonly IDatabaseContextFactory<DatabaseContext> databaseContextFactory;
        private readonly ILogger<UserService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="cryptoService">The cryptography service.</param>
        /// <param name="databaseContextFactory">Factory for the database context.</param>
        /// <param name="logger">Logger for messages.</param>
        public UserService(
            CryptoService cryptoService,
            IDatabaseContextFactory<DatabaseContext> databaseContextFactory,
            ILogger<UserService> logger)
        {
            this.cryptoService = cryptoService;
            this.databaseContextFactory = databaseContextFactory;
            this.logger = logger;
        }

        /// <summary>
        /// Get the details of a user in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The user's details, if found.</returns>
        public async Task<Result<UserOutputModel, string>> GetUserAsync(int id)
        {
            await using var context = this.databaseContextFactory.CreateDatabaseContext();

            if (context.Users == null)
            {
                this.logger.LogError($"Users DB set was null when trying to get user with id {id}.");
                return "Unable to access database.";
            }

            var user = context.Users.Find(id);

            if (user == null)
            {
                return $"User with id {id} not found.";
            }

            return new UserOutputModel(user.Id, user.Email, user.Name, user.Joined, user.AuthLevel);
        }

        /// <summary>
        /// Create a new user entity in the database.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="name">The new user's full name.</param>
        /// <param name="password">The user's chosen password.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Result<CreateUserResultModel, string>> CreateUserAsync(
            string email,
            string name,
            string password)
        {
            await using var context = this.databaseContextFactory.CreateDatabaseContext();

            var salt = this.cryptoService.GenerateSalt();
            var hash = this.cryptoService.CalculateHash(password, salt);
            var compressedHash = this.cryptoService.CompressHash(salt, hash);

            var user = new UserEntity(
                0,
                email,
                name,
                DateTime.Now,
                AuthLevel.User,
                compressedHash);

            if (context.Users == null)
            {
                this.logger.LogError($"Users DB set was null when trying to create user.");
                return "Unable to access database.";
            }

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new CreateUserResultModel
            {
                Id = user.Id,
            };
        }
    }
}