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
        /// <typeparam name="TService">The type of the scoped service to add.  This service must inherit the GameUserSessionService class.</typeparam>
        /// <param name="service">IServiceCollection.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddGameEngineService<TService>(this IServiceCollection service)
            where TService : GameSessionService
        {
            service.AddSingleton<GameEngineService>(_ => new GameEngineService());
            service.AddScoped<TService>();
            return service;
        }
    }
}