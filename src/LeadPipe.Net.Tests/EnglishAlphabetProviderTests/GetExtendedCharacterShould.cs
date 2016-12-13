// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadPipe.Net.Tests.EnglishAlphabetProviderTests
{
    /// <summary>
    /// GetExtendedCharacters tests.
    /// </summary>
    [TestFixture]
    public class GetExtendedCharacterShould
    {
        /// <summary>
        /// Tests to make sure we can get all the Extended characters.
        /// </summary>
        [Test]
        public void ReturnExtendedCharacters()
        {
            // Arrange
            var expectedCharacters = new List<char> { Convert.ToChar(176), Convert.ToChar(177) };

            IAlphabetProvider provider = new EnglishAlphabetProvider();

            // Act
            var result = new string(provider.GetExtendedCharacters().ToArray());

            // Assert
            Assert.AreEqual(expectedCharacters, result);
        }
    }
}