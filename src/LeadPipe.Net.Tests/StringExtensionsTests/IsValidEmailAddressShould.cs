// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions IsValidEmail tests.
    /// </summary>
    [TestFixture]
    public class IsValidEmailAddressShould
    {
        [TestCase(@"NotAnEmail", false)]
        [TestCase(@"@NotAnEmail", false)]
        [TestCase(@"""test\\blah""@example.com", true)]
        [TestCase(@"""test\blah""@example.com", false)]
        [TestCase("\"test\\\rblah\"@example.com", true)]
        [TestCase("\"test\rblah\"@example.com", false)]
        [TestCase(@"""test\""blah""@example.com", true)]
        [TestCase(@"""test""blah""@example.com", false)]
        [TestCase(@"customer/department@example.com", true)]
        [TestCase(@"$A12345@example.com", true)]
        [TestCase(@"!def!xyz%abc@example.com", true)]
        [TestCase(@"_Yosemite.Sam@example.com", true)]
        [TestCase(@"~@example.com", true)]
        [TestCase(@".wooly@example.com", false)]
        [TestCase(@"wo..oly@example.com", false)]
        [TestCase(@"pootietang.@example.com", false)]
        [TestCase(@".@example.com", false)]
        [TestCase(@"""Austin@Powers""@example.com", true)]
        [TestCase(@"Ima.Fool@example.com", true)]
        [TestCase(@"""Ima.Fool""@example.com", true)]
        [TestCase(@"""Ima Fool""@example.com", true)]
        [TestCase(@"Ima Fool@example.com", false)]
        public void ReturnCorrectResult(string stringToTest, bool expected)
        {
            // Arrange & Act

            var result = stringToTest.IsValidEmailAddress();

            // Assert

            Assert.That(result.Equals(expected));
        }
    }
}