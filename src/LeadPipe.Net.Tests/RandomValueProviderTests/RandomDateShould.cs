// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomDateShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.RandomValueProviderTests
{
	using System;

	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// The random date test.
	/// </summary>
	[TestFixture]
	public class RandomDateShould
	{
		#region Public Methods

		/// <summary>
		/// Runs in a loop to create a bunch of random dates. Fails if an invalid date is created.
		/// </summary>
		[Test]
		public void ReturnValidDatesWithinTheMinimumAndMaximumYears()
		{
			DateTime date;

			// Create a bunch of dates and if it tries to create an invalid date an exception will be thrown...
			for (int i = 0; i < 3000; i++)
			{
				date = RandomValueProvider.RandomDateTime(
					RandomValueProvider.RandomInteger(1600, 1900), RandomValueProvider.RandomInteger(1901, 2100));
			}
		}

		#endregion
	}
}