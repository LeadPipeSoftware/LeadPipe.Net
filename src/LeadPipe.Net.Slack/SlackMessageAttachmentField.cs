// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// Defines a Slack message attachment field.
    /// </summary>
    public class SlackMessageAttachmentField
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SlackMessageAttachmentField"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="value">The value.</param>
        /// <param name="isShort">if set to <c>true</c> [is short].</param>
        public SlackMessageAttachmentField(string title, string value, bool isShort = false)
        {
            Title = title;
            Value = value;
            IsShort = isShort;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is short.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is short; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("short")]
        public bool IsShort { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}