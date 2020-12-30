// <copyright file="IPlayer.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    /// <summary>
    /// The player interface.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets id of player.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the user playing this game.
        /// </summary>
        IUser User { get; }
    }
}