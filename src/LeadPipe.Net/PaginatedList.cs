// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadPipe.Net
{
    /*
     * Hat tip to Scott Hanselman for this one.
     */

    /// <summary>
    /// Represents a paginated list.
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    public class PaginatedList<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        public PaginatedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));
        }

        /// <summary>
        /// Gets a value indicating whether [has next page].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [has next page]; otherwise, <c>false</c>.
        /// </value>
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }

        /// <summary>
        /// Gets a value indicating whether [has previous page].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [has previous page]; otherwise, <c>false</c>.
        /// </value>
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        /// <summary>
        /// Gets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; private set; }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Gets the total pages.
        /// </summary>
        /// <value>
        /// The total pages.
        /// </value>
        public int TotalPages { get; private set; }
    }
}