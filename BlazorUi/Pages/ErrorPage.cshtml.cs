﻿// <copyright file="ErrorPage.cshtml.cs" company="None">
// Free and open source code.
// </copyright>

namespace BlazorUi.Pages
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Error page class.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorPage : PageModel
    {
        private readonly ILogger<ErrorPage> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorPage"/> class.
        /// </summary>
        /// <param name="logger">logger for the error page.</param>
        public ErrorPage(ILogger<ErrorPage> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Gets or sets request ID.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether show request has an ID.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

        /// <summary>
        /// On get.
        /// </summary>
        public void OnGet()
        {
            this.RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
        }
    }
}