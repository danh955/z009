// <copyright file="GameUser.cs" company="None">
// Free and open source code.
// </copyright>

namespace GameEngine
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The game user class.
    /// This is stored at the session level.
    /// </summary>
    public class GameUser
    {
        private readonly Func<Task<LocalStorageInfo>> getLocalStorageInfoAsync;
        private readonly Func<LocalStorageInfo, Task> setLocalStorageInfoAsync;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameUser"/> class.
        /// </summary>
        /// <param name="getLocalStorageInfoAsync">A function to get the browsers local storage info.</param>
        /// <param name="setLocalStorageInfoAsync">An action to set the browsers local storage info.</param>
        internal GameUser(Func<Task<LocalStorageInfo>> getLocalStorageInfoAsync, Func<LocalStorageInfo, Task> setLocalStorageInfoAsync)
        {
            this.getLocalStorageInfoAsync = getLocalStorageInfoAsync;
            this.setLocalStorageInfoAsync = setLocalStorageInfoAsync;
        }

        /// <summary>
        /// Gets users browser ID.
        /// </summary>
        public LocalStorageInfo LocalStorageInfo { get; private set; }

        /// <summary>
        /// Load the browser storage info.
        /// </summary>
        /// <returns>Task.</returns>
        internal async Task LoadStorageInfoAsync()
        {
            LocalStorageInfo info = await this.getLocalStorageInfoAsync();

            if (info == null)
            {
                info = new LocalStorageInfo
                {
                    Id = Guid.NewGuid().ToString(),
                };
                await this.setLocalStorageInfoAsync(info);
            }

            this.LocalStorageInfo = info;
        }
    }
}