// <copyright file="ListOfPlayers.razor.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Pages.Game
{
    using GameEngine;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;

    /// <summary>
    /// List of payers class.
    /// </summary>
    public partial class ListOfPlayers
    {
        private string newPlayerName;

        /// <summary>
        /// Gets or sets the game board to play.
        /// </summary>
        [Parameter]
        public IGameboard Gameboard { get; set; }

        /// <summary>
        /// Gets or sets game user.
        /// </summary>
        [Parameter]
        public IUser User { get; set; }

        /// <summary>
        /// Gets a value indicating whether the player is playing.
        /// </summary>
        private bool IsButtonDisable
        {
            get { return this.Gameboard.IsUserPlaying(this.User); }
        }

        /// <summary>
        /// Add a player to game.
        /// </summary>
        private void AddPlayer()
        {
            if (!string.IsNullOrWhiteSpace(this.newPlayerName))
            {
                this.Gameboard.Players.AddPlayer(this.newPlayerName, this.User);
                this.newPlayerName = string.Empty;
            }
        }

        /// <summary>
        /// Check if the user has clicked on the enter key.
        /// </summary>
        /// <param name="e">KeyboardEventArgs.</param>
        private void NewPlayerNameKeyUp(KeyboardEventArgs e)
        {
            if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                this.AddPlayer();
            }
        }
    }
}