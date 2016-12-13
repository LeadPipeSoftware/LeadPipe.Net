// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Extensions
{
    /// <summary>
    /// DateTime extension methods.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns a DateTime with its value set to Now minus the provided TimeSpan value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime Ago(this TimeSpan value)
        {
            return DateTime.Now.Subtract(value);
        }

        /// <summary>
        /// Returns a DateTime with its value set to Now minus the provided TimeSpan value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime AgoUtc(this TimeSpan value)
        {
            return DateTime.UtcNow.Subtract(value);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> with the specifed hour and, optionally
        /// provided minutes, seconds, and milliseconds.
        /// </summary>
        public static DateTime At(this DateTime date, int hour, int min = 0, int second = 0, int millisecond = 0)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, min, second, millisecond);
        }

        /// <summary>
        /// Returns a new instance of DateTime based on the provided date where the time is set to midnight
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime AtMidnight(this DateTime date)
        {
            return date.At(0);
        }

        /// <summary>
        /// Returns a new instance of DateTime based on the provided date where the time is set to noon
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime AtNoon(this DateTime date)
        {
            return date.At(12);
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
        /// Gets the first day in the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>A DateTime representing the first day in the month.</returns>
        public static DateTime FirstDayInMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Returns a DateTime with its value set to Now plus the provided TimeSpan value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime FromNow(this TimeSpan value)
        {
            return DateTime.Now.Add(value);
        }

        /// <summary>
        /// Returns a DateTime with its value set to Now plus the provided TimeSpan value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime FromNowUtc(this TimeSpan value)
        {
            return DateTime.UtcNow.Add(value);
        }

        /// <summary>
        /// Returns a new instance of DateTime based on the provided date where the year is set to the provided year
        /// </summary>
        /// <param name="date"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime In(this DateTime date, int year)
        {
            return new DateTime(year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }

        /// <summary>
        /// Determines whether the date is after the specified date.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="afterDate">The after date.</param>
        /// <param name="compareTime">if set to <c>true</c> compare time values.</param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime dt, DateTime afterDate, Boolean compareTime = false)
        {
            return compareTime
                ? dt >= afterDate
                : dt.Date >= afterDate.Date;
        }

        /// <summary>
        /// Determines whether the date is before the specified date.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="beforeDate">The before date.</param>
        /// <param name="compareTime">if set to <c>true</c> compare time values.</param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime dt, DateTime beforeDate, Boolean compareTime = false)
        {
            return compareTime
                ? dt <= beforeDate
                : dt.Date <= beforeDate.Date;
        }

        /// <summary>
        /// Determines whether the date is between the specified dates.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="compareTime">if set to <c>true</c> compare time values.</param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime dt, DateTime startDate, DateTime endDate, Boolean compareTime = false)
        {
            return compareTime
                ? dt >= startDate && dt <= endDate
                : dt.Date >= startDate.Date && dt.Date <= endDate.Date;
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
    }
}