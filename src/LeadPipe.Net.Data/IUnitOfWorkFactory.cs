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
        #region Public Properties

        /// <summary>
        /// Gets or sets the Unit of Work batch mode.
        /// </summary>
        /// <value>
        /// The Unit of Work batch mode.
        /// </value>
        UnitOfWorkBatchMode UnitOfWorkBatchMode { get; set; }
        
        #endregion

        #region Public Methods

        /// <summary>
		/// Creates a new Unit of Work.
		/// </summary>
		/// <returns>
		/// A Unit of Work.
		/// </returns>
		IUnitOfWork CreateUnitOfWork();
	    
        #endregion
	}
}