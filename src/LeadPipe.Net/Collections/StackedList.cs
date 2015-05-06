// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StackedList.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Collections
{
	using System.Collections.ObjectModel;
	using System.Linq;

	/// <summary>
	/// The stacked list.
	/// </summary>
	/// <typeparam name="T">
	/// The stacked list type.
	/// </typeparam>
	public class StackedList<T>
	{
		#region Constants and Fields

		/// <summary>
		/// The items.
		/// </summary>
		private readonly ObservableCollection<T> items = new ObservableCollection<T>();

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the count.
		/// </summary>
		public int Count
		{
			get
			{
				return this.items.Count;
			}
		}

		/// <summary>
		/// Gets the items.
		/// </summary>
		public ObservableCollection<T> Items
		{
			get
			{
				return this.items;
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Elements at.
		/// </summary>
		/// <param name="index">
		/// The index.
		/// </param>
		/// <returns>
		/// The element at the index.
		/// </returns>
		public T ElementAt(int index)
		{
			return this.items.ElementAt(index);
		}

		/// <summary>
		/// Peeks this instance.
		/// </summary>
		/// <returns>
		/// The element at the top of the stacked list.
		/// </returns>
		public T Peek()
		{
			return this.items.Last();
		}

		/// <summary>
		/// The pop.
		/// </summary>
		/// <returns>
		/// The element at the top of the stacked list.
		/// </returns>
		public T Pop()
		{
			if (this.items.Count > 0)
			{
				T temp = this.items.Last();

				this.items.Remove(temp);

				return temp;
			}

			return default(T);
		}

		/// <summary>
		/// The push.
		/// </summary>
		/// <param name="item">
		/// The item.
		/// </param>
		public void Push(T item)
		{
			this.items.Add(item);
		}

		/// <summary>
		/// The remove.
		/// </summary>
		/// <param name="item">
		/// The item.
		/// </param>
		public void Remove(T item)
		{
			this.items.Remove(item);
		}

		#endregion
	}
}