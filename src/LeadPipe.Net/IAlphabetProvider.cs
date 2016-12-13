// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace LeadPipe.Net
{
    /// <summary>
    /// Provides alphabet functions.
    /// </summary>
    public interface IAlphabetProvider
    {
        /// <summary>
        /// Creates a random string composed of alphabet characters.
        /// </summary>
        /// <param name="size">
        /// The size of the string to create.
        /// </param>
        /// <returns>
        /// A random string of the specified length.
        /// </returns>
        string CreateRandomString(int size);

        /// <summary>
        /// Gets the alphabet characters.
        /// </summary>
        /// <returns>
        /// An IEnumerable of alphabet characters.
        /// </returns>
        IEnumerable<char> GetAlphabet();

        /// <summary>
        /// Gets all the characters in the the alphabet after a specified character.
        /// </summary>
        /// <param name="alphabetCharacter">
        /// The alphabet character.
        /// </param>
        /// <returns>
        /// The characters in the the alphabet after the specified character.
        /// </returns>
        IEnumerable<char> GetAlphabetAfter(char alphabetCharacter);

        /// <summary>
        /// Gets all the characters in the the alphabet before a specified character.
        /// </summary>
        /// <param name="alphabetCharacter">
        /// The alphabet character.
        /// </param>
        /// <returns>
        /// The characters in the the alphabet before a specified character.
        /// </returns>
        IEnumerable<char> GetAlphabetBefore(char alphabetCharacter);

        /// <summary>
        /// Gets the extended characters.
        /// </summary>
        /// <returns>An IEnumerable of extended characters.</returns>
        IEnumerable<char> GetExtendedCharacters();

        /// <summary>
        /// Gets the index of a character in the alphabet.
        /// </summary>
        /// <param name="alphabetCharacter">
        /// The alphabet character.
        /// </param>
        /// <returns>
        /// The index of the character in the alphabet.
        /// </returns>
        int GetLetterIndex(char alphabetCharacter);

        /// <summary>
        /// Gets the printable characters.
        /// </summary>
        /// <returns>An IEnumerable of printable characters.</returns>
        IEnumerable<char> GetPrintableCharacters();
    }
}