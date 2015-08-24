// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FuzzyDateTimeEqualityComparer.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;

namespace LeadPipe.Net.EqualityComparers
{
    /// <summary>
    /// A configurable DateTime equality comparer. Useful for comparing persisted DateTime.
    /// </summary>
    public class FuzzyDateTimeEqualityComparer : IEqualityComparer
    {
        private readonly TimeSpan maxDifference;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyDateTimeEqualityComparer"/> class.
        /// </summary>
        /// <param name="maxDifference">The maximum difference.</param>
        public FuzzyDateTimeEqualityComparer(TimeSpan maxDifference)
        {
            this.maxDifference = maxDifference;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="x">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            if (!(x is DateTime) || !(y is DateTime)) return x.Equals(y);
            
            var dt1 = (DateTime)x;
            var dt2 = (DateTime)y;
            var duration = (dt1 - dt2).Duration();
            
            return duration < maxDifference;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}