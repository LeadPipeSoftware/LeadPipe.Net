// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
    /// <summary>
    /// Defines an object that can parse a type.
    /// </summary>
    /// <typeparam name="T">The type to parse.</typeparam>
    public interface IParse<T>
    {
        /// <summary>
        /// Gets the unparsed value.
        /// </summary>
        /// <value>The unparsed value.</value>
        T UnparsedValue { get; }

        /// <summary>
        /// Parses this instance.
        /// </summary>
        /// <returns>The parsed value.</returns>
        T Parse();
    }
}