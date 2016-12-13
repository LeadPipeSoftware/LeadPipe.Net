// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;

namespace LeadPipe.Net.Specifications
{
    /// <summary>
    /// A logical NOT specification.
    /// </summary>
    /// <typeparam name="T">
    /// The expression type.
    /// </typeparam>
    public sealed class NotSpecification<T> : Specification<T>
    {
        /// <summary>
        /// The original expression.
        /// </summary>
        private readonly Expression<Func<T, bool>> originalExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification{T}"/> class.
        /// Initializes a new instance of the <see cref="NotSpecification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="originalSpecification">
        /// The original specification.
        /// </param>
        public NotSpecification(ISpecification<T> originalSpecification)
        {
            Guard.Will.ThrowArgumentNullException("originalSpecification").When(originalSpecification == null);

            this.originalExpression = originalSpecification.SatisfiedBy();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification{T}"/> class.
        /// Initializes a new instance of the <see cref="NotSpecification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="originalSpecification">
        /// The original specification.
        /// </param>
        public NotSpecification(Expression<Func<T, bool>> originalSpecification)
        {
            Guard.Will.ThrowArgumentNullException("originalSpecification").When(originalSpecification == null);

            this.originalExpression = originalSpecification;
        }

        /// <summary>
        /// Returns the satisfaction expression.
        /// </summary>
        /// <returns>
        /// The satisfaction expression.
        /// </returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.Not(this.originalExpression.Body), this.originalExpression.Parameters.Single());
        }
    }
}