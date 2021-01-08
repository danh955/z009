// <copyright file="IUsers.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// List of users interface.
    /// </summary>
    public interface IUsers
    {
        /// <summary>
        /// Get the current game user class.
        /// </summary>
        /// <param name="getBrowserLocalStorageAsync">A function to get the browsers local storage.</param>
        /// <param name="setBrowserLocalStorageAsync">An action to set the browsers local storage.</param>
        /// <returns>GameUser.</returns>
        Task<IUser> GetUserFromLocalStorageAsync(Func<Task<BrowserLocalStorage>> getBrowserLocalStorageAsync, Func<BrowserLocalStorage, Task> setBrowserLocalStorageAsync);
    }
}