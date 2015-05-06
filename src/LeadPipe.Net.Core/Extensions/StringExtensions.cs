// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Extensions
{
	using System;
	using System.Collections;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Threading;

	using LeadPipeSoftware.Net.Core;

	/// <summary>
	/// A set of string extension methods.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Locates the position to break a given line so as to avoid breaking words.
		/// </summary>
		/// <param name="text">The text to evaluate.</param>
		/// <param name="startingIndex">The starting index.</param>
		/// <param name="maximumLineLength">The maximum line length.</param>
		/// <returns>
		/// The position to break the line so as to avoid breaking words.
		/// </returns>
		public static int BreakLine(this string text, int startingIndex, int maximumLineLength)
		{
			Guard.Will.ProtectAgainstNullArgument(() => text);

			// Find the last whitespace in the line...
			var i = maximumLineLength - 1;

			while (i >= 0 && !char.IsWhiteSpace(text[startingIndex + i]))
			{
				i--;
			}

			if (i < 0)
			{
				// No whitespace found so break at the maximum length...
				return maximumLineLength;
			}

			// Find the start of whitespace...
			while (i >= 0 && char.IsWhiteSpace(text[startingIndex + i]))
			{
				i--;
			}

			// Return the length of text before the whitespace...
			return i + 1;
		}

		/// <summary>
		/// Determines whether a string contains leading whitespace.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains leading whitespace; otherwise, <c>false</c>.
		/// </returns>
		public static bool ContainsLeadingWhiteSpace(this string stringToCheck)
		{
			return !string.IsNullOrEmpty(stringToCheck) && char.IsWhiteSpace(stringToCheck[0]);
		}

		/// <summary>
		/// Determines whether a string contains lower case characters.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains lower case characters; otherwise, <c>false</c>.
		/// </returns>
		public static bool ContainsLowerCaseCharacters(this string stringToCheck)
		{
			return stringToCheck.Any(char.IsLower);
		}

		/// <summary>
		/// Determines whether a string contains trailing whitespace.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains leading whitespace; otherwise, <c>false</c>.
		/// </returns>
		public static bool ContainsTrailingWhiteSpace(this string stringToCheck)
		{
			return !string.IsNullOrEmpty(stringToCheck) && char.IsWhiteSpace(stringToCheck[stringToCheck.Length - 1]);
		}

		/// <summary>
		/// Determines whether a string contains upper case characters.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains upper case characters; otherwise, <c>false</c>.
		/// </returns>
		public static bool ContainsUpperCaseCharacters(this string stringToCheck)
		{
			return stringToCheck.Any(char.IsUpper);
		}

		/// <summary>
		/// Determines whether a string contains whitespace.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains whitespace; otherwise, <c>false</c>.
		/// </returns>
		public static bool ContainsWhiteSpace(this string stringToCheck)
		{
			return stringToCheck.Any(char.IsWhiteSpace);
		}

		/// <summary>
		/// Returns the index of the first character that does not match.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="comparedWith">The string to use for comparison.</param>
		/// <param name="handleLengthDifference">
		/// If set to <c>true</c> the index will be returned even if the strings are of different lengths and the same-length parts are equal.
		/// </param>
		/// <returns>The index of the first character that does not match or -1 if the strings are identical.</returns>
		public static int FirstUnmatchedIndexOf(this string value, string comparedWith, bool handleLengthDifference = true)
		{
			var returnCode = -1;

			if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(comparedWith))
			{
				return handleLengthDifference ? 0 : returnCode;
			}

			var longest = comparedWith.Length > value.Length ? comparedWith : value;
			var shorten = comparedWith.Length > value.Length ? value : comparedWith;
			
			for (var i = 0; i < shorten.Length; i++)
			{
				if (shorten[i] != longest[i])
				{
					return i;
				}
			}

			/*
			 * Handle cases when length is different.
			 * 
			 * GIVEN handleLengthDifferences is True
			 *  WHEN value is 1234
			 *   AND comparedWith is 123
			 *  THEN returnCode should be 3
			 */
			if (handleLengthDifference && value.Length != comparedWith.Length)
			{
				return shorten.Length;
			}

			return returnCode;
		}

		/// <summary>
		/// A fluent helper for string formatting.
		/// </summary>
		/// <param name="stringToFormat">The string to format.</param>
		/// <param name="template">The formatting template.</param>
		/// <returns>
		/// The formatted string.
		/// </returns>
		public static string FormattedWith(this string stringToFormat, string template)
		{
			return string.Format(template, stringToFormat);
		}

		/// <summary>
		/// Helper to make formatting a string with multiple parameters easier.
		/// </summary>
		/// <param name="template">The string format.</param>
		/// <param name="args">The args.</param>
		/// <returns>System String.</returns>
		public static string FormattedWith(this string template, params object[] args)
		{
			return string.Format(template, args);
		}

		/// <summary>
		/// Gets the bytes.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>The Unicode encoded bytes representing the string.</returns>
		public static byte[] GetBytes(this string input)
		{
			var encoding = new UTF8Encoding();

			return encoding.GetBytes(input);
		}

		/// <summary>
		/// Gets the HTTP parameter value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="key">The key.</param>
		/// <returns>The value of the specified key.</returns>
		public static string GetHttpParameterValue(this string value, string key)
		{
			return value.Split('&').First(r => r.StartsWith(key)).Split('=').Skip(1).First();
		}

		/// <summary>
		/// Gets a count of the number of occurrences of a pattern in a string.
		/// </summary>
		/// /// <remarks>
		/// Given "say day bay toy" and "[sdbt]ay" this will return 3
		/// </remarks>
		/// <param name="input">The input.</param>
		/// <param name="pattern">The pattern.</param>
		/// <returns>The number of occurrences of the supplied pattern.</returns>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", 
			Justification = "Reviewed. Suppression is OK here.")]
		public static int GetOccurrenceCount(this string input, string pattern)
		{
			return input.GetOccurrences(pattern).Length;
		}

		/// <summary>
		/// Gets the occurrences of a pattern in a string.
		/// </summary>
		/// <remarks>
		/// Given "say day bay toy" and "[sdbt]ay" this will return new string[] { "say", "day", "bay" }
		/// </remarks>
		/// <param name="input">The input.</param>
		/// <param name="pattern">The pattern.</param>
		/// <returns>The occurrences of the supplied pattern.</returns>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", 
			Justification = "Reviewed. Suppression is OK here.")]
		public static string[] GetOccurrences(this string input, string pattern)
		{
			if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern))
			{
				return new string[] { };
			}

			var matches = Regex.Matches(input, pattern);

			var occurrences = new string[matches.Count];

			for (var i = 0; i < matches.Count; i++)
			{
				occurrences[i] = matches[i].Value;
			}

			return occurrences;
		}

		/// <summary>
		/// Determines whether a string contains only A-Z or a-z characters.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains only A-Z or a-z characters; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAlpha(this string stringToCheck)
		{
			if (string.IsNullOrEmpty(stringToCheck))
			{
				return false;
			}

			var expression = new Regex(@"^[a-zA-Z]*$");

			return expression.IsMatch(stringToCheck);
		}

		/// <summary>
		/// Determines whether a string contains only alphanumeric characters.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains only alphanumeric characters; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAlphanumeric(this string stringToCheck)
		{
			if (string.IsNullOrEmpty(stringToCheck))
			{
				return false;
			}

			var expression = new Regex(@"^[a-zA-Z0-9]*$");

			return expression.IsMatch(stringToCheck);
		}

		/// <summary>
		/// Determines whether a string contains only extended characters.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains only extended characters; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsExtendedCharacter(this string stringToCheck)
		{
			if (string.IsNullOrEmpty(stringToCheck))
			{
				return false;
			}

			// get the alphabet provider
			IAlphabetProvider provider = new EnglishAlphabetProvider();

			// get the extended character set
			var result = provider.GetExtendedCharacters().ToArray();

			// return false if the character in the string is not found in extended character set
			return stringToCheck.All(result.Contains);
		}

		/// <summary>
		/// Determines whether the string is null or empty.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [is null or empty] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullOrEmpty(this string value)
		{
			//// TODO: [GBM] Write unit tests.
			return string.IsNullOrEmpty(value);
		}

		/// <summary>
		/// Determines whether the string is null or whitespace.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [is null or white space] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullOrWhiteSpace(this string value)
		{
			//// TODO: [GBM] Write unit tests.
			return string.IsNullOrWhiteSpace(value);
		}

		/// <summary>
		/// Determines whether a string contains only numeric characters.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains only numeric characters; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNumeric(this string stringToCheck)
		{
			if (string.IsNullOrEmpty(stringToCheck))
			{
				return false;
			}

			var expression = new Regex(@"^[0-9]*$");

			return expression.IsMatch(stringToCheck);
		}

		/// <summary>
		/// Determines whether a string contains only printable characters.
		/// </summary>
		/// <param name="stringToCheck">The string to check.</param>
		/// <returns>
		///   <c>true</c> if the string contains only printable characters; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPrintableCharacter(this string stringToCheck)
		{
			if (string.IsNullOrEmpty(stringToCheck))
			{
				return false;
			}

			// get the alphabet provider
			IAlphabetProvider provider = new EnglishAlphabetProvider();

			// get the printable character set
			var result = provider.GetPrintableCharacters().ToArray();

			// return false if the character in the string is not found in printable character set
			return stringToCheck.All(result.Contains);
		}

		/// <summary>
		/// Returns a string containing a specified number of characters from the left side of a string.
		/// </summary>
		/// <param name="value">The string.</param>
		/// <param name="length">The number of characters to return. If 0, a zero-length string is returned. If greater than or equal to the number of characters in the string, the entire string is returned.</param>
		/// <returns>
		/// A string containing a specified number of characters from the left side of a string.
		/// </returns>
		public static string Left(this string value, int length)
		{
			//// TODO: [GBM] Write unit tests.
			if (string.IsNullOrEmpty(value) || length > value.Length || length < 0)
			{
				return value;
			}

			return value.Substring(0, length);
		}

		/// <summary>
		/// Reduces the specified input.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="maximumLength">The maximum length.</param>
		/// <returns>The reduced string.</returns>
		public static string Reduce(this string input, int maximumLength)
		{
			return input.Reduce(maximumLength, "...");
		}

		/// <summary>
		/// Reduces the specified input string to the specified length and appends ending characters.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="maximumLength">The maximum length.</param>
		/// <param name="ending">The ending.</param>
		/// <returns>The reduced string.</returns>
		public static string Reduce(this string input, int maximumLength, string ending)
		{
			if (maximumLength < ending.Length)
			{
				throw new Exception("The maximum length must be greater than the ending string length.");
			}

			var inputLength = input.Length;

			var len = inputLength;

			if (!string.IsNullOrEmpty(ending))
			{
				len += ending.Length;
			}

			// If the input string is less than the maximum length just return it back to the caller...
			if (maximumLength > inputLength)
			{
				return input;
			}

			input = input.Substring(0, inputLength - len + maximumLength);

			if (!string.IsNullOrEmpty(ending))
			{
				input += ending;
			}

			return input;
		}

		/// <summary>
		/// Returns a representation of the string with extra whitespace removed.
		/// </summary>
		/// <remarks>
		/// Given "  1 2     3     4   5 6 7  " this will return "1 2 3 4 5 6 7"
		/// </remarks>
		/// <param name="input">The input.</param>
		/// <returns>A representation of the string with extra whitespace removed.</returns>
		public static string RemoveExtraWhitespace(this string input)
		{
			return string.IsNullOrEmpty(input) ? input : Regex.Replace(input.Trim(), @"[ ]{2,}", @" ");
		}

		/// <summary>
		/// Repeats the specified string to repeat.
		/// </summary>
		/// <param name="stringToRepeat">The string to repeat.</param>
		/// <param name="repeat">The repeat.</param>
		/// <returns>The string repeated.</returns>
		public static string Repeat(this string stringToRepeat, int repeat)
		{
			//// TODO: [GBM] Write unit tests.
			var builder = new StringBuilder(repeat * stringToRepeat.Length);

			for (var i = 0; i < repeat; i++)
			{
				builder.Append(stringToRepeat);
			}

			return builder.ToString();
		}

		/// <summary>
		/// Replaces HTML BR breaks with newlines.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>The input string with HTML breaks replaced with newlines.</returns>
		public static string ReplaceBreaksWithNewlines(this string input)
		{
			return input.Replace("<br />", Environment.NewLine);
		}

		/// <summary>
		/// Replaces newlines with HTML BR breaks.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>The input string with newlines replaced with HTML breaks.</returns>
		public static string ReplaceNewlinesWithBreaks(this string input)
		{
			return input.Replace(Environment.NewLine, "<br />");
		}

		/// <summary>
		/// Returns a string containing a specified number of characters from the right side of a string.
		/// </summary>
		/// <param name="value">The string..</param>
		/// <param name="length">The number of characters to return. If 0, a zero-length string is returned. If greater than or equal to the number of characters in the string, the entire string is returned.</param>
		/// <returns>
		/// A string containing a specified number of characters from the right side of a string.
		/// </returns>
		public static string Right(this string value, int length)
		{
			//// TODO: [GBM] Write unit tests.
			if (string.IsNullOrEmpty(value) || length > value.Length || length < 0)
			{
				return value;
			}

			return value.Substring(value.Length - length);
		}

		/// <summary>
		/// Returns a friendly representation of the input string
		/// </summary>
		/// <remarks>
		/// Given "RandomValueProvider" this returns "Random Value Provider"
		/// </remarks>
		/// <param name="input">The input.</param>
		/// <returns>The friendly representation of the input string.</returns>
		public static string ToFriendlyName(this string input)
		{
			return Regex.Replace(input, @"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))", " $0");
		}

		/// <summary>
		/// Returns the MD5 hash string of the input string.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>The MD5 hash string of the input string.</returns>
		public static string ToMD5Hash(this string input)
		{
			var cryptoServiceProvider = new MD5CryptoServiceProvider();

			var newdata = Encoding.Default.GetBytes(input);

			var encrypted = cryptoServiceProvider.ComputeHash(newdata);

			cryptoServiceProvider.Dispose();

			return BitConverter.ToString(encrypted).Replace("-", string.Empty).ToLower();
		}

		/// <summary>
		/// Returns the title case representation of the input string.
		/// </summary>
		/// <remarks>
		/// Given "This is a string" this returns "This Is A String"
		/// </remarks>
		/// <param name="input">The input.</param>
		/// <returns>The title case representation of the input string.</returns>
		public static string ToTitleCase(this string input)
		{
			return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input);
		}

		/// <summary>
		/// Counts the number of words in a string.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>The number of words.</returns>
		public static int WordCount(this string input)
		{
			var collection = Regex.Matches(input, @"[\S]+");

			return collection.Count;
		}

		/// <summary>
		/// Words the wrap.
		/// </summary>
		/// <param name="textToWrap">
		/// The text to wrap.
		/// </param>
		/// <param name="charactersPerLine">
		/// The characters per line.
		/// </param>
		/// <returns>
		/// The wrapped text.
		/// </returns>
		public static string WordWrap(this string textToWrap, int charactersPerLine)
		{
			return WordWrap(textToWrap, charactersPerLine, Environment.NewLine);
		}

		/// <summary>
		/// Word wraps text to fit in a specified number of characters per line.
		/// </summary>
		/// <param name="textToWrap">
		/// The full title.
		/// </param>
		/// <param name="charactersPerLine">
		/// The characters per line.
		/// </param>
		/// <param name="newLineString">
		/// The new line string (ex: Environment.NewLine).
		/// </param>
		/// <returns>
		/// The wrapped text.
		/// </returns>
		public static string WordWrap(this string textToWrap, int charactersPerLine, string newLineString)
		{
			Guard.Will.ProtectAgainstNullArgument(() => textToWrap);
			Guard.Will.ProtectAgainstNullArgument(() => newLineString);

			int pos;
			int next;
			var wrappedTextBuilder = new StringBuilder();

			// Spit it back if there'value less than one character per line...
			if (charactersPerLine < 1)
			{
				return textToWrap;
			}

			// Parse each line of text...
			for (pos = 0; pos < textToWrap.Length; pos = next)
			{
				// Find the end of the line...
				var endOfLineIndex = textToWrap.IndexOf(newLineString, pos, StringComparison.Ordinal);

				if (endOfLineIndex == -1)
				{
					next = endOfLineIndex = textToWrap.Length;
				}
				else
				{
					next = endOfLineIndex + newLineString.Length;
				}

				// Copy this line of text, breaking into smaller lines as needed...
				if (endOfLineIndex > pos)
				{
					do
					{
						var len = endOfLineIndex - pos;

						if (len > charactersPerLine)
						{
							len = BreakLine(textToWrap, pos, charactersPerLine);
						}

						wrappedTextBuilder.Append(textToWrap, pos, len);

						wrappedTextBuilder.Append(newLineString);

						// Trim whitespace following break...
						pos += len;

						while (pos < endOfLineIndex && char.IsWhiteSpace(textToWrap[pos]))
						{
							pos++;
						}
					}
					while (endOfLineIndex > pos);
				}
				else
				{
					wrappedTextBuilder.Append(newLineString);
				}
			}

			var wrappedTextOutput = wrappedTextBuilder.ToString();

			if (wrappedTextOutput.EndsWith(newLineString))
			{
				wrappedTextOutput = wrappedTextOutput.Substring(
					0, wrappedTextOutput.LastIndexOf(newLineString, StringComparison.Ordinal));
			}

			return wrappedTextOutput;
		}

		/// <summary>
		/// Wraps each value in an enumeration with strings.
		/// </summary>
		/// <param name="values">The values.</param>
		/// <param name="before">The before.</param>
		/// <param name="after">The after.</param>
		/// <param name="separator">The separator.</param>
		/// <returns>The wrapped string.</returns>
		public static string WrapEachWith(this IEnumerable values, string before, string after, string separator)
		{
			return string.Join(
				separator, (from object value in values select string.Format("{0}{1}{2}", before, value, after)).ToArray());
		}
	}
}