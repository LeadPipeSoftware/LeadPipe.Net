// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Data;
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

		#endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="dataSessionProvider">The data session provider.</param>
        /// <param name="activeDataSessionManager">The active data session manager.</param>
        /// <param name="flushMode">The flush mode.</param>
        /// <param name="isolationLevel">The isolation level.</param>
		public UnitOfWork(
			IDataSessionProvider<ISession> dataSessionProvider,
			IActiveDataSessionManager<ISession> activeDataSessionManager,
            FlushMode flushMode = FlushMode.Auto,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
		{
			this.dataSessionProvider = dataSessionProvider;
			this.activeDataSessionManager = activeDataSessionManager;
		    this.defaultFlushMode = flushMode;
            this.defaultIsolationLevel = isolationLevel;
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
			get
			{
				return this.CurrentSession != null;
			}
		}

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
			Guard.Will.ThrowException("There is no NHibernate session. Did you start a Unit of Work?").When(this.CurrentSession == null);

			try
			{
				this.CurrentTransaction.Commit();
			}
			catch (Exception ex)
			{
                this.CurrentTransaction.Rollback();
				throw new LeadPipeNetDataException("Unable to commit the transaction. See inner exception for details.", ex);
			}
			finally
			{
			    if (this.CurrentSession != null) CurrentSession.Dispose();
			}
		}

		/// <summary>
		/// Disposes of the unit of work.
		/// </summary>
		public void Dispose()
		{
			this.activeDataSessionManager.ClearActiveDataSession();
		}

		/// <summary>
		/// Rolls back the unit of work changes.
		/// </summary>
		public void Rollback()
		{
			this.Dispose();
		}

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
			if (this.IsStarted)
			{
				throw new LeadPipeNetDataException("The Unit of Work has already been started.");
			}

			this.activeDataSessionManager.SetActiveDataSession(this.dataSessionProvider.Create());

			if (this.CurrentSession == null)
			{
				throw new LeadPipeNetDataException("Unable to create an NHibernate session. Check your ISessionFactoryBuilder implementation.");
			}

            // Use the default flush mode if the caller didn't supply one...
            this.CurrentSession.FlushMode = flushMode == this.defaultFlushMode ? this.defaultFlushMode : flushMode;

            this.CurrentTransaction = this.CurrentSession.BeginTransaction(defaultIsolationLevel);

			return this;
		}

		#endregion
	}
}