// <copyright file="GameUserSessionService.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System.Threading.Tasks;
    using GameEngine.MemStorage;

    /// <summary>
    /// Abstract game user session service.
    /// This must be inherit and applied as a scoped service in the UI.
    /// </summary>
    public abstract class GameUserSessionService
    {
        private readonly GameEngineService gameEngineService;
        private UserSession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameUserSessionService"/> class.
        /// </summary>
        /// <param name="gameEngineService">GameEngineService.</param>
        public GameUserSessionService(GameEngineService gameEngineService)
        {
            this.gameEngineService = gameEngineService;
        }

        /// <summary>
        ///  Gets list of game boards.
        /// </summary>
        public IGameboards Gameboards => this.gameEngineService.Gameboards;

        /// <summary>
        /// Gets this user.
        /// </summary>
        public IUser User => this.session?.User;

        /// <summary>
        /// Initialize service.
        /// This should only be called on the OnAfterRenderAsync event.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task InitializeAsync()
        {
            if (this.session == null)
            {
                this.session = await this.gameEngineService.UserSessions.GetUserSessionFromSessionStorageAsync(this.GetBrowserSessionStorageAsync, this.SetBrowserSessionStorageAsync);
            }

            if (this.session.User == null)
            {
                this.session.User = await this.gameEngineService.Users.GetUserFromLocalStorageAsync(this.GetBrowserLocalStorageAsync, this.SetBrowserLocalStorageAsync);
            }
        }

        /// <summary>
        /// Get the browser local storage data.
        /// </summary>
        /// <returns>BrowserLocalStorage.</returns>
        protected abstract Task<BrowserLocalStorage> GetBrowserLocalStorageAsync();

        /// <summary>
        /// Get the browser session storage data.
        /// </summary>
        /// <returns>BrowserSessionStorage.</returns>
        protected abstract Task<BrowserSessionStorage> GetBrowserSessionStorageAsync();

        /// <summary>
        /// Set the browser local storage data.
        /// </summary>
        /// <param name="localStorage">BrowserLocalStorage.</param>
        /// <returns>Task.</returns>
        protected abstract Task SetBrowserLocalStorageAsync(BrowserLocalStorage localStorage);

        /// <summary>
        /// Set the browser session storage data.
        /// </summary>
        /// <param name="sessionStorage">BrowserSessionStorage.</param>
        /// <returns>Task.</returns>
        protected abstract Task SetBrowserSessionStorageAsync(BrowserSessionStorage sessionStorage);
    }
}