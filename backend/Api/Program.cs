// <copyright file="Program.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Api
{
    /// <summary>
    /// Provides the entry point for the API.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point for the API.
        /// </summary>
        /// <param name="args">The command-line arguments provided when running this program.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}