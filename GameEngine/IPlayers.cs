// <copyright file="IPlayers.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System.Collections.Generic;
    using GameEngine.MemStorage;

    /// <summary>
    /// List of players interface.
    /// </summary>
    public interface IPlayers : IEnumerable<IPlayer>
    {
        /// <summary>
        /// Add a player.
        /// </summary>
        /// <param name="playerName">Player name.</param>
        /// <param name="user">User identity.</param>
        /// <returns>Player.</returns>
        IPlayer AddPlayer(string playerName, IUser user);
    }
}