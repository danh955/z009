// <copyright file="IGameboard.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    /// <summary>
    /// The game board interface.
    /// </summary>
    public interface IGameboard
    {
        /// <summary>
        /// Gets name of the board game.
        /// </summary>
        string BoardName { get; }

        /// <summary>
        /// Gets list of players.
        /// </summary>
        IPlayers Players { get; }

        /// <summary>
        /// Is the user playing this game?.
        /// </summary>
        /// <param name="user">GameUser.</param>
        /// <returns>True if the player is playing this game.</returns>
        bool IsUserPlaying(IUser user);
    }
}