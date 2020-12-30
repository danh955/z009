// <copyright file="ListOfGameBoard.razor.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Pages.Index
{
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using BlazorUi.Extensions;
    using GameEngine;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;

    /// <summary>
    /// List of game board component partial class.
    /// </summary>
    public partial class ListOfGameBoard
    {
        private string newBoardName;
        private string selectedBoardName;
        private GameUser user;

        [Inject]
        private GameEngineService GameService { get; set; }

        [Inject]
        private ILocalStorageService LocalStorage { get; set; }

        /// <summary>
        /// Gets a value indicating whether a board is NOT selected.
        /// </summary>
        private bool IsButtonDisable
        {
            get { return string.IsNullOrWhiteSpace(this.selectedBoardName); }
        }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.user == null)
            {
                this.user = await this.GameService.GetUserAsync(this.LocalStorage);
            }
        }

        /// <summary>
        /// Get a value indicating if the table row is selected or not.
        /// </summary>
        /// <param name="value">Row selected board name.</param>
        /// <returns>Class name to put in the row.</returns>
        private string SelectedClass(string value)
        {
            return value == this.selectedBoardName ? "selected" : "unselected";
        }

        /// <summary>
        /// Row selected click event.
        /// </summary>
        /// <param name="value">Row value selected.</param>
        private void SelectRow(string value)
        {
            this.selectedBoardName = value;
        }

        /// <summary>
        /// Create a new board game.
        /// </summary>
        private void CreateBoard()
        {
            if (!string.IsNullOrWhiteSpace(this.newBoardName))
            {
                this.GameService.AddGameBoard(this.newBoardName);
                this.newBoardName = string.Empty;
            }
        }

        /// <summary>
        /// De-select the selection.
        /// </summary>
        private void ClearButton()
        {
            if (!string.IsNullOrWhiteSpace(this.selectedBoardName))
            {
                this.selectedBoardName = string.Empty;
            }
        }

        /// <summary>
        /// Check if the user has clicked on the enter key.
        /// </summary>
        /// <param name="e">KeyboardEventArgs.</param>
        private void NewBoardNameKeyUp(KeyboardEventArgs e)
        {
            if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                this.CreateBoard();
            }
        }
    }
}