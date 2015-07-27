// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Data;
using LeadPipe.Net.Extensions;
using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
	/// <summary>
	/// The NHibernate unit of work.
	/// </summary>
	/// <example>
	/// Sample usage:
	///   <code>
	/// using(unitOfWork.Start())
	/// {
	///     // Do stuff...
	///     //
	///     unitOfWork.Commit();
	/// }
	///   </code>
	/// </example>
	public sealed class UnitOfWork : IUnitOfWork
	{
		#region Constants and Fields

		/// <summary>
		/// The active data session manager.
		/// </summary>
		private readonly IActiveDataSessionManager<ISession> activeDataSessionManager;

        /// <summary>
        /// The data command provider.
        /// </summary>
	    private readonly IDataCommandProvider dataCommandProvider;

	    /// <summary>
		/// The data session provider.
		/// </summary>
		private readonly IDataSessionProvider<ISession> dataSessionProvider;	    

	    /// <summary>
        /// The isolation level.
        /// </summary>
        private readonly IsolationLevel defaultIsolationLevel;

        /// <summary>
        /// The flush mode.
        /// </summary>
        private readonly FlushMode defaultFlushMode;

        /// <summary>
        /// The nest level key.
        /// </summary>
	    private string nestLevelKey = "LeadPipe.Net.Data.NHibernate.NestLevelKey";

	    #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="dataSessionProvider">The data session provider.</param>
        /// <param name="activeDataSessionManager">The active data session manager.</param>
        /// <param name="dataCommandProvider">The data command provider.</param>
        /// <param name="flushMode">The flush mode.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
		public UnitOfWork(
			IDataSessionProvider<ISession> dataSessionProvider,
			IActiveDataSessionManager<ISession> activeDataSessionManager,
            IDataCommandProvider dataCommandProvider,
            FlushMode flushMode = FlushMode.Auto,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,
            UnitOfWorkBatchMode unitOfWorkBatchMode = UnitOfWorkBatchMode.Singular)
		{
			this.dataSessionProvider = dataSessionProvider;
			this.activeDataSessionManager = activeDataSessionManager;
            this.dataCommandProvider = dataCommandProvider;
            this.defaultFlushMode = flushMode;
            this.defaultIsolationLevel = isolationLevel;

            this.UnitOfWorkBatchMode = unitOfWorkBatchMode;
		}

	    #region Public Properties

	    /// <summary>
	    /// The current transaction.
	    /// </summary>
	    public ITransaction CurrentTransaction { get; private set; }

	    /// <summary>
	    /// Gets a value indicating whether the unit of work is started.
	    /// </summary>
	    public bool IsStarted
	    {
	        get { return this.CurrentSession != null; }
	    }

        /// <summary>
        /// Gets or sets the nest level.
        /// </summary>
        public int NestLevel
        {
            get
            {
                return (int)Local.Data[this.nestLevelKey];
            }

            private set
            {
                Local.Data[this.nestLevelKey] = value;
            }
        }

        /// <summary>
        /// Gets the Unit of Work batch mode.
        /// </summary>
        /// <value>
        /// The Unit of Work batch mode.
        /// </value>
        public UnitOfWorkBatchMode UnitOfWorkBatchMode { get; private set; }

	    #endregion

		#region Properties

		/// <summary>
		/// Gets the current session.
		/// </summary>
		private ISession CurrentSession
		{
			get
			{
				return this.activeDataSessionManager.Current;
			}
		}

		#endregion

		#region Public Methods

        /// <summary>
        /// Flushes the unit of work and commits the transaction.
        /// </summary>
        public void Commit()
        {
            /*
             * Serializeable   - Lock the entire table until the end of the transaction.
             * RepeatableRead  - Read and Write lock rows until the end of the transaction.
             * ReadCommitted   - Write lock rows until the end of the transaction, but only Read lock as long as
             *                   necessary. This is the SQL Server default.
             * ReadUncommitted - Read and Write lock rows only as long as necessary.
             * Chaos           - Only the highest priority of writes use locks.
             */

            this.Commit(defaultIsolationLevel);
        }

        /// <summary>
        /// Flushes the unit of work and commits the transaction.
        /// </summary>
        /// <param name="isolationLevel">
        /// The isolation level to use when committing the transaction.
        /// </param>
        public void Commit(IsolationLevel isolationLevel)
        {
            Guard.Will.ThrowException("There is no NHibernate session. Did you start the Unit of Work?").When(this.CurrentSession == null);

            // If we're using a singular transaction and we're not at the root then bail...
            if (this.UnitOfWorkBatchMode.Equals(UnitOfWorkBatchMode.Singular) && this.NestLevel > 0) return;

            try
            {
                this.CurrentTransaction.Commit();
            }
            catch (Exception ex)
            {
                this.CurrentTransaction.Rollback();

                throw new LeadPipeNetDataException("Unable to commit the transaction. See inner exception for details.", ex);
            }
        }

        /// <summary>
        /// Creates a new object.
        /// </summary>
        /// <param name="obj">
        /// The object to create.
        /// </param>
        public void Create<T>(T obj) where T : class
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);

            var enumerable = obj as System.Collections.IEnumerable;

            if (enumerable != null)
            {
                foreach (var item in enumerable)
                {
                    this.dataCommandProvider.Create(item);
                }
            }
            else
            {
                this.dataCommandProvider.Create(obj);
            }
        }

        /// <summary>
        /// Deletes an object.
        /// </summary>
        /// <param name="obj">The object to delete.</param>
        public void Delete<T>(T obj) where T : class
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);

            var enumerable = obj as System.Collections.IEnumerable;

            if (enumerable != null)
            {
                foreach (var item in enumerable)
                {
                    this.dataCommandProvider.Delete(item);
                }
            }
            else
            {
                this.dataCommandProvider.Delete(obj);
            }
        }

        /// <summary>
        /// Disposes of the unit of work.
        /// </summary>
        public void Dispose()
        {
            // If someone is trying to dispose but we're nested then decrement the nest level and bail (we can only dispose once everyone is done)...
            if (this.NestLevel > 0)
            {
                this.NestLevel--;
                return;
            }

            this.activeDataSessionManager.ClearActiveDataSession();
        }

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public T Load<T>(object id)
        {
            return this.dataCommandProvider.Load<T>(id);
        }

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public T Load<T>(string id)
        {
            return this.dataCommandProvider.Load<T>(id);
        }

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public T Get<T>(object id)
        {
            return this.dataCommandProvider.Get<T>(id);
        }

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public T Get<T>(string id)
        {
            return this.dataCommandProvider.Get<T>(id);
        }

        /// <summary>
        /// Rolls back the unit of work changes.
        /// </summary>
        public void Rollback()
        {
            this.Dispose();
        }

        /// <summary>
        /// Saves an object.
        /// </summary>
        /// <param name="obj">The object to save.</param>
        public void Save<T>(T obj) where T : class
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);

            var enumerable = obj as System.Collections.IEnumerable;

            if (enumerable != null)
            {
                foreach (var item in enumerable)
                {
                    this.dataCommandProvider.Save(item);
                }
            }
            else
            {
                this.dataCommandProvider.Save(obj);
            }
        }

        /// <summary>
        /// Starts the unit of work.
        /// </summary>
        /// <returns>
        /// A started unit of work.
        /// </returns>
        public IUnitOfWork Start()
        {
            return this.Start(this.defaultFlushMode);
        }

        /// <summary>
        /// Starts the unit of work.
        /// </summary>
        /// <param name="flushMode">The flush mode.</param>
        /// <returns>
        /// A unit of work.
        /// </returns>
        /// <exception cref="LeadPipeNetDataException">
        /// The Unit of Work has already been started.
        /// or
        /// Unable to create an NHibernate session. Check your ISessionFactoryBuilder implementation.
        /// </exception>
        /// <remarks>
        /// This method creates and returns an instance of a unit of work. The IUnitOfWork interface implements
        /// IDisposable which means that a business transaction has ended when the UnitOfWork is disposed. It's
        /// important to remember that if we simply dispose of the unit of work then nothing will happen. If we want to
        /// propagate changes to the database, we have to call the Commit method on the unit of work.
        /// </remarks>
        public IUnitOfWork Start(FlushMode flushMode)
        {
            // If we don't have a session then create one...
            if (this.CurrentSession.IsNull())
            {
                this.activeDataSessionManager.SetActiveDataSession(this.dataSessionProvider.Create());

                if (this.CurrentSession == null)
                {
                    throw new LeadPipeNetDataException("Unable to create an NHibernate session. Check your ISessionFactoryBuilder implementation.");
                }

                // Use the default flush mode if the caller didn't supply one...
                this.CurrentSession.FlushMode = flushMode == this.defaultFlushMode ? this.defaultFlushMode : flushMode;

                this.NestLevel = 0;
            }
            else // Otherwise, we already have a session so increment the nest level...
            {
                this.NestLevel++;
            }

            // If this is the first time we've been started or we've been instructed to create nested transactions then begin a transaction...
            if (this.NestLevel == 0 || this.UnitOfWorkBatchMode.Equals(UnitOfWorkBatchMode.Nested)) this.CurrentTransaction = this.CurrentSession.BeginTransaction(defaultIsolationLevel);

            return this;
        }

        /// <summary>
        /// Updates an object.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        public void Update<T>(T obj) where T : class
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);

            var enumerable = obj as System.Collections.IEnumerable;

            if (enumerable != null)
            {
                foreach (var item in enumerable)
                {
                    this.dataCommandProvider.Update(item);
                }
            }
            else
            {
                this.dataCommandProvider.Update(obj);
            }
        }

		#endregion
	}
}