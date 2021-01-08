// <copyright file="UserSessions.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    /// <summary>
    /// User sessions class.
    /// </summary>
    internal class UserSessions : IUserSessions
    {
        private readonly ConcurrentDictionary<string, UserSession> sessions = new ConcurrentDictionary<string, UserSession>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Get the current game user class.
        /// </summary>
        /// <param name="getBrowserSessionStorageAsync">A function to get the browsers session storage.</param>
        /// <param name="setBrowserSessionStorageAsync">An action to set the browsers session storage.</param>
        /// <returns>IUserSession.</returns>
        internal async Task<UserSession> GetUserSessionFromSessionStorageAsync(
            Func<Task<BrowserSessionStorage>> getBrowserSessionStorageAsync,
            Func<BrowserSessionStorage, Task> setBrowserSessionStorageAsync)
        {
            BrowserSessionStorage data = await getBrowserSessionStorageAsync();

            if (data == null)
            {
                data = new BrowserSessionStorage
                {
                    SessionId = Guid.NewGuid().ToString(),
                };
                await setBrowserSessionStorageAsync(data);
            }
            else if (string.IsNullOrWhiteSpace(data.UserId))
            {
                data.SessionId = Guid.NewGuid().ToString();
                await setBrowserSessionStorageAsync(data);
            }
            else if (this.sessions.TryGetValue(data.UserId, out UserSession foundUser))
            {
                return foundUser;
            }

            var session = new UserSession(data.SessionId);

            //// TODO: How/when to remove this user from list?  Or is there another way to do this.
            return this.sessions.TryAdd(session.SessionId, session) ? session : this.sessions[session.SessionId];
        }
    }
}