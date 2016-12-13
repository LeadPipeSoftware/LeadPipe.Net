// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Data;
using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// The NHibernate unit of work factory.
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        /// <summary>
        /// The active session manager.
        /// </summary>
        private readonly IActiveDataSessionManager<ISession> activeDataSessionManager;

        /// <summary>
        /// The data session provider.
        /// </summary>
        private readonly IDataSessionProvider<ISession> dataSessionProvider;

        /// <summary>
        /// The flush mode key.
        /// </summary>
        private readonly string flushModeKey = "LeadPipe.Net.Data.NHibernate.flushModeKey";

        /// <summary>
        /// The isolation level key.
        /// </summary>
        private readonly string isolationLevelKey = "LeadPipe.Net.Data.NHibernate.isolationLevelKey";

        /// <summary>
        /// The unit of work batch mode key.
        /// </summary>
        private readonly string unitOfWorkBatchModeKey = "LeadPipe.Net.Data.NHibernate.unitOfWorkBatchModeKey";

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkFactory" /> class.
        /// </summary>
        /// <param name="dataSessionProvider">The data session provider.</param>
        /// <param name="activeDataSessionManager">The active data session manager.</param>
        public UnitOfWorkFactory(
            IDataSessionProvider<ISession> dataSessionProvider,
            IActiveDataSessionManager<ISession> activeDataSessionManager)
        {
            this.dataSessionProvider = dataSessionProvider;
            this.activeDataSessionManager = activeDataSessionManager;

            FlushMode = FlushMode.Auto;
            IsolationLevel = IsolationLevel.ReadCommitted;
            UnitOfWorkBatchMode = UnitOfWorkBatchMode.Singular;
        }

        /// <summary>
        /// Gets or sets the flush mode.
        /// </summary>
        /// <value>
        /// The flush mode.
        /// </value>
        public FlushMode FlushMode
        {
            get
            {
                return (FlushMode)Local.Data[flushModeKey];
            }

            set
            {
                Local.Data[flushModeKey] = value;
            }
        }

        /// <summary>
        /// Gets or sets the isolation level.
        /// </summary>
        /// <value>
        /// The isolation level.
        /// </value>
        public IsolationLevel IsolationLevel
        {
            get
            {
                return (IsolationLevel)Local.Data[isolationLevelKey];
            }

            set
            {
                Local.Data[isolationLevelKey] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Unit of Work batch mode.
        /// </summary>
        /// <value>
        /// The Unit of Work batch mode.
        /// </value>
        public UnitOfWorkBatchMode UnitOfWorkBatchMode
        {
            get
            {
                return (UnitOfWorkBatchMode)Local.Data[unitOfWorkBatchModeKey];
            }

            set
            {
                Local.Data[unitOfWorkBatchModeKey] = value;
            }
        }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(dataSessionProvider, activeDataSessionManager, FlushMode, IsolationLevel, UnitOfWorkBatchMode);
        }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <param name="flushMode">The flush mode.</param>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
        public IUnitOfWork CreateUnitOfWork(FlushMode flushMode)
        {
            return new UnitOfWork(dataSessionProvider, activeDataSessionManager, flushMode, IsolationLevel, UnitOfWorkBatchMode);
        }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
        public IUnitOfWork CreateUnitOfWork(IsolationLevel isolationLevel)
        {
            return new UnitOfWork(dataSessionProvider, activeDataSessionManager, FlushMode, isolationLevel, UnitOfWorkBatchMode);
        }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
        public IUnitOfWork CreateUnitOfWork(UnitOfWorkBatchMode unitOfWorkBatchMode)
        {
            return new UnitOfWork(dataSessionProvider, activeDataSessionManager, FlushMode, IsolationLevel, unitOfWorkBatchMode);
        }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <param name="flushMode">The flush mode.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
        public IUnitOfWork CreateUnitOfWork(FlushMode flushMode, IsolationLevel isolationLevel)
        {
            return new UnitOfWork(dataSessionProvider, activeDataSessionManager, flushMode, isolationLevel, UnitOfWorkBatchMode);
        }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <param name="flushMode">The flush mode.</param>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
        public IUnitOfWork CreateUnitOfWork(FlushMode flushMode, UnitOfWorkBatchMode unitOfWorkBatchMode)
        {
            return new UnitOfWork(dataSessionProvider, activeDataSessionManager, flushMode, IsolationLevel, unitOfWorkBatchMode);
        }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
        public IUnitOfWork CreateUnitOfWork(IsolationLevel isolationLevel, UnitOfWorkBatchMode unitOfWorkBatchMode)
        {
            return new UnitOfWork(dataSessionProvider, activeDataSessionManager, FlushMode, isolationLevel, unitOfWorkBatchMode);
        }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <param name="flushMode">The flush mode.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
        public IUnitOfWork CreateUnitOfWork(FlushMode flushMode, IsolationLevel isolationLevel, UnitOfWorkBatchMode unitOfWorkBatchMode)
        {
            return new UnitOfWork(dataSessionProvider, activeDataSessionManager, flushMode, isolationLevel, unitOfWorkBatchMode);
        }
    }
}