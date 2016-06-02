// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions WordWrap Tests.
    /// </summary>
    [TestFixture]
    public class WordWrapShould
    {
        /// <summary>
        /// Test that it break the lines after the characters per line are exceeded.
        /// </summary>
        [Test]
        public void BreakLinesAfterCharactersPerLineAreExceeded()
        {
            // Arrange
            const string UnwrappedString = "ORIGINAL STRING";
            int charactersPerLine = UnwrappedString.Length - 1;
            var newLineString = Environment.NewLine;

            // Act
            var wrappedString = UnwrappedString.WordWrap(charactersPerLine, newLineString);
            var lines = wrappedString.Split(new[] { newLineString }, StringSplitOptions.None);

            // Assert
            Assert.That(lines.Length, Is.EqualTo(2));
            Assert.That(lines[0], Is.EqualTo("ORIGINAL"));
            Assert.That(lines[1], Is.EqualTo("STRING"));
        }

        /// <summary>
        /// Breaks the lines after characters per line are exceeded when using an HTML tag.
        /// </summary>
        [Test]
        public void BreakLinesAfterCharactersPerLineAreExceededWhenUsingAnHtmlTag()
        {
            // Arrange
            const string UnwrappedString = "ORIGINAL STRING";
            int charactersPerLine = UnwrappedString.Length - 1;
            const string NewLineString = @"<br />";

            // Act
            var wrappedString = UnwrappedString.WordWrap(charactersPerLine, NewLineString);
            var lines = wrappedString.Split(new[] { NewLineString }, StringSplitOptions.None);

            // Assert
            Assert.That(lines.Length, Is.EqualTo(2));
            Assert.That(lines[0], Is.EqualTo("ORIGINAL"));
            Assert.That(lines[1], Is.EqualTo("STRING"));
        }

        /// <summary>
        /// Test that it does not add more line breaks when the string already contains line breaks.
        /// </summary>
        [Test]
        public void NotAddMoreLineBreaksWhenStringAlreadyContainsLineBreaks()
        {
            // Arrange
            const string UnwrappedString = "ORIGINAL\r\nSTRING";
            int charactersPerLine = UnwrappedString.Length;
            var newLineString = Environment.NewLine;

            // Act
            var wrappedString = UnwrappedString.WordWrap(charactersPerLine, newLineString);
            var lines = wrappedString.Split(new[] { newLineString }, StringSplitOptions.None);

            // Assert
            Assert.That(lines.Length, Is.EqualTo(2));
            Assert.That(lines[0], Is.EqualTo("ORIGINAL"));
            Assert.That(lines[1], Is.EqualTo("STRING"));
        }

        /// <summary>
        /// Test that it returns a string without line breaks.
        /// </summary>
        [Test]
        public void NotIncludeALineBreakWhenCharactersPerLineAreNotExceed()
        {
            // Arrange
            const string UnwrappedString = "ORIGINAL STRING";
            int charactersPerLine = UnwrappedString.Length;
            var newLineString = Environment.NewLine;

            // Act
            var wrappedString = UnwrappedString.WordWrap(charactersPerLine, newLineString);

            // Assert
            Assert.IsFalse(wrappedString.Contains(newLineString));
        }

        /// <summary>
        /// Test that it returns the original string when the characters per line are not exceeded.
        /// </summary>
        [Test]
        public void ReturnOriginalStringWhenTheCharactersPerLineAreNotExceeded()
        {
            // Arrange
            const string UnwrappedString = "ORIGINAL STRING";
            int charactersPerLine = UnwrappedString.Length;
            var newLineString = Environment.NewLine;

            // Act
            var wrappedString = UnwrappedString.WordWrap(charactersPerLine, newLineString);

            // Assert
            Assert.That(wrappedString, Is.EqualTo(UnwrappedString));
        }
    }
}