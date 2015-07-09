// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWorkFactory.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Data
{
	/// <summary>
	/// Defines a unit of work factory.
	/// </summary>
	public interface IUnitOfWorkFactory
	{
		#region Public Methods

		/// <summary>
		/// Creates a new Unit of Work.
		/// </summary>
		/// <returns>
		/// A Unit of Work.
		/// </returns>
		IUnitOfWork CreateUnitOfWork();

	    /// <summary>
	    /// Creates a new Unit of Work.
	    /// </summary>
	    /// <param name="unitOfWorkBatchMode">The Unit of Work batch mode.</param>
	    /// <returns>
	    /// A new Unit of Work.
	    /// </returns>
	    IUnitOfWork CreateUnitOfWork(UnitOfWorkBatchMode unitOfWorkBatchMode);

	    #endregion
	}
}