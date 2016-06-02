// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Domain
{
    /// <summary>
    /// The abstract base value object.
    /// </summary>
    public abstract class ValueObject : IValueObject
    {
        /*
         * It's very difficult (nearly impossible) to implement value object overrides of Equals and GetHashCode that
         * will work 100% reliably in a base such as this one. There are dozens of approaches and I've tried many of
         * them myself and I usually wind up getting burned in one way or another. I'm not the only one, either. The
         * Pluralsight guys have reached the same basic conclusion and, coincidentally, have implemented a similar
         * solution: http://blog.pluralsight.com/2012/01/21/domain-driven-design-in-c-equals-and-gethashcode-part-1/
         *
         * So what's the value of this type? I suppose it could be argued that it's merely a marker but I think that
         * it's most important function is to cry out loud and proud, "Hey! Stop that!" when we try to check for value
         * equality on an object that is intended as something that is defined by its values.
         *
         * For beginners and for folks like myself that despise tracking down value versus reference equality bugs, I
         * think that this type has value and I recommend using it as the value object base. For anyone that lives with
         * the "expert mode" turned on all the time, feel free to shrug your shoulders and move along. Don't say that
         * you weren't warned, though! :)
         */

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        public override bool Equals(object obj)
        {
            throw new NotImplementedException("Value Object implementations must explicitly override the Equals method.");
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        public override int GetHashCode()
        {
            throw new NotImplementedException("Value Object implementations must explicitly override the GetHashCode method.");
        }
    }
}