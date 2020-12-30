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
        /// <param name="getLocalStorageInfoAsync">A function to get the browsers local storage info.</param>
        /// <param name="setLocalStorageInfoAsync">An action to set the browsers local storage info.</param>
        /// <returns>GameUser.</returns>
        Task<IUser> GetUserFromLocalStorageAsync(Func<Task<LocalStorageInfo>> getLocalStorageInfoAsync, Func<LocalStorageInfo, Task> setLocalStorageInfoAsync);
    }
}