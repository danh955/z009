// <copyright file="Player.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    /// <summary>
    /// The player class.
    /// </summary>
    internal class Player : IPlayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="id">ID of player.</param>
        /// <param name="name">Name of the player.</param>
        /// <param name="user">User.</param>
        internal Player(int id, string name, IUser user)
        {
            this.Id = id;
            this.Name = name;
            this.User = user;
        }

        /// <summary>
        /// Gets id of player.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the user playing this game.
        /// </summary>
        public IUser User { get; private set; }
    }
}