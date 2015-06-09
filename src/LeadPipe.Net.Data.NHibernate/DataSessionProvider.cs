// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataSessionProvider.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
	/// <summary>
	/// The NHibernate data session provider.
	/// </summary>
	public class DataSessionProvider : IDataSessionProvider<ISession>
	{
		#region Constants and Fields

		/// <summary>
		/// The session factory builder.
		/// </summary>
		private readonly ISessionFactoryBuilder sessionFactoryBuilder;

		/// <summary>
		/// The session factory.
		/// </summary>
		private ISessionFactory sessionFactory;

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DataSessionProvider"/> class.
		/// </summary>
		/// <param name="sessionFactoryBuilder">The session factory.</param>
		public DataSessionProvider(ISessionFactoryBuilder sessionFactoryBuilder)
		{
			this.sessionFactoryBuilder = sessionFactoryBuilder;
		}

		#region Public Methods and Operators

		/// <summary>
		/// Creates an NHibernate data session instance.
		/// </summary>
		/// <returns>
		/// A new data session.
		/// </returns>
		public ISession Create()
		{
			Guard.Will.ThrowException("There is no NHibernate session factory.").When(this.sessionFactoryBuilder == null);

			if (this.sessionFactory == null)
			{
				this.sessionFactory = this.sessionFactoryBuilder.Build();
			}

			var session = this.sessionFactory.OpenSession();

			return session;
		}

		#endregion
	}
}