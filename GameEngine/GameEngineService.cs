// <copyright file="GameEngineService.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Game engine service class.
    /// </summary>
    public class GameEngineService
    {
        /// <summary>
        /// List of all the game boards.
        /// </summary>
        private readonly Dictionary<string, GameBoard> gameboards = new Dictionary<string, GameBoard>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngineService"/> class.
        /// </summary>
        internal GameEngineService()
        {
            if (this.gameboards.Count <= 0)
            {
                this.AddGameBoard("Default");
            }
        }

        /// <summary>
        /// Gets a list of game boards.
        /// </summary>
        public IEnumerable<IGameBoard> GameBoards
        {
            get { return this.gameboards.Values; }
        }

        /// <summary>
        /// Add a new game board.
        /// </summary>
        /// <param name="boardName">The new game board name.</param>
        /// <returns>True if created.  False if duplicate name.</returns>
        public bool AddGameBoard(string boardName)
        {
            if (this.gameboards.ContainsKey(boardName))
            {
                return false;
            }

            var newGameBoard = new GameBoard(boardName);
            this.gameboards.Add(boardName, newGameBoard);
            return true;
        }
    }
}