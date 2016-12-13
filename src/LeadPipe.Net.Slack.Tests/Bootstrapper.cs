// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using StructureMap;

namespace LeadPipe.Net.Slack.Tests
{
    /// <summary>
    /// Bootstraps the project.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="Bootstrapper"/> class from being created.
        /// </summary>
        private Bootstrapper()
        {
        }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static Container Container { get; protected set; }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns></returns>
        public static Bootstrapper Start()
        {
            var bootstrapper = new Bootstrapper();

            Container = new Container(c =>
            {
                c.For<ISlackConfiguration>().Use<SlackConfiguration>();
                c.For<ISlackMessagePoster>().Use<SlackMessagePoster>();
                c.For<ISlack>().Use<Slack>();
            });

            return bootstrapper;
        }
    }
}