// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// Defines a Slack message attachment.
    /// </summary>
    public class SlackMessageAttachment
    {
        private readonly List<SlackMessageAttachmentField> fields;
        private readonly IList<string> propertiesContainingMarkdown;

        /// <summary>
        /// Initializes a new instance of the <see cref="SlackMessageAttachment"/> class.
        /// </summary>
        public SlackMessageAttachment()
        {
            fields = new List<SlackMessageAttachmentField>();
            propertiesContainingMarkdown = new List<string> { "pretext", "text", "fields" };

            // Set the timestamp in Epoch...
            var t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            Timestamp = (int)t.TotalSeconds;
        }

        /// <summary>
        /// Gets or sets the author icon.
        /// </summary>
        /// <value>
        /// The author icon.
        /// </value>
        [JsonProperty("author_icon")]
        public string AuthorIcon { get; set; }

        /// <summary>
        /// Gets or sets the author link.
        /// </summary>
        /// <value>
        /// The author link.
        /// </value>
        [JsonProperty("author_link")]
        public string AuthorLink { get; set; }

        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        /// <value>
        /// The name of the author.
        /// </value>
        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the fallback.
        /// </summary>
        /// <value>
        /// The fallback.
        /// </value>
        [JsonProperty("fallback")]
        public string Fallback { get; set; }

        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        [JsonProperty("fields")]
        public IEnumerable<SlackMessageAttachmentField> Fields
        {
            get { return fields; }
        }

        /// <summary>
        /// Gets or sets the footer.
        /// </summary>
        /// <value>
        /// The footer.
        /// </value>
        [JsonProperty("footer")]
        public string Footer { get; set; }

        /// <summary>
        /// Gets or sets the footer icon.
        /// </summary>
        /// <value>
        /// The footer icon.
        /// </value>
        [JsonProperty("footer_icon")]
        public string FooterIcon { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the pretext.
        /// </summary>
        /// <value>
        /// The pretext.
        /// </value>
        [JsonProperty("pretext")]
        public string Pretext { get; set; }

        /// <summary>
        /// Gets the properties containing markdown.
        /// </summary>
        /// <value>
        /// The properties containing markdown.
        /// </value>
        [JsonProperty("mrkdwn_in")]
        public IEnumerable<string> PropertiesContainingMarkdown
        {
            get { return propertiesContainingMarkdown; }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the thumb URL.
        /// </summary>
        /// <value>
        /// The thumb URL.
        /// </value>
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        [JsonProperty("ts")]
        public int Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the title link.
        /// </summary>
        /// <value>
        /// The title link.
        /// </value>
        [JsonProperty("title_link")]
        public string TitleLink { get; set; }

        /// <summary>
        /// Adds the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public void AddField(SlackMessageAttachmentField field)
        {
            Guard.Will.ProtectAgainstNullArgument(() => field);

            fields.Add(field);
        }

        /// <summary>
        /// Adds the fields
        /// </summary>
        /// <param name="fieldsToAdd">The fields to add.</param>
        public void AddFields(IEnumerable<SlackMessageAttachmentField> fieldsToAdd)
        {
            Guard.Will.ThrowArgumentNullException("fields").When(fieldsToAdd.IsEmpty());

            fields.AddRange(fieldsToAdd);
        }

        /// <summary>
        /// Adds the field.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="value">The value.</param>
        /// <param name="isShort">if set to <c>true</c> [is short].</param>
        public void AddField(string title, string value, bool isShort = false)
        {
            Guard.Will.ProtectAgainstNullOrEmptyStringArgument(() => title);

            fields.Add(new SlackMessageAttachmentField(title, value, isShort));
        }

        /// <summary>
        /// Adds the markdown flag to property.
        /// </summary>
        /// <param name="property">The property.</param>
        public void AddMarkdownFlagToProperty(string property)
        {
            Guard.Will.ProtectAgainstNullOrEmptyStringArgument(() => property);

            propertiesContainingMarkdown.Add(property);
        }
    }
}