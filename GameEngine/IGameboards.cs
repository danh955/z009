// <copyright file="IGameboards.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System.Collections.Generic;

    /// <summary>
    /// Game board interface.
    /// </summary>
    public interface IGameboards : IEnumerable<IGameboard>
    {
        /// <summary>
        /// Gets default game board name.
        /// </summary>
        string DefaultGameboardName { get; }

        /// <summary>
        /// Add a new game board.
        /// </summary>
        /// <param name="boardName">The new game board name.</param>
        /// <returns>True if created.  False if duplicate name.</returns>
        bool AddGameboard(string boardName);

        /// <summary>
        /// Get the game board to play on.
        /// </summary>
        /// <param name="gameboardName">Game board name.</param>
        /// <returns>GameBoard.</returns>
        //// TODO: May need to put this in the User class so that the user class know what game is being played.
        public IGameboard GetGameboard(string gameboardName);
    }
}