// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Specifications
{
    /// <summary>
    /// Base class for composite specifications.
    /// </summary>
    /// <typeparam name="T">
    /// The strongly-typed expression.
    /// </typeparam>
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        /// <summary>
        /// Gets the left-hand side specification for this composite specification.
        /// </summary>
        public abstract ISpecification<T> LeftSideSpecification { get; }

        /// <summary>
        /// Gets the right-hand side specification for this composite specification.
        /// </summary>
        public abstract ISpecification<T> RightSideSpecification { get; }
    }
}