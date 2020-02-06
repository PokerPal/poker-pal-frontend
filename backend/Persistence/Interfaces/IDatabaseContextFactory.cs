// <copyright file="IDatabaseContextFactory.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

namespace Persistence.Interfaces
{
    /// <summary>
    /// Factory for creating database contexts.
    /// </summary>
    /// <typeparam name="TContext">The type of database context that is created.</typeparam>
    public interface IDatabaseContextFactory<out TContext>
    {
        /// <summary>
        /// Create a database context.
        /// </summary>
        /// <returns>The created context.</returns>
        public TContext CreateDatabaseContext();
    }
}