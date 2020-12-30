// <copyright file="IUser.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System;

    /// <summary>
    /// The user interface.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets user ID.
        /// This is a string that comes from the browsers local storage.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets object created date and time.
        /// </summary>
        DateTime CreatedTime { get; }
    }
}