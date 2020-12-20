// <copyright file="Player.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    /// <summary>
    /// Player class.
    /// This is what the player see and can interact with.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        internal Player(string userName)
        {
            this.PlayerName = userName;
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string PlayerName { get; private set; }
    }
}