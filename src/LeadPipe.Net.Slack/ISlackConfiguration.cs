// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// The Slack configuration.
    /// </summary>
    public interface ISlackConfiguration
    {
        /// <summary>
        /// Gets the default Slack channel.
        /// </summary>
        /// <value>
        /// The default Slack channel.
        /// </value>
        string DefaultChannel { get; }

        /// <summary>
        /// Gets a value indicating whether sending Slack messages is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; }

        /// <summary>
        /// Gets the Slack URL with access token.
        /// </summary>
        /// <value>
        /// The URL with access token.
        /// </value>
        string UrlWithAccessToken { get; }
    }
}