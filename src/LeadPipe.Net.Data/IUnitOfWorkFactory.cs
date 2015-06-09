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
		/// Creates a unit of work.
		/// </summary>
		/// <returns>
		/// A unit of work.
		/// </returns>
		IUnitOfWork CreateUnitOfWork();

		#endregion
	}
}