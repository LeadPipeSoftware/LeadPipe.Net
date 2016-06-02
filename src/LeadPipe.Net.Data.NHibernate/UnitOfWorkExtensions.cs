// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// Unit of Work extension methods.
    /// </summary>
    public static class UnitOfWorkExtensions
    {
        /// <summary>
        /// Currents the session.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <returns>ISession.</returns>
        public static ISession CurrentSession(this IUnitOfWork unitOfWork)
        {
            var nhibernateUnitOfWork = unitOfWork as UnitOfWork;

            return nhibernateUnitOfWork.IsNotNull() ? nhibernateUnitOfWork.CurrentSession : null;
        }
    }
}