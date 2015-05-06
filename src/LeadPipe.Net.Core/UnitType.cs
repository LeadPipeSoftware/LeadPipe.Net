// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitType.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
	/// <summary>
	/// Represents void as a value.
	/// </summary>
	public sealed class UnitType
	{
		/*
		 * NOTE: In F#, UnitType represents void so that you can still return a value. This implementation lets us do
		 *       things like define a type that *conceptually* has void as a generic argument. UnitType represents that
		 *       conceptual void.
		 */

		/// <summary>
		/// The default.
		/// </summary>
		public static readonly UnitType Default = new UnitType();

		/// <summary>
		/// Prevents a default instance of the <see cref="UnitType"/> class from being created.
		/// </summary>
		private UnitType()
		{
		}
	}
}