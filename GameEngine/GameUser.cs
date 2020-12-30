// <copyright file="GameUser.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The game user class.
    /// This is stored at the session level.
    /// </summary>
    public class GameUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameUser"/> class.
        /// </summary>
        private GameUser(string userId)
        {
            this.UserId = userId;
            this.CreatedTime = DateTime.Now;
        }

        /// <summary>
        /// Gets user ID.
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// Gets object created date and time.
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// Get the current game user class.
        /// </summary>
        /// <param name="gameUsers">List of game users.</param>
        /// <param name="getLocalStorageInfoAsync">A function to get the browsers local storage info.</param>
        /// <param name="setLocalStorageInfoAsync">An action to set the browsers local storage info.</param>
        /// <returns>GameUser.</returns>
        internal static async Task<GameUser> GetUserAsync(
            Dictionary<string, GameUser> gameUsers,
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
            else if (gameUsers.TryGetValue(info.UserId, out GameUser foundUser))
            {
                return foundUser;
            }

            var user = new GameUser(info.UserId);

            //// TODO: How/when to remove this user from list?  Or is there another way to do this.
            gameUsers.Add(user.UserId, user);
            return user;
        }
    }
}