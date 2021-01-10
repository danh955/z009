// <copyright file="GameSessionService.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System.Threading;
    using System.Threading.Tasks;
    using GameEngine.MemStorage;

    /// <summary>
    /// Abstract game user session service class.
    /// This must be inherit and applied as a scoped service in the UI.
    /// </summary>
    public abstract class GameSessionService
    {
        private readonly SemaphoreSlim initSemaphoreSlim = new SemaphoreSlim(1, 1);
        private UserSession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameSessionService"/> class.
        /// </summary>
        /// <param name="gameEngineService">GameEngineService.</param>
        public GameSessionService(GameEngineService gameEngineService)
        {
            this.GameEngineService = gameEngineService;
        }

        /// <summary>
        ///  Gets list of game boards.
        /// </summary>
        public IGameboards Gameboards => this.GameEngineService.Gameboards;

        /// <summary>
        /// Gets this user.
        /// </summary>
        public IUser User => this.session?.User;

        /// <summary>
        /// Gets game engine service.
        /// </summary>
        internal GameEngineService GameEngineService { get; private set; }

        /// <summary>
        /// Initialize service.
        /// This should only be called on the OnAfterRenderAsync event.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task InitializeAsync()
        {
            if (this.session == null)
            {
                await this.initSemaphoreSlim.WaitAsync(20000);
                try
                {
                    if (this.session == null)
                    {
                        this.session = await this.GameEngineService.UserSessions.GetUserSessionAsync(this);
                    }
                }
                finally
                {
                    this.initSemaphoreSlim.Release();
                }
            }
        }

        /// <summary>
        /// Get the browser local storage data.
        /// </summary>
        /// <returns>BrowserLocalStorage.</returns>
        protected internal abstract Task<BrowserLocalStorage> GetBrowserLocalStorageAsync();

        /// <summary>
        /// Get the browser session storage data.
        /// </summary>
        /// <returns>BrowserSessionStorage.</returns>
        protected internal abstract Task<BrowserSessionStorage> GetBrowserSessionStorageAsync();

        /// <summary>
        /// Set the browser local storage data.
        /// </summary>
        /// <param name="localStorage">BrowserLocalStorage.</param>
        /// <returns>Task.</returns>
        protected internal abstract Task SetBrowserLocalStorageAsync(BrowserLocalStorage localStorage);

        /// <summary>
        /// Set the browser session storage data.
        /// </summary>
        /// <param name="sessionStorage">BrowserSessionStorage.</param>
        /// <returns>Task.</returns>
        protected internal abstract Task SetBrowserSessionStorageAsync(BrowserSessionStorage sessionStorage);
    }
}