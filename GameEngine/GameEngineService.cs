// <copyright file="GameEngineService.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using GameEngine.MemStorage;

    /// <summary>
    /// Game engine service class.
    /// </summary>
    public class GameEngineService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngineService"/> class.
        /// </summary>
        internal GameEngineService()
        {
        }

        /// <summary>
        /// Gets list of game boards.
        /// </summary>
        internal Gameboards Gameboards { get; private set; } = new Gameboards();

        /// <summary>
        /// Gets users.
        /// </summary>
        internal Users Users { get; private set; } = new Users();

        /// <summary>
        /// Gets the user sessions.
        /// </summary>
        internal UserSessions UserSessions { get; private set; } = new UserSessions();
    }
}