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
        /// <param name="getLocalStorageInfoAsync">A function to get the browsers local storage info.</param>
        /// <param name="setLocalStorageInfoAsync">An action to set the browsers local storage info.</param>
        /// <returns>GameUser.</returns>
        public async Task<IUser> GetUserFromLocalStorageAsync(
            Func<Task<LocalStorageInfo>> getLocalStorageInfoAsync,
            Func<LocalStorageInfo, Task> setLocalStorageInfoAsync)
        {
            LocalStorageInfo info = await getLocalStorageInfoAsync();

            if (info == null)
            {
                info = new LocalStorageInfo
                {
                    UserId = Guid.NewGuid().ToString(),
                };
                await setLocalStorageInfoAsync(info);
            }
            else if (string.IsNullOrWhiteSpace(info.UserId))
            {
                info.UserId = Guid.NewGuid().ToString();
                await setLocalStorageInfoAsync(info);
            }
            else if (this.users.TryGetValue(info.UserId, out User foundUser))
            {
                return foundUser;
            }

            var user = new User(info.UserId);

            //// TODO: How/when to remove this user from list?  Or is there another way to do this.
            return this.users.TryAdd(user.Id, user) ? user : this.users[user.Id];
        }
    }
}