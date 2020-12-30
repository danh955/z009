// <copyright file="User.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    using System;

    /// <summary>
    /// User class.
    /// </summary>
    internal class User : IUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">User ID.</param>
        internal User(string id)
        {
            this.Id = id;
            this.CreatedTime = DateTime.Now;
        }

        /// <summary>
        /// Gets user ID.
        /// This is a string that comes from the browsers local storage.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets object created date and time.
        /// </summary>
        public DateTime CreatedTime { get; private set; }
    }
}