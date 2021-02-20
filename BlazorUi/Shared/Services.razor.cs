// <copyright file="Services.razor.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Shared
{
    using System.Threading.Tasks;
    using BlazorUi.Services;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Services initialization class.
    /// </summary>
    public partial class Services
    {
        [Inject]
        private SessionService Session { get; set; }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await this.Session.InitializeAsync();
            }
        }
    }
}