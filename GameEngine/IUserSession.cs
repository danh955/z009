// <copyright file="IUserSession.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    /// <summary>
    /// User session interface.
    /// </summary>
    public interface IUserSession
    {
        /// <summary>
        /// Gets session ID.
        /// </summary>
        string SessionId { get; }

        /// <summary>
        /// Gets user ID.
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        IUser User { get; }
    }
}