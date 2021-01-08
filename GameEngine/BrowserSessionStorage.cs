// <copyright file="BrowserSessionStorage.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    /// <summary>
    /// Browser session storage interface.
    /// This is the data that is stored in the browser session storage.
    /// The application that uses the game engine will provide this data from the browser.
    /// </summary>
    public class BrowserSessionStorage
    {
        /// <summary>
        /// Gets or sets Session ID.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets user ID.
        /// </summary>
        public string UserId { get; set; }
    }
}