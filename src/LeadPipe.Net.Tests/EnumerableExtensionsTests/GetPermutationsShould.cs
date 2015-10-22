// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPermutationsShould.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadPipe.Net.Tests.EnumerableExtensionsTests
{
    /// <summary>
    /// The GetPermutations tests.
    /// </summary>
    [TestFixture]
    public class GetPermutationsShould
    {
        #region Public Methods

        [Test]
        public void ReturnTheCorrectNumberOfPermutations()
        {
            // Arrange

            var l = new List<int> { 1, 2, 3, 4 };

            Console.WriteLine(l.GetPermutationCount().ToString().FormattedWith("There should be {0} permutations."));

            // Act

            var permutations = l.GetPermutations();

            Console.WriteLine(permutations.Count().ToString().FormattedWith("There are {0} permutations."));

            foreach (var item in permutations)
            {
                foreach (var value in item)
                {
                    Console.Write(value);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }

            // Assert

            Assert.That(l.GetPermutationCount().Equals(permutations.Count()));
        }

        #endregion Public Methods
    }
}