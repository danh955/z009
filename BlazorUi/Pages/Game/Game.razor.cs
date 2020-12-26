// <copyright file="Game.razor.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Pages.Game
{
    using GameEngine;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Game playing page.
    /// </summary>
    public partial class Game
    {
        /// <summary>
        /// Gets or sets board name to play.
        /// </summary>
        [Parameter]
        public string BoardName { get; set; }

        [Inject]
        private GameEngineService GameService { get; set; }
    }
}