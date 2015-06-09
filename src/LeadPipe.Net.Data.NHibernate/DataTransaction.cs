// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataTransaction.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
	/// <summary>
	/// An NHibernate implementation of IDataTransaction.
	/// </summary>
	public sealed class DataTransaction : IDataTransaction
	{
		#region Constants and Fields

		/// <summary>
		/// The NHibernate transaction.
		/// </summary>
		private readonly ITransaction transaction;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="DataTransaction"/> class.
		/// </summary>
		/// <param name="transaction">
		/// The transaction.
		/// </param>
		public DataTransaction(ITransaction transaction)
		{
			this.transaction = transaction;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Flushes the session and commits the transaction.
		/// </summary>
		public void Commit()
		{
			this.transaction.Commit();
		}

		/// <summary>
		/// Disposes the transaction.
		/// </summary>
		public void Dispose()
		{
			this.transaction.Dispose();
		}

		/// <summary>
		/// Forces the transaction to roll back.
		/// </summary>
		public void Rollback()
		{
			this.transaction.Rollback();
		}

		#endregion
	}
}