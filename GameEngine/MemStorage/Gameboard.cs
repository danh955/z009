// <copyright file="Gameboard.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    using System.Linq;

    /// <summary>
    /// The game board class.
    /// This is where a the Universe live.
    /// </summary>
    public class Gameboard : IGameboard
    {
        private readonly Players players = new Players();

        /// <summary>
        /// Initializes a new instance of the <see cref="Gameboard"/> class.
        /// </summary>
        /// <param name="boardName">Name of the game board.</param>
        public Gameboard(string boardName)
        {
            this.BoardName = boardName;
        }

        /// <summary>
        /// Gets the name of the board name.
        /// </summary>
        public string BoardName { get; private set; }

        /// <inheritdoc/>
        public IPlayers Players => this.players;

        /// <summary>
        /// Is the user playing this game?.
        /// </summary>
        /// <param name="user">GameUser.</param>
        /// <returns>True if the player is playing this game.</returns>
        public bool IsUserPlaying(IUser user)
        {
            return this.players.Any(p => p.User == user);
        }
    }
}