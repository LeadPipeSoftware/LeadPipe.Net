// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Extensions
{
	using System.Collections.Generic;
	using System.Dynamic;

	/// <summary>
	/// The Dictionary extensions.
	/// </summary>
	public static class DictionaryExtensions
	{
		#region Public Methods and Operators

		/// <summary>
		/// Returns a new instance of System.Collections.Generic.SortedDictionary from the specified Dictionary using the default System.Collections.Generic.IComparer implementation for the key type.
		/// </summary>
		/// <typeparam name="TKey">The key type.</typeparam>
		/// <typeparam name="TValue">The value type.</typeparam>
		/// <param name="source">The source dictionary.</param>
		/// <returns>A new sorted dictionary.</returns>
		public static SortedDictionary<TKey, TValue> Sort<TKey, TValue>(this Dictionary<TKey, TValue> source)
		{
			//// TODO: [GBM] Write unit tests.

			return new SortedDictionary<TKey, TValue>(source);
		}

		/// <summary>
		/// Returns a new instance of System.Collections.Generic.SortedDictionary from the specified Dictionary using the specified System.Collections.Generic.IComparer.
		/// </summary>
		/// <typeparam name="TKey">The key type.</typeparam>
		/// <typeparam name="TValue">The value type.</typeparam>
		/// <param name="source">The source dictionary.</param>
		/// <param name="comparer">The IComparer implementation.</param>
		/// <returns>A new sorted dictionary.</returns>
		public static SortedDictionary<TKey, TValue> Sort<TKey, TValue>(this Dictionary<TKey, TValue> source, IComparer<TKey> comparer)
		{
			//// TODO: [GBM] Write unit tests.

			return new SortedDictionary<TKey, TValue>(source, comparer);
		}

		/// <summary>
		/// Converts the IDictionary instance into an ExpandoObject.
		/// </summary>
		/// <param name="dictionary">The source dictionary.</param>
		/// <returns>A new ExpandoObject.</returns>
		public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary)
		{
			//// TODO: [GBM] Write unit tests.

			var expando = new ExpandoObject();
			var expandoDict = (IDictionary<string, object>)expando;

			foreach (var item in dictionary)
			{
				if (item.Value is IDictionary<string, object>)
				{
					var d = (IDictionary<string, object>)item.Value;
					expandoDict.Add(item.Key, d.ToExpando());
				}
				else
				{
					expandoDict.Add(item);
				}
			}

			return expando;
		}

		#endregion
	}
}