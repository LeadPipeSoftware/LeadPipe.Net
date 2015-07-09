// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkFactory.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
	/// <summary>
	/// The NHibernate unit of work factory.
	/// </summary>
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		#region Constants and Fields

		/// <summary>
		/// The active session manager.
		/// </summary>
		private readonly IActiveDataSessionManager<ISession> activeDataSessionManager;

		/// <summary>
		/// The data session provider.
		/// </summary>
		private readonly IDataSessionProvider<ISession> dataSessionProvider;

        /// <summary>
        /// The unit of work batch mode key.
        /// </summary>
        private readonly string unitOfWorkBatchModeKey = "LeadPipe.Net.Data.NHibernate.unitOfWorkBatchModeKey";

		#endregion

		#region Constructors and Destructors

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

            this.UnitOfWorkBatchMode = UnitOfWorkBatchMode.Singular;
		}

		#endregion

        #region Public Properties

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
                return (UnitOfWorkBatchMode)Local.Data[this.unitOfWorkBatchModeKey];
            }

            set
            {
                Local.Data[this.unitOfWorkBatchModeKey] = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
		public IUnitOfWork CreateUnitOfWork()
		{
			return new UnitOfWork(this.dataSessionProvider, this.activeDataSessionManager, unitOfWorkBatchMode: this.UnitOfWorkBatchMode);
		}

		#endregion
	}
}