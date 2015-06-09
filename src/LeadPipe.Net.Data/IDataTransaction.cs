// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataTransaction.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Data
{
	/// <summary>
	/// Defines a generic data transaction.
	/// </summary>
	public interface IDataTransaction : IDisposable
	{
		#region Public Methods

		/// <summary>
		/// Commits the transaction.
		/// </summary>
		void Commit();

		/// <summary>
		/// Rolls the transaction back.
		/// </summary>
		void Rollback();

		#endregion
	}
}