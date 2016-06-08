// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// Posts messages to Slack.
    /// </summary>
    public interface ISlackMessagePoster
    {
        /// <summary>
        /// Posts the supplied message to Slack.
        /// </summary>
        /// <param name="message">The message to post.</param>
        void PostMessage(SlackMessage message);
    }
}