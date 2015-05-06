// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomValueProvider.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Text;

	/// <summary>
	/// Provides random values.
	/// </summary>
	public static class RandomValueProvider
	{
		#region Constants and Fields

		/// <summary>
		/// The lorem ipsum words.
		/// </summary>
		private static readonly string[] LoremIpsumWords = new[]
			{
				"consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", 
				"dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et", 
				"justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", 
				"sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor"
			};

		/// <summary>
		/// The random seed.
		/// </summary>
		private static readonly Random RandomSeed = new Random();

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets a string of lorem ipsum.
		/// </summary>
		/// <param name="numberOfWords">The number of words.</param>
		/// <returns>A string consisting of lorem ipsum words ("Lorem ipsum dolor sit amet sed diam.").</returns>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		public static string LoremIpsum(int numberOfWords)
		{
			var result = new StringBuilder();

			result.Append("Lorem ipsum dolor sit amet");

			var random = new Random();

			for (var i = 0; i <= numberOfWords; i++)
			{
				result.Append(" " + LoremIpsumWords[random.Next(LoremIpsumWords.Length - 1)]);
			}

			result.Append(".");

			return result.ToString();
		}

		/// <summary>
		/// Returns a random Boolean value.
		/// </summary>
		/// <returns>A random Boolean value.</returns>
		public static bool RandomBool()
		{
			return RandomSeed.NextDouble() > 0.5;
		}

		/// <summary>
		/// Returns a random integer.
		/// </summary>
		/// <param name="min">The minimum random integer boundary.</param>
		/// <param name="max">The maximum random integer boundary.</param>
		/// <returns>A random integer.</returns>
		public static int RandomInteger(int min, int max)
		{
			return RandomSeed.Next(min, max);
		}

		/// <summary>
		/// Returns a random unsigned integer.
		/// </summary>
		/// <param name="max">The maximum random integer boundary.</param>
		/// <returns>A random unsigned integer.</returns>
		public static uint RandomUnsignedInteger(int max)
		{
			return (uint)RandomSeed.Next(0, max);
		}

		/// <summary>
		/// Gets random keys from a dictionary.
		/// </summary>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="dictionary">The dictionary.</param>
		/// <returns>An enumeration of random keys.</returns>
		/// <example>
		///   <code>
		/// Dictionary&lt;string, object%gt; dict = GetDictionary();
		/// foreach (string key in RandomKey(dict).Take(10))
		/// {
		/// Console.WriteLine(value);
		/// }
		/// </code>
		/// </example>
		/// <remarks>Bear in mind that this method does not concern itself with uniqueness. In other words, it may return a key
		/// from the dictionary more than once.</remarks>
		public static IEnumerable<TKey> RandomKeys<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
		{
			var rand = new Random();

			var keys = dictionary.Keys.ToList();

			var size = dictionary.Count;

			while (true)
			{
				yield return keys[rand.Next(size)];
			}
		}

		/// <summary>
		/// Generates a random string with the given length.
		/// </summary>
		/// <param name="size">Size of the string.</param>
		/// <param name="lowerCase">If true, generate a lowercase string.</param>
		/// <returns>A random string.</returns>
		public static string RandomString(int size, bool lowerCase)
		{
			var randomString = new StringBuilder(size);

			// ASCII start position (65 = A / 97 = a)...
			var start = lowerCase ? 97 : 65;

			// Add random chars...
			for (var i = 0; i < size; i++)
			{
				randomString.Append((char)((26 * RandomSeed.NextDouble()) + start));
			}

			return randomString.ToString();
		}

		/// <summary>
		/// Gets random values from a dictionary.
		/// </summary>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="dictionary">The dictionary.</param>
		/// <returns>An enumeration of random values.</returns>
		/// <example>
		///   <code>
		/// Dictionary&lt;string, object%gt; dict = GetDictionary();
		/// foreach (object value in RandomValues(dict).Take(10))
		/// {
		/// Console.WriteLine(value);
		/// }
		/// </code>
		/// </example>
		/// <remarks>Bear in mind that this method does not concern itself with uniqueness. In other words, it may return a
		/// value from the dictionary more than once.</remarks>
		public static IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
		{
			var rand = new Random();

			var values = dictionary.Values.ToList();

			var size = dictionary.Count;

			while (true)
			{
				yield return values[rand.Next(size)];
			}
		}

		/// <summary>
		/// Generates a random date between the date and times specified.
		/// </summary>
		/// <param name="minimum">The minimum date and time.</param>
		/// <param name="maximum">The maximum date and time.</param>
		/// <returns>A random date and time.</returns>
		public static DateTime RandomDateTime(DateTime minimum, DateTime maximum)
		{
			// Set the range...
			var range = new TimeSpan(maximum.Ticks - minimum.Ticks);

			// Fire up a new random date and time...
			return minimum + new TimeSpan((long)(range.Ticks * RandomSeed.NextDouble()));
		}

		/// <summary>
		/// Generates a random date between the years specified.
		/// </summary>
		/// <param name="minimumYear">The minimum year.</param>
		/// <param name="maximumYear">The maximum year.</param>
		/// <returns>A random date between the min and max years.</returns>
		public static DateTime RandomDateTime(int minimumYear, int maximumYear)
		{
			var minimum = new DateTime(minimumYear);
			var maximum = new DateTime(maximumYear);

			return RandomDateTime(minimum, maximum);
		}

		#endregion
	}
}