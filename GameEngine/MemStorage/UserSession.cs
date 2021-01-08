// <copyright file="UserSession.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    using System;

    /// <summary>
    /// User session class.
    /// </summary>
    public class UserSession : IUserSession
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserSession"/> class.
        /// </summary>
        /// <param name="sessionId">Session ID.</param>
        internal UserSession(string sessionId)
        {
            this.SessionId = sessionId;
            this.CreatedTime = DateTime.Now;
        }

        /// <inheritdoc/>
        public string SessionId { get; internal set; }

        /// <inheritdoc/>
        public string UserId { get; internal set; }

        /// <summary>
        /// Gets object created date and time.
        /// </summary>
        public DateTime CreatedTime { get; private set; }
    }
}