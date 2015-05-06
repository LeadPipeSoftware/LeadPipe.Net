// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Extensions
{
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// The List extension methods.
	/// </summary>
	public static class ListExtensions
	{
		#region Public Methods and Operators

		/// <summary>
		/// Adds all the elements in the specified enumeration to the list if not already present.
		/// </summary>
		/// <typeparam name="T">The list type.</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="items">The items.</param>
		/// <returns>True if the list changed. False otherwise.</returns>
		public static bool AddAll<T>(this IList<T> list, IEnumerable<T> items)
		{
			//// TODO: [GBM] Write unit tests.

			var itemsAdded = false;

			foreach (var item in items.Where(item => !list.Contains(item)))
			{
				list.Add(item);
				itemsAdded = true;
			}

			return itemsAdded;
		}

		/// <summary>
		/// Removes all the elements in the specified enumeration to the list if present.
		/// </summary>
		/// <typeparam name="T">The list type.</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="items">The items.</param>
		/// <returns>True if the list changed. False otherwise.</returns>
		public static bool RemoveAll<T>(this IList<T> list, IEnumerable<T> items)
		{
			//// TODO: [GBM] Write unit tests.

			var itemsRemoved = false;

			foreach (var item in items.Where(item => list.Contains(item)))
			{
				list.Remove(item);
				itemsRemoved = true;
			}

			return itemsRemoved;
		}

		/// <summary>
		/// Replaces the specified list item.
		/// </summary>
		/// <typeparam name="T">The list type.</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="item">The item.</param>
		/// <returns>
		/// True if the item was replaced. False otherwise.
		/// </returns>
		public static bool ReplaceSingleItem<T>(this List<T> list, T item) where T : class
		{
			//// TODO: [GBM] Write unit tests.

			return list.ReplaceItemAt(list.IndexOf(item), item);
		}

		/// <summary>
		/// Replaces the list item at a specified position.
		/// </summary>
		/// <typeparam name="T">The list type.</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="position">The position.</param>
		/// <param name="item">The item.</param>
		/// <returns>True if the item was replaced. False otherwise.</returns>
		public static bool ReplaceItemAt<T>(this IList<T> list, int position, T item)
		{
			//// TODO: [GBM] Write unit tests.

			if (position > list.Count - 1)
			{
				return false;
			}

			list.RemoveAt(position);

			list.Insert(position, item);

			return true;
		}

		#endregion
	}
}