// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// Sends Slack messages.
    /// </summary>
    /// <seealso cref="LeadPipe.Net.Slack.ISlackMessageText" />
    /// <seealso cref="LeadPipe.Net.Slack.ISlackAttachmentValues" />
    /// <seealso cref="LeadPipe.Net.Slack.ISlackOptionalValues" />
    public class Slack : ISlackMessageText,
                         ISlackAttachmentValues,
                         ISlackOptionalValues
    {
        private readonly ISlackConfiguration configuration;
        private readonly Encoding encoding = new UTF8Encoding();
        private readonly SlackMessage pendingSlackMessage;
        private SlackMessageLevel messageLevel;
        private SlackMessageAttachment pendingSlackMessageAttachment;

        /// <summary>
        /// Initializes a new instance of the <see cref="Slack"/> class.
        /// </summary>
        /// <param name="slackConfiguration">The slack configuration.</param>
        public Slack(ISlackConfiguration slackConfiguration)
        {
            configuration = slackConfiguration;

            // Set default values...
            messageLevel = SlackMessageLevel.Info;

            pendingSlackMessage = new SlackMessage(configuration.DefaultChannel);
        }

        /// <summary>
        /// Gets the build.
        /// </summary>
        /// <value>
        /// The build.
        /// </value>
        public ISlackMessageText Build { get { return this; } }

        /// <summary>
        /// Gets the with attachment.
        /// </summary>
        /// <value>
        /// The with attachment.
        /// </value>
        public ISlackAttachmentValues WithAttachment
        {
            get
            {
                pendingSlackMessageAttachment = new SlackMessageAttachment();

                return this;
            }
        }

        /// <summary>
        /// Ases the name of the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public ISlackOptionalValues AsUserName(string userName)
        {
            pendingSlackMessage.UserName = userName;

            return this;
        }

        /// <summary>
        /// Attaches this instance.
        /// </summary>
        /// <returns></returns>
        public ISlackOptionalValues Attach()
        {
            pendingSlackMessage.AddAttachment(pendingSlackMessageAttachment);

            pendingSlackMessageAttachment = null;

            return this;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns></returns>
        public SlackMessage GetMessage()
        {
            SetDefaultMessageValues();

            return pendingSlackMessage;
        }

        /// <summary>
        /// Includings the field.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="value">The value.</param>
        /// <param name="isShort">if set to <c>true</c> [is short].</param>
        /// <returns></returns>
        ISlackAttachmentValues ISlackAttachmentValues.IncludingField(string title, string value, bool isShort)
        {
            var field = new SlackMessageAttachmentField(title, value, isShort);

            pendingSlackMessageAttachment.AddField(field);

            return this;
        }

        /// <summary>
        /// Withes the fallback text.
        /// </summary>
        /// <param name="fallbackText">The fallback text.</param>
        /// <returns></returns>
        ISlackAttachmentValues ISlackAttachmentValues.WithFallbackText(string fallbackText)
        {
            pendingSlackMessageAttachment.Fallback = fallbackText;

            return this;
        }

        /// <summary>
        /// Withes the title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        ISlackAttachmentValues ISlackAttachmentValues.WithTitle(string title)
        {
            pendingSlackMessageAttachment.Title = title;

            return this;
        }

        /// <summary>
        /// Withes the title link.
        /// </summary>
        /// <param name="titleLink">The title link.</param>
        /// <returns></returns>
        ISlackAttachmentValues ISlackAttachmentValues.WithTitleLink(string titleLink)
        {
            pendingSlackMessageAttachment.TitleLink = titleLink;

            return this;
        }

        /// <summary>
        /// Messages the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ISlackOptionalValues Message(string message)
        {
            pendingSlackMessage.Text = message;

            return this;
        }

        /// <summary>
        /// Sends the now.
        /// </summary>
        public void SendNow()
        {
            var messageToSend = GetMessage();

            if (configuration.Enabled) PostMessage(messageToSend);
        }

        /// <summary>
        /// To the channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns></returns>
        public ISlackOptionalValues ToChannel(string channel)
        {
            pendingSlackMessage.Channel = channel;

            return this;
        }

        /// <summary>
        /// Withes the author icon.
        /// </summary>
        /// <param name="authorIcon">The author icon.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithAuthorIcon(string authorIcon)
        {
            pendingSlackMessageAttachment.AuthorIcon = authorIcon;

            return this;
        }

        /// <summary>
        /// Withes the author link.
        /// </summary>
        /// <param name="authorLink">The author link.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithAuthorLink(string authorLink)
        {
            pendingSlackMessageAttachment.AuthorLink = authorLink;

            return this;
        }

        /// <summary>
        /// Withes the name of the author.
        /// </summary>
        /// <param name="authorName">Name of the author.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithAuthorName(string authorName)
        {
            pendingSlackMessageAttachment.AuthorName = authorName;

            return this;
        }

        /// <summary>
        /// Withes the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithColor(string color)
        {
            pendingSlackMessageAttachment.Color = color;

            return this;
        }

        /// <summary>
        /// Withes the footer.
        /// </summary>
        /// <param name="footer">The footer.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithFooter(string footer)
        {
            pendingSlackMessageAttachment.Footer = footer;

            return this;
        }

        /// <summary>
        /// Withes the footer icon.
        /// </summary>
        /// <param name="footerIcon">The footer icon.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithFooterIcon(string footerIcon)
        {
            pendingSlackMessageAttachment.FooterIcon = footerIcon;

            return this;
        }

        /// <summary>
        /// Withes the icon emoji.
        /// </summary>
        /// <param name="iconEmoji">The icon emoji.</param>
        /// <returns></returns>
        public ISlackOptionalValues WithIconEmoji(string iconEmoji)
        {
            pendingSlackMessage.IconEmoji = iconEmoji;

            return this;
        }

        /// <summary>
        /// Withes the image URL.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithImageUrl(string imageUrl)
        {
            pendingSlackMessageAttachment.ImageUrl = imageUrl;

            return this;
        }

        /// <summary>
        /// Withes the message level.
        /// </summary>
        /// <param name="messageLevel">The message level.</param>
        /// <returns></returns>
        public ISlackOptionalValues WithMessageLevel(SlackMessageLevel messageLevel)
        {
            this.messageLevel = messageLevel;

            return this;
        }

        /// <summary>
        /// Withes the pretext.
        /// </summary>
        /// <param name="pretext">The pretext.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithPretext(string pretext)
        {
            pendingSlackMessageAttachment.Pretext = pretext;

            return this;
        }

        /// <summary>
        /// Withes the priority.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithPriority(SlackMessagePriority priority)
        {
            pendingSlackMessageAttachment.AddField("Priority", priority.DisplayName, true);

            return this;
        }

        /// <summary>
        /// Withes the thumb URL.
        /// </summary>
        /// <param name="thumbUrl">The thumb URL.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithThumbUrl(string thumbUrl)
        {
            pendingSlackMessageAttachment.ThumbUrl = thumbUrl;

            return this;
        }

        /// <summary>
        /// Withes the timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns></returns>
        public ISlackAttachmentValues WithTimestamp(int timestamp)
        {
            pendingSlackMessageAttachment.Timestamp = timestamp;

            return this;
        }

        /// <summary>
        /// Posts the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void PostMessage(SlackMessage message)
        {
            var payloadJson = JsonConvert.SerializeObject(message);

            using (var client = new WebClient())
            {
                var data = new NameValueCollection { ["payload"] = payloadJson };

                var response = client.UploadValues(configuration.UrlWithAccessToken, "POST", data);

                // The response text is usually "ok"
                var responseText = encoding.GetString(response);
            }
        }

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