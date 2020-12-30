// <copyright file="Gameboards.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine.MemStorage
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// List of game boards class.
    /// This is where all the Universes live.
    /// </summary>
    internal class Gameboards : IGameboards
    {
        private readonly Dictionary<string, Gameboard> gameboards = new Dictionary<string, Gameboard>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="MemStorage.Gameboards"/> class.
        /// </summary>
        internal Gameboards()
        {
            this.AddGameboard(this.DefaultGameboardName);
        }

        /// <summary>
        /// Gets a list of game boards.
        /// </summary>
        public IEnumerable<IGameboard> Boards
        {
            get { return this.gameboards.Values; }
        }

        /// <summary>
        /// Gets default game board name.
        /// </summary>
        public string DefaultGameboardName => "Default";

        /// <summary>
        /// Add a new game board.
        /// </summary>
        /// <param name="boardName">The new game board name.</param>
        /// <returns>True if created.  False if duplicate name.</returns>
        public bool AddGameboard(string boardName)
        {
            if (this.gameboards.ContainsKey(boardName))
            {
                return false;
            }

            this.gameboards.Add(boardName, new Gameboard(boardName));
            return true;
        }

        /// <inheritdoc/>
        public IEnumerator<IGameboard> GetEnumerator() => this.gameboards.Values.GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.gameboards.Values.GetEnumerator();

        /// <summary>
        /// Get the game board to play on.
        /// </summary>
        /// <param name="gameboardName">Game board name.</param>
        /// <returns>GameBoard.</returns>
        public IGameboard GetGameboard(string gameboardName)
        {
            return this.gameboards.TryGetValue(gameboardName, out Gameboard gameboard) ? gameboard : null;
        }
    }
}