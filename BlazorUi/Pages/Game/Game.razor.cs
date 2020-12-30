// <copyright file="Game.razor.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Pages.Game
{
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using BlazorUi.Extensions;
    using GameEngine;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Game playing page.
    /// </summary>
    public partial class Game
    {
        private IGameboard gameboard;
        private IUser user;

        /// <summary>
        /// Gets or sets board name to play.
        /// </summary>
        [Parameter]
        public string GameboardName { get; set; }

        [Inject]
        private GameEngineService GameService { get; set; }

        [Inject]
        private ILocalStorageService LocalStorage { get; set; }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.user == null)
            {
                this.user = await this.GameService.GetUserFromLocalStorageAsync(this.LocalStorage);
                this.StateHasChanged();
            }
        }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (string.IsNullOrWhiteSpace(this.GameboardName))
            {
                this.GameboardName = this.GameService.Gameboards.DefaultGameboardName;
            }

            this.gameboard = this.GameService.Gameboards.GetGameboard(this.GameboardName);
        }
    }
}