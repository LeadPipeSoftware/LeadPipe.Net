// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Dynamic;

namespace LeadPipe.Net.Extensions
{
    public static class ExpandoObjectExtensions
    {
        /// <summary>
        /// Converts an expando object to a dictionary.
        /// </summary>
        /// <param name="expando">The expando.</param>
        /// <returns>IDictionary&lt;System.String, System.Object&gt;.</returns>
        public static IDictionary<string, object> ToDictionary(this ExpandoObject expando)
        {
            return expando;
        }
    }
}