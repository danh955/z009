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
        private readonly Gameboards gameboards = new Gameboards();
        private readonly Users users = new Users();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngineService"/> class.
        /// </summary>
        internal GameEngineService()
        {
        }

        /// <summary>
        /// Gets list of game boards.
        /// </summary>
        public IGameboards Gameboards => this.gameboards;

        /// <summary>
        /// Gets list of users.
        /// </summary>
        public IUsers Users => this.users;
    }
}