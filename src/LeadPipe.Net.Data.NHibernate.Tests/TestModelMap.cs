// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestModelMap.cs" company="Lead Pipe Software">
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
	public class TestModelMap : ClassMapping<TestModel>
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="TestModelMap"/> class.
		/// </summary>
		public TestModelMap()
		{
			this.Id(x => x.Sid, m => m.Generator(Generators.GuidComb));

			this.Property(x => x.Key, m => m.Access(Accessor.ReadOnly));

			this.Property(x => x.TestProperty);

			this.Property(x => x.MutableTestProperty);

			this.ManyToOne(x => x.TestChild, m =>
				{
					m.Lazy(LazyRelation.Proxy);
					m.Cascade(Cascade.All);
				});

			this.Bag(x => x.TestChildren, bag =>
			{
				bag.Inverse(false);
				bag.Cascade(Cascade.All);
			}, a => a.OneToMany());
		}

		#endregion
	}
}