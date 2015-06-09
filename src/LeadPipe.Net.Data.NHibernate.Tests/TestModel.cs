// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestModel.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
	/// <summary>
	/// The test model.
	/// </summary>
	public class TestModel : PersistableObject<Guid>, IEntity
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="TestModel"/> class.
		/// </summary>
		/// <param name="testProperty">
		/// The test property.
		/// </param>
		public TestModel(string testProperty)
		{
			this.TestProperty = testProperty;
			this.TestChildren = new List<TestChildModel>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TestModel"/> class.
		/// </summary>
		protected TestModel()
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

		/// <summary>
		/// Gets or sets the mutable test property.
		/// </summary>
		public virtual string MutableTestProperty { get; set; }

		/// <summary>
		/// Gets or sets the test child.
		/// </summary>
		public virtual TestChildModel TestChild { get; set; }

		/// <summary>
		/// Gets or sets the test children.
		/// </summary>
		public virtual IList<TestChildModel> TestChildren { get; set; }

		#endregion
	}
}