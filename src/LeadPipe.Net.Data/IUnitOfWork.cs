// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Data
{
	/// <summary>
	/// Defines a unit of work.
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		/*
		 * Martin Fowler defines the Unit of Work as follows:
		 * 
		 * "Maintains a list of objects affected by a business transaction and coordinates the writing out of changes
		 * and the resolution of concurrency problems."
		 * 
		 * Simply put, a unit of work's concern is to manage the changes you're making. The most important thing to
		 * note is the word "business" in Martin's definition. A database transaction may be a component of a unit of
		 * work, but a unit of work isn't just a database transaction.
		 */

		#region Public Properties

		/// <summary>
		/// Gets a value indicating whether the unit of work is started.
		/// </summary>
		bool IsStarted { get; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Commits the changes made in the unit of work.
		/// </summary>
		void Commit();

		/// <summary>
		/// Rolls back the unit of work changes.
		/// </summary>
		void Rollback();

		/// <summary>
		/// Starts the unit of work.
		/// </summary>
		/// <returns>A started unit of work.</returns>
		IUnitOfWork Start();

		#endregion
	}
}