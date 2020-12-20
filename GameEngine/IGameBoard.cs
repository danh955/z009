// <copyright file="IGameBoard.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System.Collections.Generic;

    /// <summary>
    /// Game board interface.
    /// </summary>
    public interface IGameBoard
    {
        /// <summary>
        /// Gets name of the game board.
        /// </summary>
        string BoardName { get; }

        /// <summary>
        /// Gets list of players.
        /// </summary>
        IEnumerable<IPlayer> Players { get; }

        /// <summary>
        /// Add a player onto this board game.
        /// </summary>
        /// <param name="userName">User name of the player.</param>
        /// <returns>Player.</returns>
        Player AddPlayer(string userName);
    }
}