// <copyright file="ServiceCollectionExtensions.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Service collection extensions class.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add game engine service.
        /// </summary>
        /// <param name="service">IServiceCollection.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddGameEngineService(this IServiceCollection service)
        {
            service.AddSingleton<GameEngineService>(_ => new GameEngineService());
            return service;
        }
    }
}