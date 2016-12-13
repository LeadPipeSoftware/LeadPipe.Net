// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Authorization;
using StructureMap;

namespace LeadPipe.Net.Lucene.Tests
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
                c.For<IAuthorizer>().Use<Authorizer>();
                c.For<IAuthorizationProvider>().Use<AuthorizationProvider>();
                c.For<IAuthorizationLogger>().Use<DebugAuthorizationLogger>();
            });

            return bootstrapper;
        }
    }
}