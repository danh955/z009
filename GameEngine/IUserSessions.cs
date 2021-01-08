// <copyright file="IUserSessions.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// List of user sessions interface.
    /// </summary>
    public interface IUserSessions
    {
        /// <summary>
        /// Get the current game user class.
        /// </summary>
        /// <param name="getBrowserSessionStorageAsync">A function to get the browsers session storage.</param>
        /// <param name="setBrowserSessionStorageAsync">An action to set the browsers session storage.</param>
        /// <returns>IUserSession.</returns>
        Task<IUserSession> GetUserSessionFromSessionStorageAsync(
            Func<Task<BrowserSessionStorage>> getBrowserSessionStorageAsync,
            Func<BrowserSessionStorage, Task> setBrowserSessionStorageAsync);
    }
}