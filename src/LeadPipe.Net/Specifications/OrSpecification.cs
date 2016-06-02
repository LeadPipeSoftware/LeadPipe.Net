// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace LeadPipe.Net.Specifications
{
    /// <summary>
    /// A logical OR specification.
    /// </summary>
    /// <typeparam name="T">
    /// The expression type.
    /// </typeparam>
    public sealed class OrSpecification<T> : CompositeSpecification<T>
    {
        /// <summary>
        /// The left-hand side specification.
        /// </summary>
        private readonly ISpecification<T> leftSideSpecification;

        /// <summary>
        /// The right-hand side specification.
        /// </summary>
        private readonly ISpecification<T> rightSideSpecification;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrSpecification{T}"/> class.
        /// </summary>
        /// <param name="leftSide">
        /// The left-hand side specification.
        /// </param>
        /// <param name="rightSide">
        /// The right-hand side specification.
        /// </param>
        public OrSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            Guard.Will.ThrowArgumentNullException("leftSide").When(leftSide == null);
            Guard.Will.ThrowArgumentNullException("rightSide").When(rightSide == null);

            this.leftSideSpecification = leftSide;
            this.rightSideSpecification = rightSide;
        }

        /// <summary>
        /// The left-hand side specification.
        /// </summary>
        public override ISpecification<T> LeftSideSpecification
        {
            get
            {
                return this.leftSideSpecification;
            }
        }

        /// <summary>
        /// The right-hand side specification.
        /// </summary>
        public override ISpecification<T> RightSideSpecification
        {
            get
            {
                return this.rightSideSpecification;
            }
        }

        /// <summary>
        /// Returns the satisfaction expression.
        /// </summary>
        /// <returns>
        /// The satisfaction expression.
        /// </returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            var left = this.leftSideSpecification.SatisfiedBy();

            var right = this.rightSideSpecification.SatisfiedBy();

            return left.OrElse(right);
        }
    }
}