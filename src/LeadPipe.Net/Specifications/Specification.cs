// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace LeadPipe.Net.Specifications
{
    /// <summary>
    /// An abstract base class for specifications.
    /// </summary>
    /// <typeparam name="T">
    /// The expression type.
    /// </typeparam>
    public abstract class Specification<T> : ISpecification<T>
    {
        /// <summary>
        /// Implements the operator !.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Specification<T> operator !(Specification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }

        /// <summary>
        /// Implements the operator &amp;.
        /// </summary>
        /// <param name="leftSideSpecification">The left side specification.</param>
        /// <param name="rightSideSpecification">The right side specification.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Specification<T> operator &(
            Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
        {
            return new AndSpecification<T>(leftSideSpecification, rightSideSpecification);
        }

        /// <summary>
        /// Implements the operator |.
        /// </summary>
        /// <param name="leftSideSpecification">The left side specification.</param>
        /// <param name="rightSideSpecification">The right side specification.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Specification<T> operator |(
            Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
        {
            return new OrSpecification<T>(leftSideSpecification, rightSideSpecification);
        }

        /// <summary>
        /// Implements the operator false.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator false(Specification<T> specification)
        {
            return false;
        }

        /// <summary>
        /// Implements the operator true.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator true(Specification<T> specification)
        {
            return false;
        }

        /// <summary>
        /// Defines the expression that satisfies this specification.
        /// </summary>
        /// <returns>
        /// The expression that satisfies this specification.
        /// </returns>
        public abstract Expression<Func<T, bool>> SatisfiedBy();
    }
}