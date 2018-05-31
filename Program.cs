// <copyright file="Program.cs" company="Thomas Sauvajon">
// Copyright (c) Thomas Sauvajon. All rights reserved.
// </copyright>

namespace Hackaton
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// Application entrypoint class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entrypoint method
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Builds a web host with command line arguments
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>The built web host</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
