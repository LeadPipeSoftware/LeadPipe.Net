// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionFactoryBuilder.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
	/// <summary>
	/// A session factory builder.
	/// </summary>
	public interface ISessionFactoryBuilder
	{
		#region Public Methods and Operators

		/// <summary>
		/// Builds an NHibernate session factory instance.
		/// </summary>
		/// <returns>An NHibernate session factory.</returns>
		ISessionFactory Build();

		#endregion
	}
}