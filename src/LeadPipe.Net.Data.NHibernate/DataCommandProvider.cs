// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// The NHibernate data command provider.
    /// </summary>
    public class DataCommandProvider : IDataCommandProvider
    {
        /// <summary>
        /// The active session manager.
        /// </summary>
        private readonly IActiveDataSessionManager<ISession> activeDataSessionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataCommandProvider"/> class.
        /// </summary>
        /// <param name="activeDataSessionManager">
        /// The active data session manager.
        /// </param>
        public DataCommandProvider(IActiveDataSessionManager<ISession> activeDataSessionManager)
        {
            this.activeDataSessionManager = activeDataSessionManager;
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        public ISession Session
        {
            get
            {
                return this.activeDataSessionManager.Current;
            }
        }

        /// <summary>
        /// Gets the total number of results for the last executed query.
        /// </summary>
        public int TotalResults
        {
            get
            {
                throw new NotImplementedException("This property is not supported with NHibernate at this time.");
            }
        }

        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object to create.</param>
        public virtual void Create(object obj)
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);
            Guard.Will.ThrowExceptionOfType<LeadPipeNetDataException>("There is no NHibernate session. Did you start a Unit of Work?").When(this.Session == null);

            this.Session.Save(obj);
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="obj">The object to delete.</param>
        public virtual void Delete(object obj)
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);
            Guard.Will.ThrowExceptionOfType<LeadPipeNetDataException>("There is no NHibernate session. Did you start a Unit of Work?").When(this.Session == null);

            this.Session.Delete(obj);
        }

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public T Get<T>(object id)
        {
            return this.Session.Get<T>(id);
        }

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public T Get<T>(string id)
        {
            return this.Session.Get<T>(id);
        }

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public T Load<T>(object id)
        {
            return this.Session.Load<T>(id);
        }

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public T Load<T>(string id)
        {
            return this.Session.Load<T>(id);
        }

        /// <summary>
        /// Provides the LINQ IQueryable hook.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>
        /// An IQueryable of the object type.
        /// </returns>
        public virtual IQueryable<T> Query<T>()
        {
            Guard.Will.ThrowExceptionOfType<LeadPipeNetDataException>("There is no NHibernate session. Did you start a Unit of Work?").When(this.Session == null);

            return this.Session.Query<T>();
        }

        /// <summary>
        /// Saves the specified object.
        /// </summary>
        /// <param name="obj">The object to save.</param>
        public virtual void Save(object obj)
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);
            Guard.Will.ThrowExceptionOfType<LeadPipeNetDataException>("There is no NHibernate session. Did you start a Unit of Work?").When(this.Session == null);

            this.Session.Save(obj);
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        public virtual void Update(object obj)
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);
            Guard.Will.ThrowExceptionOfType<LeadPipeNetDataException>("There is no NHibernate session. Did you start a Unit of Work?").When(this.Session == null);

            this.Session.Update(obj);
        }
    }
}