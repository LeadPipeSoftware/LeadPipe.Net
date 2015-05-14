// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoolExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Extensions
{
	/// <summary>
	/// The Boolean type extensions.
	/// </summary>
	public static class BoolExtensions
	{
		#region Public Methods and Operators

		/// <summary>
		/// Executes the action if the Boolean value is true.
		/// </summary>
		/// <param name="obj">if set to <c>true</c> [obj].</param>
		/// <param name="action">The action.</param>
		/// <returns>The Boolean value.</returns>
		public static bool IfTrue(this bool obj, Action action)
		{
			//// TODO: [GBM] Write unit tests.

			if (obj)
			{
				action();
			}

			return obj;
		}

		/// <summary>
		/// Executes the action if the Boolean value is false.
		/// </summary>
		/// <param name="obj">if set to <c>true</c> [obj].</param>
		/// <param name="action">The action.</param>
		/// <returns>The Boolean value.</returns>
		public static bool IfFalse(this bool obj, Action action)
		{
			//// TODO: [GBM] Write unit tests.

			if (!obj)
			{
				action();
			}

			return obj;
		}

		/// <summary>
		/// Returns true if the Boolean value is false.
		/// </summary>
		/// <param name="obj">The Boolean object.</param>
		/// <returns>
		/// True if the Boolean value is false.
		/// </returns>
		public static bool IsFalse(this bool obj)
		{
			return obj != true;
		}

		/// <summary>
		/// Returns true if the Boolean value is true.
		/// </summary>
		/// <param name="obj">The Boolean object.</param>
		/// <returns>
		/// True if the Boolean value is true.
		/// </returns>
		public static bool IsTrue(this bool obj)
		{
			return obj;
		}

		/// <summary>
		/// Converts a Boolean value to the binary representation.
		/// </summary>
		/// <param name="obj">if set to <c>true</c> [obj].</param>
		/// <returns>1 if true, 0 if false</returns>
		public static int ToBinary(this bool obj)
		{
			//// TODO: [GBM] Write unit tests.

			return obj ? 1 : 0;
		}

		#endregion
	}
}