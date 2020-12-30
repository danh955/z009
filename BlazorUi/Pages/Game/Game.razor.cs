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
        private GameBoard gameBoard;
        private GameUser user;

        /// <summary>
        /// Gets or sets board name to play.
        /// </summary>
        [Parameter]
        public string GameBoardName { get; set; }

        [Inject]
        private GameEngineService GameService { get; set; }

        [Inject]
        private ILocalStorageService LocalStorage { get; set; }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.user == null)
            {
                this.user = await this.GameService.GetUserAsync(this.LocalStorage);
                this.StateHasChanged();
            }
        }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.gameBoard = this.GameService.GetGameBoard(this.GameBoardName);
        }
    }
}