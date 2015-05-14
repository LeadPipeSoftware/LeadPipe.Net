// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClock.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net
{
	/// <summary>
	/// Allows for abstracting calls such as DateTime.Now particularly in unit tests.
	/// </summary>
	public interface IClock
	{
		/// <summary>
		/// Gets the current time.
		/// </summary>
		/// <returns>The current time.</returns>
		DateTime GetCurrentTime();

		/// <summary>
		/// Gets the current UTC time.
		/// </summary>
		/// <returns>The current UTC time.</returns>
		DateTime GetCurrentUtcTime();
	}
}