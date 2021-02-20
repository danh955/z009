// <copyright file="BrowserLocalStorage.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    /// <summary>
    /// Browser local storage interface.
    /// This is the data that is stored in the browser local storage.
    /// The application that uses the game engine will provide this data from the browser.
    /// </summary>
    public class BrowserLocalStorage
    {
        /// <summary>
        /// Gets or sets user ID.
        /// </summary>
        public string UserId { get; set; }
    }
}