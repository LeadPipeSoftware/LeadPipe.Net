// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// The Slack message priority.
    /// </summary>
    public class SlackMessagePriority : Enumeration<SlackMessagePriority>
    {
        /// <summary>
        /// Critical priority.
        /// </summary>
        public static readonly SlackMessagePriority Critical = new SlackMessagePriority(4, "Critical");

        /// <summary>
        /// High priority.
        /// </summary>
        public static readonly SlackMessagePriority High = new SlackMessagePriority(3, "High");

        /// <summary>
        /// Low priority.
        /// </summary>
        public static readonly SlackMessagePriority Low = new SlackMessagePriority(1, "Low");

        /// <summary>
        /// Medium priority.
        /// </summary>
        public static readonly SlackMessagePriority Medium = new SlackMessagePriority(2, "Medium");

        /// <summary>
        /// Not Applicable
        /// </summary>
        public static readonly SlackMessagePriority NotApplicable = new SlackMessagePriority(0, "N/A");

        /// <summary>
        /// Initializes a new instance of the <see cref="SlackMessagePriority"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="displayName">The display name.</param>
        public SlackMessagePriority(int value, string displayName)
            : base(value, displayName)
        {
        }
    }
}