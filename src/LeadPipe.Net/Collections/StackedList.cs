// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Linq;

namespace LeadPipe.Net.Collections
{
    /// <summary>
    /// The stacked list.
    /// </summary>
    /// <typeparam name="T">
    /// The stacked list type.
    /// </typeparam>
    public class StackedList<T>
    {
        /// <summary>
        /// The items.
        /// </summary>
        private readonly ObservableCollection<T> items = new ObservableCollection<T>();

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
    }
}