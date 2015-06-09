// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompositeSpecification.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
		#region Public Properties

		/// <summary>
		/// Gets the left-hand side specification for this composite specification.
		/// </summary>
		public abstract ISpecification<T> LeftSideSpecification { get; }

		/// <summary>
		/// Gets the right-hand side specification for this composite specification.
		/// </summary>
		public abstract ISpecification<T> RightSideSpecification { get; }

		#endregion
	}
}