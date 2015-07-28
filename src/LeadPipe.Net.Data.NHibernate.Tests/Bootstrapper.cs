// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Data.NHibernate.StructureMap;
using StructureMap;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
	/// <summary>
	/// The bootstrapper.
	/// </summary>
	public class Bootstrapper
	{
		#region Constructors and Destructors

		/// <summary>
		/// Prevents a default instance of the <see cref="Bootstrapper"/> class from being created.
		/// </summary>
		private Bootstrapper()
		{
		}

		#endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static Container AmbientContainer { get; protected set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
		/// The start.
		/// </summary>
		/// <returns>
		/// The started bootstrapper.
		/// </returns>
		public static Bootstrapper Start()
		{
			var bootstrapper = new Bootstrapper();

            AmbientContainer = new Container();

            LeadPipeNHibernateDataConfiguration.Initialize(AmbientContainer, typeof(UnitTestSessionFactoryBuilder));

            /*
             * It's only necessary to register repositories if you have custom implementations that
             * extend the base Repository class. If you do nothing, you'll simply get the generic
             * repository implementation.
             */

            LeadPipeNHibernateDataConfiguration.RegisterRepository<TestModel>(AmbientContainer, typeof(TestModelRepository));

			return bootstrapper;
		}

		#endregion
	}
}