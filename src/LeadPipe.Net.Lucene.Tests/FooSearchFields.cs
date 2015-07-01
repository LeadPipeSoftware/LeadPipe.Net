// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FooSearchFields.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Lucene.Tests
{
	/// <summary>
	/// The search fields.
	/// </summary>
	public class FooSearchFields
	{
		public static readonly string Id;

		public static readonly string Parrot;

		public static readonly string Bar;

		static FooSearchFields()
		{
			Id = "Id".ToLowerInvariant();
			Parrot = "Parrot".ToLowerInvariant();
			Bar = "Bar".ToLowerInvariant();
		}
	}
}