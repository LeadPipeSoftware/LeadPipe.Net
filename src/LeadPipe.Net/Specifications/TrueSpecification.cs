// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrueSpecification.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
		#region Public Methods

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

		#endregion
	}
}