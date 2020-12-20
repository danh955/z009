// <copyright file="Index.razor.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Pages
{
    /// <summary>
    /// Index page class.
    /// </summary>
    public partial class Index
    {
        private string message;

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.message = "something";
        }
    }
}