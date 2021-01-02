// <copyright file="Game.razor.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Pages.Game
{
    using BlazorUi.Services;
    using GameEngine;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Game playing page.
    /// </summary>
    public partial class Game
    {
        private IGameboard gameboard;

        /// <summary>
        /// Gets or sets board name to play.
        /// </summary>
        [Parameter]
        public string GameboardName { get; set; }

        [Inject]
        private GameEngineService GameService { get; set; }

        [Inject]
        private SessionDataService Session { get; set; }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (this.Session.SetGameBoardName(this.GameboardName, this.Session.GameboardName, this.GameService.Gameboards.DefaultGameboardName))
            {
                this.StateHasChanged();
            }

            this.gameboard = this.GameService.Gameboards.GetGameboard(this.Session.GameboardName);
        }
    }
}