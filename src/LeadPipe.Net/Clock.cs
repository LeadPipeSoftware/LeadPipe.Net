// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Clock.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Core
{
	/// <summary>
	/// Represents system time.
	/// </summary>
	public class Clock : IClock
	{
		/// <summary>
		/// Gets the current time.
		/// </summary>
		/// <returns>
		/// The current time.
		/// </returns>
		public DateTime GetCurrentTime()
		{
			return DateTime.Now;
		}

		/// <summary>
		/// Gets the current UTC time.
		/// </summary>
		/// <returns>
		/// The current UTC time.
		/// </returns>
		public DateTime GetCurrentUtcTime()
		{
			return DateTime.UtcNow;
		}
	}
}