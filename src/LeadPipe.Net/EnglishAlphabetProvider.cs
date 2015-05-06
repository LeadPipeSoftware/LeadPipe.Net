// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnglishAlphabetProvider.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipeSoftware.Net.Core
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Provides English alphabet functions.
	/// </summary>
	public class EnglishAlphabetProvider : IAlphabetProvider
	{
		#region Public Methods

		/// <summary>
		/// Creates a random string composed of English alphabet characters.
		/// </summary>
		/// <param name="size">The size of the string to create.</param>
		/// <returns>
		/// A random string of the specified length.
		/// </returns>
		public string CreateRandomString(int size)
		{
			var random = new Random(DateTime.Now.Millisecond);

			var buffer = new char[size];

			for (int i = 0; i < size; i++)
			{
				buffer[i] = this.GetAlphabet().ElementAt(random.Next(this.GetAlphabet().Count()));
			}

			return new string(buffer);
		}

		/// <summary>
		/// Gets the alphabet characters.
		/// </summary>
		/// <returns>
		/// An IEnumerable of English alphabet characters.
		/// </returns>
		public IEnumerable<char> GetAlphabet()
		{
			// For every character from A to Z...
			for (char c = 'A'; c <= 'Z'; c++)
			{
				yield return c;
			}
		}

		/// <summary>
		/// Gets all the characters in the the alphabet after a specified character.
		/// </summary>
		/// <param name="alphabetCharacter">The alphabet character.</param>
		/// <returns>
		/// The characters in the the alphabet after the specified character.
		/// </returns>
		public IEnumerable<char> GetAlphabetAfter(char alphabetCharacter)
		{
			return this.GetAlphabet().Where(x => StringComparer.CurrentCulture.Compare(x, alphabetCharacter) > 0);
		}

		/// <summary>
		/// Gets all the characters in the the alphabet before a specified character.
		/// </summary>
		/// <param name="alphabetCharacter">The alphabet character.</param>
		/// <returns>
		/// The characters in the the alphabet before the specified character.
		/// </returns>
		public IEnumerable<char> GetAlphabetBefore(char alphabetCharacter)
		{
			return this.GetAlphabet().Where(x => StringComparer.CurrentCulture.Compare(x, alphabetCharacter) < 0);
		}

		/// <summary>
		/// Gets the one-based index of a character in the alphabet.
		/// </summary>
		/// <param name="alphabetCharacter">The alphabet character.</param>
		/// <returns>
		/// The one-based index of the character in the alphabet.
		/// </returns>
		public int GetLetterIndex(char alphabetCharacter)
		{
			var stringAlphabet = new string(this.GetAlphabet().ToArray());

			return stringAlphabet.IndexOf(alphabetCharacter) + 1;
		}

		/// <summary>
		/// Gets the printable characters.
		/// </summary>
		/// <returns>
		/// An IEnumerable of printable characters.
		/// </returns>
		public IEnumerable<char> GetPrintableCharacters()
		{
			var printableChars = new List<char>();

			// Ascii values of all upper and lower case alphabets, numbers 0 - 9 and special characters till the max ascii value of 126 
			for (int i = 32; i <= 126; i++)
			{
				// convert to a character
				char c = Convert.ToChar(i);

				// add to the list
				printableChars.Add(c);
			}

			return printableChars;
		}

		/// <summary>
		/// Gets the extended characters.
		/// </summary>
		/// <returns>
		/// An IEnumerable of extended characters.
		/// </returns>
		public IEnumerable<char> GetExtendedCharacters()
		{
			// list of extended characters 
			var extendedChars = new List<char> { Convert.ToChar(176), Convert.ToChar(177) };

			return extendedChars;
		}

		#endregion
	}
}