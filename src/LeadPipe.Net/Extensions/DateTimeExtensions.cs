// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Extensions
{
	/// <summary>
	/// DateTime extension methods.
	/// </summary>
	public static class DateTimeExtensions
	{
		#region Public Methods and Operators

		/// <summary>
		/// Gets a DateTime representing midnight on the current date
		/// </summary>
		/// <param name="current">The current date</param>
		/// <returns>A DateTime representing midnight on the current date.</returns>
		public static DateTime Midnight(this DateTime current)
		{
			var midnight = new DateTime(current.Year, current.Month, current.Day);

			return midnight;
		}

		/// <summary>
		/// Gets a DateTime representing noon on the current date
		/// </summary>
		/// <param name="current">The current date</param>
		/// <returns>A DateTime representing noon on the current date.</returns>
		public static DateTime Noon(this DateTime current)
		{
			var noon = new DateTime(current.Year, current.Month, current.Day, 12, 0, 0);

			return noon;
		}

		/// <summary>
		/// Combines a date with a time.
		/// </summary>
		/// <param name="datePart">The date part.</param>
		/// <param name="timePart">The time part.</param>
		/// <returns>The combined date and time.</returns>
		public static DateTime Combine(DateTime datePart, DateTime timePart)
		{
			return new DateTime(datePart.Year, datePart.Month, datePart.Day, timePart.Hour, timePart.Minute, timePart.Second, timePart.Millisecond);
		}

		/// <summary>
		/// Gets the first day in the month.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns>A DateTime representing the first day in the month.</returns>
		public static DateTime FirstDayInMonth(DateTime date)
		{
			return new DateTime(date.Year, date.Month, 1);
		}

		/// <summary>
		/// Determines whether the specified date is a weekend day.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns><c>true</c> if the specified date is weekend; otherwise, <c>false</c>.</returns>
		public static bool IsWeekend(this DateTime date)
		{
			//// TODO: Write unit tests.
			return date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;
		}

		/// <summary>
		/// Gets the last day in the month.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns>A DateTime representing the last day in the month.</returns>
		public static DateTime LastDayInMonth(DateTime date)
		{
			return FirstDayInMonth(date).AddMonths(1).AddDays(-1);
		}

		/// <summary>
		/// Gets the next date after a day of the week.
		/// </summary>
		/// <param name="dayOfWeek">The day of week.</param>
		/// <returns>A DateTime representing the next date after the supplied day of the week.</returns>
		public static DateTime Next(DayOfWeek dayOfWeek)
		{
			return dayOfWeek <= DateTime.Today.DayOfWeek
				? DateTime.Today.Date.AddDays((dayOfWeek - DateTime.Today.DayOfWeek) + 7)
				: DateTime.Today.Date.AddDays(dayOfWeek - DateTime.Today.DayOfWeek);
		}

		/// <summary>
		/// Gets the previous date after a day of the week.
		/// </summary>
		/// <param name="dayOfWeek">The day of week.</param>
		/// <returns>A DateTime representing the next date after the supplied day of the week.</returns>
		public static DateTime Previous(DayOfWeek dayOfWeek)
		{
			return dayOfWeek >= DateTime.Today.DayOfWeek
				? DateTime.Today.Date.AddDays((dayOfWeek - DateTime.Today.DayOfWeek) - 7)
				: DateTime.Today.Date.AddDays(dayOfWeek - DateTime.Today.DayOfWeek);
		}

		/// <summary>
		/// Gets the date that starts a week.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <param name="startDay">The start day.</param>
		/// <returns>
		/// A DateTime representing the start of the week.
		/// </returns>
		public static DateTime StartWeek(DateTime time, DayOfWeek startDay = DayOfWeek.Monday)
		{
			return time.Date.AddDays(startDay - time.DayOfWeek);
		}

		/// <summary>
		/// Gets the date that ends a week.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <param name="endDay">The end day.</param>
		/// <returns>
		/// A DateTime representing the end of the week.
		/// </returns>
		public static DateTime EndWeek(DateTime time, DayOfWeek endDay = DayOfWeek.Sunday)
		{
			return time.Date.AddDays(endDay - time.DayOfWeek);
		}

		/// <summary>
		/// Sets the time of the current date with minute precision.
		/// </summary>
		/// <param name="current">The current date.</param>
		/// <param name="hour">The hour.</param>
		/// <param name="minute">The minute.</param>
		/// <returns>The set time.</returns>
		public static DateTime SetTime(this DateTime current, int hour, int minute)
		{
			return SetTime(current, hour, minute, 0, 0);
		}

		/// <summary>
		/// Sets the time of the current date with second precision.
		/// </summary>
		/// <param name="current">The current date.</param>
		/// <param name="hour">The hour.</param>
		/// <param name="minute">The minute.</param>
		/// <param name="second">The second.</param>
		/// <returns>The set time.</returns>
		public static DateTime SetTime(this DateTime current, int hour, int minute, int second)
		{
			return SetTime(current, hour, minute, second, 0);
		}

		/// <summary>
		/// Sets the time of the current date with millisecond precision.
		/// </summary>
		/// <param name="current">The current date.</param>
		/// <param name="hour">The hour.</param>
		/// <param name="minute">The minute.</param>
		/// <param name="second">The second.</param>
		/// <param name="millisecond">The millisecond.</param>
		/// <returns>The set time.</returns>
		public static DateTime SetTime(this DateTime current, int hour, int minute, int second, int millisecond)
		{
			var setTime = new DateTime(current.Year, current.Month, current.Day, hour, minute, second, millisecond);

			return setTime;
		}

		#endregion
	}
}