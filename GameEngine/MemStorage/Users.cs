// <copyright file="Users.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    using System;
    using System.Collections.Concurrent;
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
        /// <param name="getBrowserLocalStorageAsync">A function to get the browsers local storage info.</param>
        /// <param name="setBrowserLocalStorageAsync">An action to set the browsers local storage info.</param>
        /// <returns>GameUser.</returns>
        public async Task<IUser> GetUserFromLocalStorageAsync(
            Func<Task<BrowserLocalStorage>> getBrowserLocalStorageAsync,
            Func<BrowserLocalStorage, Task> setBrowserLocalStorageAsync)
        {
            BrowserLocalStorage data = await getBrowserLocalStorageAsync();

            if (data == null)
            {
                data = new BrowserLocalStorage
                {
                    UserId = Guid.NewGuid().ToString(),
                };
                await setBrowserLocalStorageAsync(data);
            }
            else if (string.IsNullOrWhiteSpace(data.UserId))
            {
                data.UserId = Guid.NewGuid().ToString();
                await setBrowserLocalStorageAsync(data);
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