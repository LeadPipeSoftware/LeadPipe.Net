// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpressionExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;

namespace LeadPipe.Net.Specifications
{
	/// <summary>
	/// Extension methods for the Expression type.
	/// </summary>
	public static class ExpressionExtensions
	{
		#region Public Methods

		/// <summary>
		/// Merges the supplied expression using a bitwise AND operator.
		/// </summary>
		/// <typeparam name="T">
		/// The strongly-typed lambda expression.
		/// </typeparam>
		/// <param name="first">
		/// The right-hand expression.
		/// </param>
		/// <param name="second">
		/// The left-hand expression.
		/// </param>
		/// <returns>
		/// A new expression merged using a bitwise AND operator.
		/// </returns>
		public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
			return first.Compose(second, Expression.And);
		}

		/// <summary>
		/// Merges the supplied expression using a conditional AND operator.
		/// </summary>
		/// <typeparam name="T">
		/// The strongly-typed lambda expression.
		/// </typeparam>
		/// <param name="first">
		/// The right-hand expression.
		/// </param>
		/// <param name="second">
		/// The left-hand expression.
		/// </param>
		/// <returns>
		/// A new expression merged using a conditional AND operator.
		/// </returns>
		public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
			return first.Compose(second, Expression.AndAlso);
		}

		/// <summary>
		/// Compose two expressions by merging them into a new expression.
		/// </summary>
		/// <typeparam name="T">
		/// The strongly-typed lambda expression.
		/// </typeparam>
		/// <param name="first">
		/// The original expression instance.
		/// </param>
		/// <param name="second">
		/// The expression instance to merge.
		/// </param>
		/// <param name="merge">
		/// The function to merge.
		/// </param>
		/// <returns>
		/// A new merged expression.
		/// </returns>
		public static Expression<T> Compose<T>(
			this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
		{
			// Build the parameter map (from parameters of second to parameters of first)...
			var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

			// Replace the parameters in the second lambda expression with parameters from the first...
			var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

			// Apply the composition of lambda expression bodies to the parameters from the first expression...
			return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
		}

		/// <summary>
		/// Merges the supplied expression using a bitwise OR operator.
		/// </summary>
		/// <typeparam name="T">
		/// The strongly-typed lambda expression.
		/// </typeparam>
		/// <param name="first">
		/// The right-hand expression.
		/// </param>
		/// <param name="second">
		/// The left-hand expression.
		/// </param>
		/// <returns>
		/// A new expression merged using a bitwise OR operator.
		/// </returns>
		public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
			return first.Compose(second, Expression.Or);
		}

		/// <summary>
		/// Merges the supplied expression using a conditional OR operator.
		/// </summary>
		/// <typeparam name="T">
		/// The strongly-typed lambda expression.
		/// </typeparam>
		/// <param name="first">
		/// The right-hand expression.
		/// </param>
		/// <param name="second">
		/// The left-hand expression.
		/// </param>
		/// <returns>
		/// A new expression merged using a conditional OR operator.
		/// </returns>
		public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
			return first.Compose(second, Expression.OrElse);
		}

		#endregion
	}
}