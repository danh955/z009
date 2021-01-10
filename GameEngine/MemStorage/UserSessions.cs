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
        /// Get the current game session from the browser session storage.
        /// </summary>
        /// <param name="service">GameSessionService.</param>
        /// <returns>IUserSession.</returns>
        internal async Task<UserSession> GetUserSessionAsync(GameSessionService service)
        {
            bool saveBrowserStorage = false;
            BrowserSessionStorage data = await service.GetBrowserSessionStorageAsync();

            if (data == null)
            {
                data = new BrowserSessionStorage
                {
                    SessionId = Guid.NewGuid().ToString(),
                };
                saveBrowserStorage = true;
            }
            else if (string.IsNullOrWhiteSpace(data.SessionId))
            {
                data.SessionId = Guid.NewGuid().ToString();
                saveBrowserStorage = true;
            }
            else if (this.sessions.TryGetValue(data.SessionId, out UserSession foundSession))
            {
                await SetUserAsync(foundSession, service, data, saveBrowserStorage);
                return foundSession;
            }

            var session = new UserSession(data.SessionId);
            await SetUserAsync(session, service, data, saveBrowserStorage);

            //// TODO: How/when to remove this user from list?  Or is there another way to do this.
            return this.sessions.TryAdd(session.SessionId, session) ? session : this.sessions[session.SessionId];
        }

        private static async Task SetUserAsync(UserSession session, GameSessionService service, BrowserSessionStorage data, bool saveBrowserStorage)
        {
            if (session.User == null)
            {
                session.User = await service.GameEngineService.Users.GetUserAsync(service, data.UserId);
            }

            if (string.IsNullOrWhiteSpace(data.UserId))
            {
                data.UserId = session.User.Id;
                saveBrowserStorage = true;
            }

            if (saveBrowserStorage)
            {
                await service.SetBrowserSessionStorageAsync(data);
            }
        }
    }
}