// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NHibernate;
using System;
using System.Data;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// The NHibernate unit of work.
    /// </summary>
    /// <example>
    /// Sample usage:
    /// <code>
    /// using(unitOfWork.Start())
    /// {
    ///     // Do stuff...
    ///     //
    ///     unitOfWork.Commit();
    /// }
    /// </code>
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
        /// The flush mode.
        /// </summary>
        private readonly FlushMode defaultFlushMode;

        /// <summary>
        /// The isolation level.
        /// </summary>
        private readonly IsolationLevel defaultIsolationLevel;

        /// <summary>
        /// The action to take after a commit.
        /// </summary>
        private Action invokeAfterCommit;

        /// <summary>
        /// The action to take before a commit.
        /// </summary>
        private Action invokeBeforeCommit;

        /// <summary>
        /// The action to take on a commit exception.
        /// </summary>
        private Action _invokeOnCommitException;

        /// <summary>
        /// The action to take on a rollback.
        /// </summary>
        private Action invokeOnRollback;

        /// <summary>
        /// The nest level key.
        /// </summary>
        private string nestLevelKey = "LeadPipe.Net.Data.NHibernate.NestLevelKey";

        #endregion Constants and Fields

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dataSessionProvider">The data session provider.</param>
        /// <param name="activeDataSessionManager">The active data session manager.</param>
        /// <param name="flushMode">The flush mode.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        public UnitOfWork(
            IDataSessionProvider<ISession> dataSessionProvider,
            IActiveDataSessionManager<ISession> activeDataSessionManager,
            FlushMode flushMode = FlushMode.Auto,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,
            UnitOfWorkBatchMode unitOfWorkBatchMode = UnitOfWorkBatchMode.Singular)
        {
            this.dataSessionProvider = dataSessionProvider;
            this.activeDataSessionManager = activeDataSessionManager;
            this.defaultFlushMode = flushMode;
            this.defaultIsolationLevel = isolationLevel;

            this.UnitOfWorkBatchMode = unitOfWorkBatchMode;
        }

        #region Public Properties

        /// <summary>
        /// Gets the current NHibernate session.
        /// </summary>
        public ISession CurrentSession
        {
            get
            {
                return this.activeDataSessionManager.Current;
            }
        }

        /// <summary>
        /// The current NHibernate transaction.
        /// </summary>
        public ITransaction CurrentTransaction { get; private set; }

        /// <summary>
        /// Defines an action that occurs after the Unit of Work is committed.
        /// </summary>
        public Action InvokeAfterCommit
        {
            get { return this.invokeAfterCommit; }
            set { this.invokeAfterCommit = value; }
        }

        /// <summary>
        /// Defines an action that occurs before the Unit of Work is committed.
        /// </summary>
        public Action InvokeBeforeCommit
        {
            get { return this.invokeBeforeCommit; }
            set { this.invokeBeforeCommit = value; }
        }

        /// <summary>
        /// Defines an action that occurs if an exception occurs during commit.
        /// </summary>
        public Action InvokeOnCommitException
        {
            get { return this._invokeOnCommitException; }
            set { this._invokeOnCommitException = value; }
        }

        /// <summary>
        /// Defines an action that occurs immediately prior to the transaction being rolled back.
        /// </summary>
        public Action InvokeOnRollback
        {
            get { return this.invokeOnRollback; }
            set { this.invokeOnRollback = value; }
        }

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
        /// <value>The Unit of Work batch mode.</value>
        public UnitOfWorkBatchMode UnitOfWorkBatchMode { get; private set; }

        #endregion Public Properties

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
        /// <param name="isolationLevel">The isolation level to use when committing the transaction.</param>
        public void Commit(IsolationLevel isolationLevel)
        {
            Guard.Will.ThrowException("There is no current NHibernate session. Did you start the Unit of Work?").When(this.CurrentSession == null);

            // If we're using a singular transaction and we're not at the root then bail...
            if (this.UnitOfWorkBatchMode.Equals(UnitOfWorkBatchMode.Singular) && this.NestLevel > 0) return;

            try
            {
                if (this.invokeBeforeCommit.IsNotNull()) invokeBeforeCommit.Invoke();

                this.CurrentTransaction.Commit();

                if (this.invokeAfterCommit.IsNotNull()) invokeAfterCommit.Invoke();
            }
            catch (Exception ex)
            {
                try
                {
                    if (this._invokeOnCommitException.IsNotNull()) _invokeOnCommitException.Invoke();
                }
                finally
                {
                    this.Rollback();

                    throw new LeadPipeNetDataException("Unable to commit the transaction. See inner exception for details.", ex);
                }
            }
        }

        /// <summary>
        /// Disposes of the unit of work.
        /// </summary>
        public void Dispose()
        {
            // If someone is trying to dispose but we're nested then decrement the nest level and
            // bail (we can only dispose once everyone is done)...
            if (this.NestLevel > 0)
            {
                this.NestLevel--;
                return;
            }

            this.activeDataSessionManager.ClearActiveDataSession();
        }

        /// <summary>
        /// Rolls back the unit of work changes.
        /// </summary>
        public void Rollback()
        {
            try
            {
                if (this.invokeOnRollback.IsNotNull()) invokeOnRollback.Invoke();
            }
            catch (Exception ex)
            {
                throw new LeadPipeNetDataException("An error occurred during the rollback action invocation.", ex);
            }
            finally
            {
                /*
                 * Per Jason (http://nhibernate.info/blog/2009/09/08/part-9-nhibernate-transactions.html)...
                 *
                 * "The NHibernate ITransaction will perform an implicit rollback when it is
                 * disposed, unless an explicit call to Commit or Rollback has already occurred. To
                 * implement this behavior, [NHibernate implements] IDisposable in our transaction
                 * wrapper and chain our wrapper’s Dispose to NHibernate.ITransaction’s Dispose.
                 *
                 * This implicit rollback can indicate a missing call to Commit, so it generates an
                 * alert in NHibernate Profiler. If you intend to rollback, do it explicitly. Your
                 * code will be easier to understand."
                 *
                 * As such, we're performing an explicit rollback.
                 */

                this.CurrentTransaction.Rollback();

                /*
                 * As per the NHibernate documentation, we dispose after rollback to keep the
                 * session consistent REGARDLESS OF THE NEST LEVEL. Everybody's done. Kaput!
                 *
                 * http://nhibernate.info/doc/nhibernate-reference/manipulatingdata.html
                 */

                this.activeDataSessionManager.ClearActiveDataSession();
            }
        }

        public IUnitOfWork Start()
        {
            return this.Start(this.defaultFlushMode);
        }

        /// <summary>
        /// Starts the unit of work.
        /// </summary>
        /// <param name="flushMode">The flush mode.</param>
        /// <returns>A unit of work.</returns>
        /// <exception cref="LeadPipeNetDataException">
        /// The Unit of Work has already been started. or Unable to create an NHibernate session.
        /// Check your ISessionFactoryBuilder implementation.
        /// </exception>
        /// <remarks>
        /// This method creates and returns an instance of a unit of work. The IUnitOfWork interface
        /// implements IDisposable which means that a business transaction has ended when the
        /// UnitOfWork is disposed. It's important to remember that if we simply dispose of the unit
        /// of work then nothing will happen. If we want to propagate changes to the database, we
        /// have to call the Commit method on the unit of work.
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

            // If this is the first time we've been started or we've been instructed to create
            // nested transactions then begin a transaction...
            if (this.NestLevel == 0 || this.UnitOfWorkBatchMode.Equals(UnitOfWorkBatchMode.Nested)) this.CurrentTransaction = this.CurrentSession.BeginTransaction(defaultIsolationLevel);

            return this;
        }

        #endregion Public Methods
    }
}