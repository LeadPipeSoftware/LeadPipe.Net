// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System;

namespace LeadPipe.Net.Tests.RandomValueProviderTests
{
    /// <summary>
    /// The random date tests.
    /// </summary>
    [TestFixture]
    public class RandomDateShould
    {
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
    }
}