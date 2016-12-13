// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// A session factory builder.
    /// </summary>
    public interface ISessionFactoryBuilder
    {
        /// <summary>
        /// Builds an NHibernate session factory instance.
        /// </summary>
        /// <returns>An NHibernate session factory.</returns>
        ISessionFactory Build();
    }
}