// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace LeadPipe.Net.Extensions
{
	/// <summary>
	/// The Enumerable extension methods.
	/// </summary>
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Appends the specified enumeration with an element.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="element">The element.</param>
		/// <returns>An enumeration with the element appended.</returns>
		public static IEnumerable<T> Append<T>(this IEnumerable<T> enumeration, T element)
		{
			//// TODO: [GBM] Write unit tests.
			foreach (var t in enumeration)
			{
				yield return t;
			}

			yield return element;
		}

		/// <summary>
		/// Determines whether the enumeration contains exactly the specified number of items.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="count">The count.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns><c>true</c> if the specified enumeration contains exactly; otherwise, <c>false</c>.</returns>
		public static bool ContainsExactly<T>(this IEnumerable<T> enumeration, int count, Func<T, bool> predicate)
		{
			//// TODO: [GBM] Write unit tests.
			Guard.Will.ProtectAgainstNullArgument(() => predicate);

			return enumeration != null && enumeration.Count(predicate).Equals(count);
		}

		/// <summary>
		/// Determines whether the enumeration contains none of an item.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns><c>true</c> if the specified enumeration contains none; otherwise, <c>false</c>.</returns>
		public static bool ContainsNone<T>(this IEnumerable<T> enumeration, Func<T, bool> predicate)
		{
			//// TODO: [GBM] Write unit tests.
			return ContainsExactly(enumeration, 0, predicate);
		}

		/// <summary>
		/// Determines whether the enumeration contains only one of an item.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns><c>true</c> if [contains only one] [the specified enumeration]; otherwise, <c>false</c>.</returns>
		public static bool ContainsOnlyOne<T>(this IEnumerable<T> enumeration, Func<T, bool> predicate)
		{
			//// TODO: [GBM] Write unit tests.
			return ContainsExactly(enumeration, 1, predicate);
		}

		/// <summary>
		/// Counts the number of times an item appears in a source.
		/// </summary>
		/// <typeparam name="T">The type of item in the source.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="item">The item.</param>
		/// <returns>The count.</returns>
		public static int CountItem<T>(this IEnumerable<T> source, T item)
		{
			//// TODO: [GBM] Write unit tests.
			return source.Count(x => x.Equals(item));
		}

		/// <summary>
		/// Excludes the specified enumeration.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="element">The element.</param>
		/// <returns>An enumeration with the element excluded.</returns>
		public static IEnumerable<T> Exclude<T>(this IEnumerable<T> enumeration, T element)
		{
			//// TODO: [GBM] Write unit tests.
			return enumeration.Where(t => !t.Equals(element));
		}

		/// <summary>
		/// Looks for a consecutive sequence of items that satisfy a predicate.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="sequence">The sequence.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="sequenceSize">Size of the sequence.</param>
		/// <returns>An enumeration of consecutive values that satisfy the predicate.</returns>
		/// <remarks>Let's say you have an IEnumerable of integers and you want to find 10 consecutive values that are greater
		/// than 100. This is your method!</remarks>
		public static IEnumerable<IEnumerable<T>> GetConsecutiveSequence<T>(this IEnumerable<T> sequence, Predicate<T> predicate, int sequenceSize)
		{
			//// TODO: [GBM] Write unit tests.
			var window = Enumerable.Repeat(default(T), 0);

			var count = 0;

			foreach (var item in sequence)
			{
				if (predicate(item))
				{
					window = window.Concat(Enumerable.Repeat(item, 1));

					count++;

					if (count == sequenceSize)
					{
						yield return window;

						window = window.Skip(1);

						count--;
					}
				}
				else
				{
					count = 0;

					window = Enumerable.Repeat(default(T), 0);
				}
			}
		}

		/// <summary>
		/// Gets the description attribute if it exist else it returns the name.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>A <see cref="System.String" /></returns>
		public static string GetDescription(this Enum value)
		{
			var type = value.GetType();
			var name = Enum.GetName(type, value);
			if (name != null)
			{
				var field = type.GetField(name);
				if (field != null)
				{
					var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
					if (attr != null)
					{
						return attr.Description;
					}
				}
			}

			return name;
		}

		/// <summary>
		/// Determines whether the specified source is empty.
		/// </summary>
		/// <typeparam name="T">The enumerable type.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns><c>true</c> if the specified source is empty; otherwise, <c>false</c>.</returns>
		public static bool IsEmpty<T>(this IEnumerable<T> source)
		{
			//// TODO: [GBM] Write unit tests.
			return !source.Any();
		}

		/// <summary>
		/// Determines whether an enumeration is null or empty.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns><c>true</c> if [is null or empty] [the specified source]; otherwise, <c>false</c>.</returns>
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
		{
			//// TODO: [GBM] Write unit tests.
			return source == null || !source.Any();
		}

		/// <summary>
		/// Returns an enumeration with default values filtered out.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns>An enumeration without default values.</returns>
		public static IEnumerable<T> NotDefault<T>(this IEnumerable<T> source)
		{
			//// TODO: [GBM] Write unit tests.
			return source.Where(e => !Equals(e, default(T)));
		}

		/// <summary>
		/// Shuffles the specified source.
		/// </summary>
		/// <typeparam name="T">The enumerable type.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns>A shuffled enumeration.</returns>
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			//// TODO: [GBM] Write unit tests.
			var array = source.ToArray();
			return ShuffleItems(array, array.Length);
		}

		/// <summary>
		/// Takes a random item from an enumeration.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="count">The count.</param>
		/// <returns>The random item.</returns>
		public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
		{
			//// TODO: [GBM] Write unit tests.
			var array = source.ToArray();
			return ShuffleItems(array, Math.Min(count, array.Length)).Take(count);
		}

		/// <summary>
		/// Converts the enumerable to an observable collection.
		/// </summary>
		/// <typeparam name="T">The type of enumeration.</typeparam>
		/// <param name="source">The source enumerable.</param>
		/// <returns>The enumerable as an observable collection.</returns>
		public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
		{
			//// TODO: [GBM] Write unit tests.
			var c = new ObservableCollection<T>();

			foreach (var e in source)
			{
				c.Add(e);
			}

			return c;
		}

        /// <summary>
        /// Gets the item in the enumeration based on the maximum of the specified property.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MaxBy(selector, Comparer<TKey>.Default);
        }

        /// <summary>
        /// Gets the item in the enumeration based on the maximum of the specified property.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">The supplied sequence contains no elements.</exception>
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {
            Guard.Will.ProtectAgainstNullArgument(() => source);
            Guard.Will.ProtectAgainstNullArgument(() => selector);
            Guard.Will.ProtectAgainstNullArgument(() => comparer);

            using (var sourceIterator = source.GetEnumerator())
            {
                if (!sourceIterator.MoveNext())
                {
                    throw new InvalidOperationException("The supplied sequence contains no elements.");
                }

                var max = sourceIterator.Current;

                var maxKey = selector(max);

                while (sourceIterator.MoveNext())
                {
                    var candidate = sourceIterator.Current;

                    var candidateProjected = selector(candidate);

                    if (comparer.Compare(candidateProjected, maxKey) <= 0) continue;

                    max = candidate;

                    maxKey = candidateProjected;
                }

                return max;
            }
        }

		/// <summary>
		/// Shuffles the items.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="array">The array.</param>
		/// <param name="count">The count.</param>
		/// <returns>A shuffled enumeration.</returns>
		private static IEnumerable<T> ShuffleItems<T>(T[] array, int count)
		{
			for (var n = 0; n < count; n++)
			{
				var k = RandomValueProvider.RandomInteger(n, array.Length);
				var temp = array[n];
				array[n] = array[k];
				array[k] = temp;
			}

			return array;
		}
	}
}