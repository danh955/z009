// <copyright file="UserSession.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    using System;

    /// <summary>
    /// User session class.
    /// </summary>
    internal class UserSession : IUserSession
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
        string IUserSession.SessionId => this.SessionId;

        /// <inheritdoc/>
        IUser IUserSession.User => this.User;

        /// <summary>
        /// Gets object created date and time.
        /// </summary>
        internal DateTime CreatedTime { get; private set; }

        /// <summary>
        /// Gets or sets session ID.
        /// </summary>
        internal string SessionId { get; set; }

        /// <summary>
        /// Gets or sets user.
        /// </summary>
        internal User User { get; set; }
    }
}