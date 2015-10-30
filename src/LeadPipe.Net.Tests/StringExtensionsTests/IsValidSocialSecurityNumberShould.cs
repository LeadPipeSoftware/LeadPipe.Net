// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsValidSocialSecurityNumberShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions IsValidSocialSecurityNumber tests.
    /// </summary>
    [TestFixture]
    public class IsValidSocialSecurityNumberShould
    {
        #region Public Methods

        [TestCase(@"447-74-7263", true)]
        [TestCase(@"blarg", false)]
        [TestCase(@"900-74-7263", false)]
        [TestCase(@"999-74-7263", false)]
        [TestCase(@"959-74-7263", false)]
        [TestCase(@"447747263", true)]
        [TestCase(@"000-74-7263", false)]
        [TestCase(@"666-74-7263", false)]
        [TestCase(@"447-74-763", false)]
        [TestCase(@"447-4-7263", false)]
        [TestCase(@"447-74-723", false)]
        public void ReturnCorrectResultWhenDashesAreNotForced(string stringToTest, bool expected)
        {
            // Arrange & Act

            var result = stringToTest.IsValidSocialSecurityNumber();

            // Assert

            Assert.That(result.Equals(expected));
        }

        [TestCase(@"447-74-7263", true)]
        [TestCase(@"447747263", false)]
        public void ReturnCorrectResultWhenDashesAreForced(string stringToTest, bool expected)
        {
            // Arrange & Act

            var result = stringToTest.IsValidSocialSecurityNumber(true);

            // Assert

            Assert.That(result.Equals(expected));
        }

        #endregion
    }
}