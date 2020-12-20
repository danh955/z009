// <copyright file="ListOfGameBoard.razor.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.GameComponents
{
    using GameEngine;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// List of game board component partial class.
    /// </summary>
    public partial class ListOfGameBoard
    {
        [Inject]
        private GameEngineService GameService { get; set; }
    }
}