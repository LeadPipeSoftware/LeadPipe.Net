// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecimalExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Extensions
{
	/// <summary>
	/// Decimal extension methods.
	/// </summary>
	public static class DecimalExtensions
	{
		#region Public Methods and Operators

		/// <summary>
		/// Returns the percent of the given total number.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <param name="total">The total.</param>
		/// <returns>
		/// The percent of the given total.
		/// </returns>
		public static decimal PercentOf(this decimal position, int total)
		{
			decimal result = 0;

			if (position > 0 && total > 0)
			{
				result = position / total * 100;
			}

			return result;
		}

		/// <summary>
		/// Returns the percent of the given total number.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <param name="total">The total.</param>
		/// <returns>
		/// The percent of the given total.
		/// </returns>
		public static decimal PercentOf(this decimal position, decimal total)
		{
			decimal result = 0;

			if (position > 0 && total > 0)
			{
				result = position / total * 100;
			}

			return result;
		}

		/// <summary>
		/// Returns the percent of the given total number.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <param name="total">The total.</param>
		/// <returns>
		/// The percent of the given total.
		/// </returns>
		public static decimal PercentOf(this decimal position, long total)
		{
			decimal result = 0;

			if (position > 0 && total > 0)
			{
				result = position / total * 100;
			}

			return result;
		}

		/// <summary>
		/// Returns the percentage of the given total number.
		/// </summary>
		/// <param name="number">The number.</param>
		/// <param name="percent">The percent.</param>
		/// <returns>
		/// The percentage of the given total.
		/// </returns>
		public static decimal PercentageOf(this decimal number, int percent)
		{
			return number * percent / 100;
		}

		/// <summary>
		/// Returns the percentage of the given total number.
		/// </summary>
		/// <param name="number">The number.</param>
		/// <param name="percent">The percent.</param>
		/// <returns>
		/// The percentage of the given total.
		/// </returns>
		public static decimal PercentageOf(this decimal number, decimal percent)
		{
			return number * percent / 100;
		}

		/// <summary>
		/// Returns the percentage of the given total number.
		/// </summary>
		/// <param name="number">The number.</param>
		/// <param name="percent">The percent.</param>
		/// <returns>
		/// The percentage of the given total.
		/// </returns>
		public static decimal PercentageOf(this decimal number, long percent)
		{
			return number * percent / 100;
		}

		#endregion
	}
}