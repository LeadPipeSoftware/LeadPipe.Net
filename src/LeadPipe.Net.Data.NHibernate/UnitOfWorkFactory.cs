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
	        return this.CreateUnitOfWork(UnitOfWorkBatchMode.Singular);
	    }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <param name="unitOfWorkBatchMode">The Unit of Work batch mode.</param>
        /// <returns>
        /// A new Unit of Work.
        /// </returns>
		public IUnitOfWork CreateUnitOfWork(UnitOfWorkBatchMode unitOfWorkBatchMode)
		{
			return new UnitOfWork(this.dataSessionProvider, this.activeDataSessionManager, unitOfWorkBatchMode: unitOfWorkBatchMode);
		}

		#endregion
	}
}