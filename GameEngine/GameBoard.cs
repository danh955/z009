// <copyright file="GameBoard.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// The game board class.
    /// </summary>
    public class GameBoard
    {
        private readonly Dictionary<string, Player> players = new Dictionary<string, Player>(StringComparer.OrdinalIgnoreCase);
        private int nextPlayerId;

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

        /// <summary>
        /// Gets list of players.
        /// </summary>
        public IEnumerable<Player> Players => this.players.Values;

        /// <summary>
        /// Add a player.
        /// </summary>
        /// <param name="playerName">Player name.</param>
        /// <param name="user">User identity.</param>
        /// <returns>Player.</returns>
        public Player AddPlayer(string playerName, GameUser user)
        {
            if (this.players.TryGetValue(playerName, out Player player))
            {
                return player;
            }

            int playerId = Interlocked.Increment(ref this.nextPlayerId);
            player = new Player(playerId, playerName, user);
            this.players.Add(playerName, player);
            return player;
        }

        /// <summary>
        /// Is the user playing this game?
        /// </summary>
        /// <param name="user">GameUser</param>
        /// <returns>True if the player is playing this game.</returns>
        public bool IsUserPlaying(GameUser user)
        {
            return this.Players.Any(p => p.User == user);
        }
    }
}