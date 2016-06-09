// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// Defines a Slack message.
    /// </summary>
    public class SlackMessage
    {
        private readonly IList<SlackMessageAttachment> attachments;

        /// <summary>
        /// Initializes a new instance of the <see cref="SlackMessage"/> class.
        /// </summary>
        /// <param name="channel">The channel.</param>
        public SlackMessage(string channel)
        {
            Channel = channel;

            attachments = new List<SlackMessageAttachment>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether [as user].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [as user]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("as_user")]
        public bool AsUser { get; set; }

        /// <summary>
        /// Gets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        [JsonProperty("attachments")]
        public IEnumerable<SlackMessageAttachment> Attachments
        {
            get { return attachments; }
        }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        /// <value>
        /// The channel.
        /// </value>
        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the icon emoji.
        /// </summary>
        /// <value>
        /// The icon emoji.
        /// </value>
        [JsonProperty("icon_emoji")]
        public string IconEmoji { get; set; }

        /// <summary>
        /// Gets or sets the icon URL.
        /// </summary>
        /// <value>
        /// The icon URL.
        /// </value>
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets or sets the link names.
        /// </summary>
        /// <value>
        /// The link names.
        /// </value>
        [JsonProperty("link_names")]
        public int LinkNames { get; set; }

        /// <summary>
        /// Gets or sets the parse.
        /// </summary>
        /// <value>
        /// The parse.
        /// </value>
        [JsonProperty("parse")]
        public string Parse { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [unfurl links].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [unfurl links]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("unfurl_links")]
        public bool UnfurlLinks { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [unfurl media].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [unfurl media]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("unfurl_media")]
        public bool UnfurlMedia { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Adds the attachment.
        /// </summary>
        /// <param name="slackMessageAttachmentToAdd">The slack message attachment to add.</param>
        public void AddAttachment(SlackMessageAttachment slackMessageAttachmentToAdd)
        {
            Guard.Will.ProtectAgainstNullArgument(() => slackMessageAttachmentToAdd);

            attachments.Add(slackMessageAttachmentToAdd);
        }
    }
}