// <copyright file="SessionService.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Services
{
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Blazored.SessionStorage;
    using GameEngine;

    /// <summary>
    /// Session service class.
    /// SessionService is for the UI.  GameSessionService is for the game engine access.
    /// </summary>
    public class SessionService : GameSessionService
    {
        private const string StorageKey = "2dWar";
        private readonly ILocalStorageService localStorageService;
        private readonly ISessionStorageService sessionStorageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionService"/> class.
        /// </summary>
        /// <param name="gameEngineService">GameEngineService.</param>
        /// <param name="localStorageService">ILocalStorageService.</param>
        /// <param name="sessionStorageService">ISessionStorageService.</param>
        public SessionService(GameEngineService gameEngineService, ILocalStorageService localStorageService, ISessionStorageService sessionStorageService)
            : base(gameEngineService)
        {
            this.localStorageService = localStorageService;
            this.sessionStorageService = sessionStorageService;
        }

        /// <summary>
        /// Gets board name to play.
        /// </summary>
        public string GameboardName { get; private set; }

        /// <summary>
        /// Set the game board name.
        /// This will select the first name that is not null or empty.
        /// </summary>
        /// <param name="names">List of names.</param>
        /// <returns>True if game board name changed.</returns>
        public bool SetGameBoardName(params string[] names)
        {
            if (names.Length > 0)
            {
                foreach (var name in names)
                {
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        string oldName = this.GameboardName;
                        this.GameboardName = name;
                        return oldName != name;
                    }
                }
            }

            return false;
        }

        /// <inheritdoc/>
        protected override async Task<BrowserLocalStorage> GetBrowserLocalStorageAsync()
        {
            return await this.localStorageService.GetItemAsync<BrowserLocalStorage>(StorageKey);
        }

        /// <inheritdoc/>
        protected override async Task<BrowserSessionStorage> GetBrowserSessionStorageAsync()
        {
            return await this.sessionStorageService.GetItemAsync<BrowserSessionStorage>(StorageKey);
        }

        /// <inheritdoc/>
        protected override async Task SetBrowserLocalStorageAsync(BrowserLocalStorage localStorage)
        {
            await this.localStorageService.SetItemAsync(StorageKey, localStorage);
        }

        /// <inheritdoc/>
        protected override async Task SetBrowserSessionStorageAsync(BrowserSessionStorage sessionStorage)
        {
            await this.sessionStorageService.SetItemAsync(StorageKey, sessionStorage);
        }
    }
}