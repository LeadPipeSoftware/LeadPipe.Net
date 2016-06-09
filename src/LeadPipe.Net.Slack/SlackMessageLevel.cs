// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// The Slack message level.
    /// </summary>
    public class SlackMessageLevel : Enumeration<SlackMessageLevel>
    {
        // NOTE (GBM): To make things a little easier, we're just adopting Log4Net's message levels

        /// <summary>
        /// Debug level.
        /// </summary>
        public static readonly SlackMessageLevel Debug = new SlackMessageLevel(1, "Debug", "good", "Debug Message");


        /// <summary>
        /// Error level.
        /// </summary>
        public static readonly SlackMessageLevel Error = new SlackMessageLevel(3, "Error", "danger", "Error Message");


        /// <summary>
        /// Fatal level.
        /// </summary>
        public static readonly SlackMessageLevel Fatal = new SlackMessageLevel(4, "Fatal", "danger", "Fatality Message");


        /// <summary>
        /// Information level.
        /// </summary>
        public static readonly SlackMessageLevel Info = new SlackMessageLevel(0, "Info", "good", "Info Message");


        /// <summary>
        /// Warn level.
        /// </summary>
        public static readonly SlackMessageLevel Warn = new SlackMessageLevel(2, "Warn", "warning", "Warning Message");

        /// <summary>
        /// Initializes a new instance of the <see cref="SlackMessageLevel"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="messageColor">Color of the message.</param>
        /// <param name="defaultTitle">The default title.</param>
        public SlackMessageLevel(int value, string displayName, string messageColor, string defaultTitle)
            : base(value, displayName)
        {
            MessageColor = messageColor;
            DefaultTitle = defaultTitle;
        }

        /// <summary>
        /// Gets or sets the default title.
        /// </summary>
        /// <value>
        /// The default title.
        /// </value>
        public string DefaultTitle { get; protected set; }

        /// <summary>
        /// Gets or sets the color of the message.
        /// </summary>
        /// <value>
        /// The color of the message.
        /// </value>
        public string MessageColor { get; protected set; }
    }
}