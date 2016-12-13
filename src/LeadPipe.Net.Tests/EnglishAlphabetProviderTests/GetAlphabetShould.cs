// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System.Linq;

namespace LeadPipe.Net.Tests.EnglishAlphabetProviderTests
{
    /// <summary>
    /// GetAlphabet tests.
    /// </summary>
    [TestFixture]
    public class GetAlphabetShould
    {
        /// <summary>
        /// Tests to make sure we can get all the English alphabet characters.
        /// </summary>
        [Test]
        public void ReturnFullAlphabet()
        {
            // Arrange
            const string ExpectedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            IAlphabetProvider provider = new EnglishAlphabetProvider();

            // Act
            var result = new string(provider.GetAlphabet().ToArray());

            // Assert
            Assert.AreEqual(ExpectedCharacters, result);
        }
    }
}