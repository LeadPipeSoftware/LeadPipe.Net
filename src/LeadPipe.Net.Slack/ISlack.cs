// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// The Slack client.
    /// </summary>
    /// <seealso cref="LeadPipe.Net.Slack.ISlackMessageText" />
    /// <seealso cref="LeadPipe.Net.Slack.ISlackAttachmentValues" />
    /// <seealso cref="LeadPipe.Net.Slack.ISlackOptionalValues" />
    public interface ISlack : ISlackMessageText, ISlackAttachmentValues, ISlackOptionalValues
    {
    }

    /// <summary>
    /// The Slack attachment interface.
    /// </summary>
    public interface ISlackAttachmentValues
    {
        /// <summary>
        /// Attaches this instance.
        /// </summary>
        /// <returns></returns>
        ISlackOptionalValues Attach();

        /// <summary>
        /// Includings the field.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="value">The value.</param>
        /// <param name="isShort">if set to <c>true</c> [is short].</param>
        /// <returns></returns>
        ISlackAttachmentValues IncludingField(string title, string value, bool isShort = false);

        /// <summary>
        /// Withes the author icon.
        /// </summary>
        /// <param name="authorIcon">The author icon.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithAuthorIcon(string authorIcon);

        /// <summary>
        /// Withes the author link.
        /// </summary>
        /// <param name="authorLink">The author link.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithAuthorLink(string authorLink);

        /// <summary>
        /// Withes the name of the author.
        /// </summary>
        /// <param name="authorName">Name of the author.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithAuthorName(string authorName);

        /// <summary>
        /// Withes the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithColor(string color);

        /// <summary>
        /// Withes the fallback text.
        /// </summary>
        /// <param name="fallbackText">The fallback text.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithFallbackText(string fallbackText);

        /// <summary>
        /// Withes the footer.
        /// </summary>
        /// <param name="footer">The footer.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithFooter(string footer);

        /// <summary>
        /// Withes the footer icon.
        /// </summary>
        /// <param name="footerIcon">The footer icon.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithFooterIcon(string footerIcon);

        /// <summary>
        /// Withes the image URL.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithImageUrl(string imageUrl);

        /// <summary>
        /// Withes the pretext.
        /// </summary>
        /// <param name="pretext">The pretext.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithPretext(string pretext);

        /// <summary>
        /// Withes the priority.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithPriority(SlackMessagePriority priority);

        /// <summary>
        /// Withes the thumb URL.
        /// </summary>
        /// <param name="thumbUrl">The thumb URL.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithThumbUrl(string thumbUrl);

        /// <summary>
        /// Withes the timestamp.
        /// </summary>
        /// <param name="timeStamp">The time stamp.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithTimestamp(int timeStamp);

        /// <summary>
        /// Withes the title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithTitle(string title);

        /// <summary>
        /// Withes the title link.
        /// </summary>
        /// <param name="titleLink">The title link.</param>
        /// <returns></returns>
        ISlackAttachmentValues WithTitleLink(string titleLink);
    }

    /// <summary>
    /// The Slack Message Text interface.
    /// </summary>
    public interface ISlackMessageText
    {
        /// <summary>
        /// Messages the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ISlackOptionalValues Message(string message);
    }

    /// <summary>
    /// The Slack optional values.
    /// </summary>
    public interface ISlackOptionalValues
    {
        /// <summary>
        /// Gets the with attachment.
        /// </summary>
        /// <value>
        /// The with attachment.
        /// </value>
        ISlackAttachmentValues WithAttachment { get; }

        /// <summary>
        /// Ases the name of the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        ISlackOptionalValues AsUserName(string userName);

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns></returns>
        SlackMessage GetMessage();

        /// <summary>
        /// Sends the now.
        /// </summary>
        void SendNow();

        /// <summary>
        /// To the channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns></returns>
        ISlackOptionalValues ToChannel(string channel);

        /// <summary>
        /// Withes the icon emoji.
        /// </summary>
        /// <param name="iconEmoji">The icon emoji.</param>
        /// <returns></returns>
        ISlackOptionalValues WithIconEmoji(string iconEmoji);

        /// <summary>
        /// Withes the message level.
        /// </summary>
        /// <param name="messageLevel">The message level.</param>
        /// <returns></returns>
        ISlackOptionalValues WithMessageLevel(SlackMessageLevel messageLevel);
    }
}