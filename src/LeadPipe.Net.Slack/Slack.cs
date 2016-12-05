// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using LeadPipe.Net.Extensions;

/*
 *
 *            ___________    ____
 *     ______/   \__//   \__/____\
 *   _/   \_/  :           //____\\
 *  /|      :  :  ..      /        \
 * | |     ::     ::      \        /
 * | |     :|     ||     \ \______/
 * | |     ||     ||      |\  /  |
 *  \|     ||     ||      |   / | \
 *   |     ||     ||      |  / /_\ \
 *   | ___ || ___ ||      | /  /    \
 *    \_-_/  \_-_/ | ____ |/__/      \
 *                 _\_--_/    \      /
 *                /____             /
 *               /     \           /
 *               \______\_________/
 *
 *
 *   _   _  ____            _    _ _______ ____
 *  | \ | |/ __ \      /\  | |  | |__   __/ __ \
 *  |  \| | |  | |    /  \ | |  | |  | | | |  | |
 *  | . ` | |  | |   / /\ \| |  | |  | | | |  | |
 *  | |\  | |__| |  / ____ \ |__| |  | | | |__| |
 *  |_|_\_|\____/ _/_/_  _\_\____/   |_|__\____/_____ _____ _   _  _____
 *  |  ____/ __ \|  __ \|  \/  |   /\|__   __|__   __|_   _| \ | |/ ____|
 *  | |__ | |  | | |__) | \  / |  /  \  | |     | |    | | |  \| | |  __
 *  |  __|| |  | |  _  /| |\/| | / /\ \ | |     | |    | | | . ` | | |_ |
 *  | |   | |__| | | \ \| |  | |/ ____ \| |     | |   _| |_| |\  | |__| |
 *  |_|    \____/|_|  \_\_|  |_/_/    \_\_|     |_|  |_____|_| \_|\_____|
 *
 */

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// Sends Slack messages.
    /// </summary>
    public class Slack : ISlack, ISlackMessageText, ISlackOptionalValues, ISlackAttachmentValues
    {
        private readonly ISlackMessagePoster poster;
        private readonly SlackMessage pendingSlackMessage;
        private SlackMessageLevel messageLevel;
        private SlackMessageAttachment pendingSlackMessageAttachment;

        /// <summary>
        /// Initializes a new instance of the <see cref="Slack"/> class.
        /// </summary>
        /// <param name="slackConfiguration">The Slack configuration.</param>
        /// <param name="poster">The Slack message poster.</param>
        public Slack(ISlackConfiguration slackConfiguration, ISlackMessagePoster poster)
        {
            this.poster = poster;

            // Set default values...
            messageLevel = SlackMessageLevel.Info;

            pendingSlackMessage = new SlackMessage(slackConfiguration.DefaultChannel);
        }

        // ****************************************************************************************
        // Initialize
        // ****************************************************************************************

        /// <summary>
        /// Starts building a Slack message.
        /// </summary>
        public ISlackMessageText Send { get { return this; } }

        /// <summary>
        /// Sets the Slack message text.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The client.</returns>
        public ISlackOptionalValues Message(string message)
        {
            pendingSlackMessage.Text = message;

            return this;
        }

        /// <summary>
        /// Adds a Slack attachment to the message.
        /// </summary>
        public ISlackAttachmentValues MessageWithAttachment
        {
            get
            {
                pendingSlackMessageAttachment = new SlackMessageAttachment();

                return this;
            }
        }

        // ****************************************************************************************
        // Optional Values
        // ****************************************************************************************

        /// <summary>
        /// Sends the message as a particular user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The client.</returns>
        public ISlackOptionalValues AsUserName(string userName)
        {
            pendingSlackMessage.UserName = userName;

            return this;
        }

        /// <summary>
        /// Adds an icon emoji to the message.
        /// </summary>
        /// <param name="iconEmoji">The icon emoji.</param>
        /// <returns>The client.</returns>
        public ISlackOptionalValues WithIconEmoji(string iconEmoji)
        {
            pendingSlackMessage.IconEmoji = iconEmoji;

            return this;
        }

        /// <summary>
        /// Assigns a message level to the Slack message.
        /// </summary>
        /// <param name="messageLevel">The message level.</param>
        /// <returns>The client.</returns>
        public ISlackOptionalValues WithMessageLevel(SlackMessageLevel messageLevel)
        {
            this.messageLevel = messageLevel;

            return this;
        }

        // ****************************************************************************************
        // Attachment Values
        // ****************************************************************************************

        /// <summary>
        /// Adds fallback text to the Slack attachment.
        /// </summary>
        /// <param name="fallbackText">The fallback text.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues ISlackAttachmentValues.WithFallbackText(string fallbackText)
        {
            pendingSlackMessageAttachment.Fallback = fallbackText;

            return this;
        }

        /// <summary>
        /// Adds a title to the Slack attachment.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues ISlackAttachmentValues.WithTitle(string title)
        {
            pendingSlackMessageAttachment.Title = title;

            return this;
        }

        /// <summary>
        /// Adds a title link to the Slack attachment.
        /// </summary>
        /// <param name="titleLink">The title link.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues ISlackAttachmentValues.WithTitleLink(string titleLink)
        {
            pendingSlackMessageAttachment.TitleLink = titleLink;

            return this;
        }

        /// <summary>
        /// Adds an author icon to the Slack message attachment.
        /// </summary>
        /// <param name="authorIcon">The author icon.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithAuthorIcon(string authorIcon)
        {
            pendingSlackMessageAttachment.AuthorIcon = authorIcon;

            return this;
        }

        /// <summary>
        /// Adds an author link to the Slack message attachment.
        /// </summary>
        /// <param name="authorLink">The author link.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithAuthorLink(string authorLink)
        {
            pendingSlackMessageAttachment.AuthorLink = authorLink;

            return this;
        }

        /// <summary>
        /// Adds an author name to the Slack message attachment.
        /// </summary>
        /// <param name="authorName">Name of the author.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithAuthorName(string authorName)
        {
            pendingSlackMessageAttachment.AuthorName = authorName;

            return this;
        }

        /// <summary>
        /// Assigns a color to the Slack message attachment.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithColor(string color)
        {
            pendingSlackMessageAttachment.Color = color;

            return this;
        }

        /// <summary>
        /// Adds a footer to the Slack message attachment.
        /// </summary>
        /// <param name="footer">The footer.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithFooter(string footer)
        {
            pendingSlackMessageAttachment.Footer = footer;

            return this;
        }

        /// <summary>
        /// Adds a footer icon to the Slack message attachment.
        /// </summary>
        /// <param name="footerIcon">The footer icon.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithFooterIcon(string footerIcon)
        {
            pendingSlackMessageAttachment.FooterIcon = footerIcon;

            return this;
        }

        /// <summary>
        /// Adds an image URL to the Slack message attachment.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithImageUrl(string imageUrl)
        {
            pendingSlackMessageAttachment.ImageUrl = imageUrl;

            return this;
        }

        /// <summary>
        /// Adds pre-text to the Slack message attachment.
        /// </summary>
        /// <param name="pretext">The pretext.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithPretext(string pretext)
        {
            pendingSlackMessageAttachment.Pretext = pretext;

            return this;
        }

        /// <summary>
        /// Assigns a priority to the Slack message attachment.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithPriority(SlackMessagePriority priority)
        {
            pendingSlackMessageAttachment.AddField("Priority", priority.DisplayName, true);

            return this;
        }

        /// <summary>
        /// Adds optional text that appears within the attachment.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithText(string text)
        {
            pendingSlackMessageAttachment.Text = text;

            return this;
        }

        /// <summary>
        /// Adds an image thumbnail to the Slack message attachment.
        /// </summary>
        /// <param name="thumbUrl">The thumb URL.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithThumbUrl(string thumbUrl)
        {
            pendingSlackMessageAttachment.ThumbUrl = thumbUrl;

            return this;
        }

        /// <summary>
        /// Adds a timestamp to the Slack message attachment.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>The client.</returns>
        public ISlackAttachmentValues WithTimestamp(int timestamp)
        {
            pendingSlackMessageAttachment.Timestamp = timestamp;

            return this;
        }

        /// <summary>
        /// Includes an attachment field on the Slack message attachment.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="value">The value.</param>
        /// <param name="isShort">if set to <c>true</c> [is short].</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues ISlackAttachmentValues.IncludingField(string title, string value, bool isShort)
        {
            var field = new SlackMessageAttachmentField(title, value, isShort);

            pendingSlackMessageAttachment.AddField(field);

            return this;
        }

        /// <summary>
        /// Includes multiple fields on the Slack message attachment.
        /// </summary>
        /// <param name="fields">The fields to include.</param>
        /// <returns>
        /// The client.
        /// </returns>
        ISlackAttachmentValues ISlackAttachmentValues.IncludingFields(IEnumerable<SlackMessageAttachmentField> fields)
        {
            pendingSlackMessageAttachment.AddFields(fields);

            return this;
        }

        /// <summary>
        /// Attaches the Slack message attachment.
        /// </summary>
        /// <returns>The client.</returns>
        public ISlackOptionalValues Attach()
        {
            pendingSlackMessage.AddAttachment(pendingSlackMessageAttachment);

            pendingSlackMessageAttachment = null;

            return this;
        }

        // ****************************************************************************************
        // Finalize
        // ****************************************************************************************

        /// <summary>
        /// Gets the Slack message instance.
        /// </summary>
        /// <returns>The Slack message.</returns>
        public SlackMessage ToSlackMessageObject()
        {
            SetDefaultMessageValues();

            Result = null;

            return pendingSlackMessage;
        }

        /// <summary>
        /// Sends the Slack message to the default channel.
        /// </summary>
        public void ToDefaultChannel()
        {
            var messageToPost = ToSlackMessageObject();

            Result = poster.PostMessage(messageToPost);
        }

        /// <summary>
        /// Assigns the Slack message to the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns>The client.</returns>
        public void ToChannel(string channel)
        {
            pendingSlackMessage.Channel = channel;

            var messageToPost = ToSlackMessageObject();

            Result = poster.PostMessage(messageToPost);
        }

        /// <summary>
        /// Gets or sets the result of the Slack API call.
        /// </summary>
        public string Result { get; protected set; }

        // ****************************************************************************************
        // Dirty Work
        // ****************************************************************************************

        /// <summary>
        /// Sets the default message values.
        /// </summary>
        private void SetDefaultMessageValues()
        {
            if (pendingSlackMessage.Attachments.IsEmpty()) return;

            foreach (var attachment in pendingSlackMessage.Attachments)
            {
                if (attachment.Color.IsNullOrWhiteSpace()) attachment.Color = messageLevel.MessageColor;

                if (attachment.Title.IsNullOrWhiteSpace()) attachment.Title = messageLevel.DefaultTitle;
            }
        }
    }
}