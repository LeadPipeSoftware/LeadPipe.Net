// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

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
    // ****************************************************************************************
    // Initialize
    // ****************************************************************************************

    /// <summary>
    /// The Slack message client.
    /// </summary>
    public interface ISlack : ISlackSend
    {
    }

    /// <summary>
    /// The Slack Build interface.
    /// </summary>
    public interface ISlackSend
    {
        /// <summary>
        /// Starts building a Slack message.
        /// </summary>
        ISlackMessageText Send { get; }
    }

    /// <summary>
    /// The Slack Message Text interface.
    /// </summary>
    public interface ISlackMessageText
    {
        /// <summary>
        /// Sets the message text.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The client.</returns>
        ISlackOptionalValues Message(string message);
    }

    // ****************************************************************************************
    // Optional Values
    // ****************************************************************************************

    /// <summary>
    /// The Slack optional values.
    /// </summary>
    public interface ISlackOptionalValues
    {
        /// <summary>
        /// Adds a Slack message attachment.
        /// </summary>
        ISlackAttachmentValues WithAttachment { get; }

        /// <summary>
        /// Sends the Slack message as a particular user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The client.</returns>
        ISlackOptionalValues AsUserName(string userName);

        /// <summary>
        /// Assigns an icon emoji to the Slack message.
        /// </summary>
        /// <param name="iconEmoji">The icon emoji.</param>
        /// <returns>The client.</returns>
        ISlackOptionalValues WithIconEmoji(string iconEmoji);

        /// <summary>
        /// Assigns a message level to the Slack message.
        /// </summary>
        /// <param name="messageLevel">The message level.</param>
        /// <returns>The client.</returns>
        ISlackOptionalValues WithMessageLevel(SlackMessageLevel messageLevel);

        /// <summary>
        /// Sends the message to a specific Slack channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        void ToChannel(string channel);

        /// <summary>
        /// Sends the message to the default Slack channel.
        /// </summary>
        void ToDefaultChannel();

        /// <summary>
        /// Gets the built-up Slack message object instead of sending.
        /// </summary>
        /// <returns>The built-up Slack message</returns>
        SlackMessage ToSlackMessageObject();
    }

    // ****************************************************************************************
    // Attachment Values
    // ****************************************************************************************

    /// <summary>
    /// The Slack attachment interface.
    /// </summary>
    public interface ISlackAttachmentValues
    {
        /// <summary>
        /// Attaches the Slack message attachment.
        /// </summary>
        /// <returns>The client.</returns>
        ISlackOptionalValues Attach();

        /// <summary>
        /// Includes a field on the Slack message attachment.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="value">The value.</param>
        /// <param name="isShort">if set to <c>true</c> [is short].</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues IncludingField(string title, string value, bool isShort = false);

        /// <summary>
        /// Adds an author icon to the Slack message attachment.
        /// </summary>
        /// <param name="authorIcon">The author icon.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithAuthorIcon(string authorIcon);

        /// <summary>
        /// Adds an author link to the Slack message attachment.
        /// </summary>
        /// <param name="authorLink">The author link.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithAuthorLink(string authorLink);

        /// <summary>
        /// Adds the author name to the Slack message attachment.
        /// </summary>
        /// <param name="authorName">Name of the author.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithAuthorName(string authorName);

        /// <summary>
        /// Assigns a color to the Slack message attachment.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithColor(string color);

        /// <summary>
        /// Assigns fallback text to the Slack message attachment.
        /// </summary>
        /// <param name="fallbackText">The fallback text.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithFallbackText(string fallbackText);

        /// <summary>
        /// Adds a footer to the Slack message attachment.
        /// </summary>
        /// <param name="footer">The footer.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithFooter(string footer);

        /// <summary>
        /// Adds a footer icon to the Slack message attachment.
        /// </summary>
        /// <param name="footerIcon">The footer icon.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithFooterIcon(string footerIcon);

        /// <summary>
        /// Adds an image URL to the Slack message attachment.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithImageUrl(string imageUrl);

        /// <summary>
        /// Adds pre-text to the Slack message attachment.
        /// </summary>
        /// <param name="pretext">The pretext.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithPretext(string pretext);

        /// <summary>
        /// Assigns a priority to the Slack message attachment.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithPriority(SlackMessagePriority priority);

        /// <summary>
        /// Adds an thumb URL to the Slack message attachment.
        /// </summary>
        /// <param name="thumbUrl">The thumb URL.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithThumbUrl(string thumbUrl);

        /// <summary>
        /// Adds a timestamp to the Slack message attachment.
        /// </summary>
        /// <param name="timeStamp">The time stamp.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithTimestamp(int timeStamp);

        /// <summary>
        /// Adds a title to the Slack message attachment.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithTitle(string title);

        /// <summary>
        /// Adds a title link to the Slack message attachment.
        /// </summary>
        /// <param name="titleLink">The title link.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithTitleLink(string titleLink);
    }
}