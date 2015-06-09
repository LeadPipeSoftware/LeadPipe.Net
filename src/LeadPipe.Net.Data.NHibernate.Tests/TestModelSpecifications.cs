// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestModelSpecifications.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Specifications;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
	/// <summary>
	/// The test model specifications.
	/// </summary>
	public static class TestModelSpecifications
	{
		#region Public Methods and Operators

		/// <summary>
		/// The test property starts with abc.
		/// </summary>
		/// <returns>
		/// Test Models that start with ABC.
		/// </returns>
		public static ISpecification<TestModel> TestPropertyStartsWithABC()
		{
			return new AdHocSpecification<TestModel>(x => x.TestProperty.StartsWith("ABC"));
		}

		#endregion
	}
}