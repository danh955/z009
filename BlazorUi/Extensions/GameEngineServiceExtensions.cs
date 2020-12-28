// <copyright file="GameEngineServiceExtensions.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Extensions
{
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using GameEngine;

    /// <summary>
    /// Game engine service extensions static class.
    /// </summary>
    public static class GameEngineServiceExtensions
    {
        /// <summary>
        /// Get the current user.
        /// </summary>
        /// <param name="service">GameEngineService.</param>
        /// <param name="localStorage">ILocalStorageService.</param>
        /// <returns>GameUser.</returns>
        public static async Task<GameUser> GetUserAsync(this GameEngineService service, ILocalStorageService localStorage)
        {
            return await service.GetUserAsync(
                            async () => { return await localStorage.GetItemAsync<LocalStorageInfo>(service.StorageKey); },
                            async (info) => { await localStorage.SetItemAsync(service.StorageKey, info); });
        }
    }
}