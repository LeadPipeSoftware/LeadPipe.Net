// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISpecification.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace LeadPipe.Net.Specifications
{
	/// <summary>
	/// Defines the interface for a specification.
	/// </summary>
	/// <typeparam name="T">The expression type.</typeparam>
	/// <remarks>
	/// For more information please refer to http://martinfowler.com/apsupp/spec.pdf or simply search for Specification
	/// Pattern on Wikipedia. Be aware, however, that this is a variant employing Linq and lambdas.
	/// </remarks>
	public interface ISpecification<T>
	{
		#region Public Methods

		/// <summary>
		/// Determines if the specification is satisfied by an expression lambda.
		/// </summary>
		/// <returns>
		/// The satisfaction expression.
		/// </returns>
		Expression<Func<T, bool>> SatisfiedBy();

		#endregion
	}
}