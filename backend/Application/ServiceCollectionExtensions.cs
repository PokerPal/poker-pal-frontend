// <copyright file="ServiceCollectionExtensions.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    /// <summary>
    /// Adds the application services to the service collection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add all the application services to a service collection.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<BadgeService>();
        }
    }
}