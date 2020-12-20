// <copyright file="GameBoard.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The game board class.
    /// </summary>
    public class GameBoard : IGameBoard
    {
        private readonly Dictionary<string, Player> players = new Dictionary<string, Player>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="GameBoard"/> class.
        /// </summary>
        /// <param name="boardName">Name of board.</param>
        internal GameBoard(string boardName)
        {
            this.BoardName = boardName;
        }

        /// <summary>
        /// Gets or sets name of the game board.
        /// </summary>
        public string BoardName { get; set; }

        /// <inheritdoc/>
        public IEnumerable<IPlayer> Players => this.players.Values;

        /// <inheritdoc/>
        public Player AddPlayer(string userName)
        {
            if (this.players.TryGetValue(userName, out Player player))
            {
                return player;
            }

            player = new Player(userName);
            this.players.Add(userName, player);
            return player;
        }
    }
}