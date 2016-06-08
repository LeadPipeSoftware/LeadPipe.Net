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
        /// <summary>
        /// Gets the result of the Slack API call.
        /// </summary>
        string Result { get; }
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
        /// Prepares a simple message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The client.</returns>
        ISlackOptionalValues Message(string message);

        /// <summary>
        /// Prepares a message with a message attachment.
        /// </summary>
        /// <returns>The client.</returns>
        ISlackAttachmentValues MessageWithAttachment { get; }
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
        /// A valid URL that displays a small 16x16px image to the left of the author name. Will only work if author name is present.
        /// </summary>
        /// <param name="authorIcon">The author icon.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithAuthorIcon(string authorIcon);

        /// <summary>
        /// A valid URL that will hyperlink the author name text. Will only work if author name is present.
        /// </summary>
        /// <param name="authorLink">The author link.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithAuthorLink(string authorLink);

        /// <summary>
        /// Small text used to display the author's name.
        /// </summary>
        /// <param name="authorName">Name of the author.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithAuthorName(string authorName);

        /// <summary>
        /// An optional value that can either be one of good, warning, danger, or any hex color code (eg. #439FE0). This value is used to color the border along the left side of the message attachment.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithColor(string color);

        /// <summary>
        /// A plain-text summary of the attachment. This text will be used in clients that don't show formatted text and should not contain any markup.
        /// </summary>
        /// <param name="fallbackText">The fallback text.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithFallbackText(string fallbackText);

        /// <summary>
        /// Add some brief text to help contextualize and identify an attachment. Limited to 300 characters and may be truncated further when displayed to users in environments with limited screen real estate.
        /// </summary>
        /// <param name="footer">The footer.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithFooter(string footer);

        /// <summary>
        /// Renders a small icon beside the footer text, provide a publicly accessible URL string in the footer icon field. You must also provide a footer for the field to be recognized.
        /// </summary>
        /// <param name="footerIcon">The footer icon.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithFooterIcon(string footerIcon);

        /// <summary>
        /// A valid URL to an image file that will be displayed inside a message attachment. Slack currently supports the following formats: GIF, JPEG, PNG, and BMP.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithImageUrl(string imageUrl);

        /// <summary>
        /// This is optional text that appears above the message attachment block.
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
        /// This is the main text in a message attachment, and can contain standard message markup.
        /// </summary>
        /// <remarks>The content will automatically collapse if it contains 700+ characters or 5+ linebreaks, and will display a "Show more..." link to expand the content.</remarks>
        /// <param name="text">The text.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithText(string text);

        /// <summary>
        /// A valid URL to an image file that will be displayed as a thumbnail on the right side of a message attachment. Slack currently supports the following formats: GIF, JPEG, PNG, and BMP.
        /// </summary>
        /// <param name="thumbUrl">The thumb URL.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithThumbUrl(string thumbUrl);

        /// <summary>
        /// Adds a timestamp (Epoch time) to the Slack message attachment.
        /// </summary>
        /// <param name="timeStamp">The time stamp.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithTimestamp(int timeStamp);

        /// <summary>
        /// The title is displayed as larger, bold text near the top of a message attachment.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithTitle(string title);

        /// <summary>
        /// The title link will turn the title into a hyperlink.
        /// </summary>
        /// <param name="titleLink">The title link.</param>
        /// <returns>The client.</returns>
        ISlackAttachmentValues WithTitleLink(string titleLink);
    }
}