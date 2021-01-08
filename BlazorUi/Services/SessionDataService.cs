// <copyright file="SessionDataService.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Services
{
    using System;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using GameEngine;

    /// <summary>
    /// Session service class.
    /// </summary>
    public class SessionDataService
    {
        private readonly GameEngineService gameService;
        private readonly ILocalStorageService localStorage;
        private IUser user;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionDataService"/> class.
        /// </summary>
        /// <param name="gameService">GameEngineService.</param>
        /// <param name="localStorage">ILocalStorageService.</param>
        public SessionDataService(GameEngineService gameService, ILocalStorageService localStorage)
        {
            this.gameService = gameService;
            this.localStorage = localStorage;
            this.StartTime = DateTime.Now;
        }

        /// <summary>
        /// Gets board name to play.
        /// </summary>
        public string GameboardName { get; private set; }

        /// <summary>
        /// Gets start time of the session.
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// Gets the game user.
        /// </summary>
        public IUser User => this.user;

        /// <summary>
        /// Initialize service.
        /// This should only be called on the OnAfterRenderAsync event.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task InitializeAsync()
        {
            if (this.user == null)
            {
                const string StorageKey = "2dWar";

                this.user = await this.gameService.Users.GetUserFromLocalStorageAsync(
                                async () => { return await this.localStorage.GetItemAsync<BrowserLocalStorage>(StorageKey); },
                                async (data) => { await this.localStorage.SetItemAsync(StorageKey, data); });
            }
        }

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
    }
}