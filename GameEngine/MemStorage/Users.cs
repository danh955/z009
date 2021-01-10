// <copyright file="Users.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <summary>
    /// List of users class.
    /// </summary>
    internal class Users : IUsers
    {
        private readonly ConcurrentDictionary<string, User> users = new ConcurrentDictionary<string, User>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Get the current game user class.
        /// </summary>
        /// <param name="gameSessionService">GameSessionService.</param>
        /// <param name="userId">User ID.</param>
        /// <returns>GameUser.</returns>
        internal async Task<User> GetUserAsync(GameSessionService gameSessionService, string userId = null)
        {
            if (!string.IsNullOrWhiteSpace(userId))
            {
                if (this.users.TryGetValue(userId, out User value))
                {
                    return value;
                }
            }

            BrowserLocalStorage data = await gameSessionService.GetBrowserLocalStorageAsync();

            if (data == null)
            {
                data = new BrowserLocalStorage
                {
                    UserId = Guid.NewGuid().ToString(),
                };
                await gameSessionService.SetBrowserLocalStorageAsync(data);
            }
            else if (string.IsNullOrWhiteSpace(data.UserId))
            {
                data.UserId = Guid.NewGuid().ToString();
                await gameSessionService.SetBrowserLocalStorageAsync(data);
            }
            else if (this.users.TryGetValue(data.UserId, out User foundUser))
            {
                return foundUser;
            }

            var user = new User(data.UserId);

            //// TODO: How/when to remove this user from list?  Or is there another way to do this.
            return this.users.TryAdd(user.Id, user) ? user : this.users[user.Id];
        }
    }
}