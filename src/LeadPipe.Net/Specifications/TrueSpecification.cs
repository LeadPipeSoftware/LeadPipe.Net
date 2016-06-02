// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace LeadPipe.Net.Specifications
{
    /// <summary>
    /// True specification.
    /// </summary>
    /// <typeparam name="T">
    /// Type in this specification.
    /// </typeparam>
    public sealed class TrueSpecification<T> : Specification<T>
        where T : class
    {
        /// <summary>
        /// Satisfied By
        /// </summary>
        /// <returns>
        /// True if satisfied.
        /// </returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            var result = true;

            Expression<Func<T, bool>> trueExpression = t => result;

            return trueExpression;
        }
    }
}