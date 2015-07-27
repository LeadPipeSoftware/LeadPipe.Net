// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

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
        /// <value>
        /// <c>true</c> if this instance is started; otherwise, <c>false</c>.
        /// </value>
		bool IsStarted { get; }

        /// <summary>
        /// Gets the nest level.
        /// </summary>
        /// <value>
        /// The nest level.
        /// </value>
        int NestLevel { get; }

        /// <summary>
        /// Gets the Unit of Work batch mode.
        /// </summary>
        /// <value>
        /// The Unit of Work batch mode.
        /// </value>
        UnitOfWorkBatchMode UnitOfWorkBatchMode { get; }

		#endregion

		#region Public Methods

        /// <summary>
        /// Commits the changes made in the unit of work.
        /// </summary>
        void Commit();
        
        /// <summary>
        /// Creates an object.
        /// </summary>
        /// <param name="obj">The object to create.</param>
        void Create<T>(T obj) where T : class;

        /// <summary>
        /// Delete an object.
        /// </summary>
        /// <param name="obj">The object to delete.</param>
        void Delete<T>(T obj) where T : class;

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Load<T>(object id);

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Load<T>(string id);

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Get<T>(object id);

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Get<T>(string id);

        /// <summary>
        /// Rolls back the unit of work changes.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Saves an object.
        /// </summary>
        /// <param name="obj">The object to save.</param>
        void Save<T>(T obj) where T : class;

        /// <summary>
        /// Starts the unit of work.
        /// </summary>
        /// <returns>A started unit of work.</returns>
        IUnitOfWork Start();

        /// <summary>
        /// Updates an object.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        void Update<T>(T obj) where T : class;

		#endregion
	}
}