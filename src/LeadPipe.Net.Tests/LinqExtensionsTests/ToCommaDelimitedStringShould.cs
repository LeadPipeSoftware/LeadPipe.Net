// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LeadPipe.Net.Tests.LinqExtensionsTests
{
    /// <summary>
    /// ToCommaDelimitedString LINQ extension method tests.
    /// </summary>
    public class ToCommaDelimitedStringShould
    {
        /// <summary>
        /// Tests to ensure that a comma delimited string is returned.
        /// </summary>
        [Test]
        public void ReturnCommaDelimitedString()
        {
            var data = new List<TestThing>
                {
                    new TestThing { Name = "Jenny", Number = 8675309 },
                    new TestThing { Name = "Tom", Number = 4 },
                    new TestThing { Name = "Dick", Number = 209234 }
                };

            var orderedData = (IOrderedQueryable<TestThing>)data.AsQueryable();

            var csv = orderedData.ToCommaDelimitedString();

            Assert.IsTrue(csv.Equals("Name,Number,\nJenny,8675309,\nTom,4,\nDick,209234,\n"));
        }
    }

    /// <summary>
    /// Just a plain old test thing.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Reviewed. Suppression is OK here.")]
    internal class TestThing
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number { get; set; }
    }
}