// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestChildModel.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
	/// <summary>
	/// The test model.
	/// </summary>
	public class TestChildModel : PersistableObject<Guid>, IEntity
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="TestChildModel"/> class.
		/// </summary>
		/// <param name="testProperty">
		/// The test property.
		/// </param>
		public TestChildModel(string testProperty)
		{
			this.TestProperty = testProperty;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TestChildModel"/> class.
		/// </summary>
		protected TestChildModel()
		{
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the entity key.
		/// </summary>
		public virtual string Key
		{
			get
			{
				return this.TestProperty;
			}
		}

		/// <summary>
		/// Gets or sets the test property.
		/// </summary>
		public virtual string TestProperty { get; protected set; }

		#endregion
	}
}