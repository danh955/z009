// <copyright file="Players.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// List of players class.
    /// </summary>
    internal class Players : IPlayers
    {
        private readonly Dictionary<string, Player> players = new Dictionary<string, Player>(StringComparer.OrdinalIgnoreCase);
        private int nextPlayerId;

        /// <summary>
        /// Add a player.
        /// </summary>
        /// <param name="playerName">Player name.</param>
        /// <param name="user">User identity.</param>
        /// <returns>Player.</returns>
        public IPlayer AddPlayer(string playerName, IUser user)
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

        /// <inheritdoc/>
        public IEnumerator<IPlayer> GetEnumerator() => this.players.Values.GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.players.Values.GetEnumerator();
    }
}