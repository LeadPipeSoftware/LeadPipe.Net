// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestChildMap.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
	/// <summary>
	/// The test model map.
	/// </summary>
	public class TestChildMap : ClassMapping<TestChildModel>
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="TestChildMap"/> class.
		/// </summary>
		public TestChildMap()
		{
			this.Id(x => x.Sid, m => m.Generator(Generators.GuidComb));

			this.Property(x => x.Key, m => m.Access(Accessor.ReadOnly));

			this.Property(x => x.TestProperty);
		}

		#endregion
	}
}