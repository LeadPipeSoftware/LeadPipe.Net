// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using static System.Int16;

namespace LeadPipe.Net.Extensions
{
    public static class ConversionExtensions
    {
        public static DateTime ParseDateTime(this string value)
        {
            return DateTime.Parse(value, CultureInfo.InvariantCulture);
        }

        public static DateTime ParseDateTime(this string value, IFormatProvider provider)
        {
            return DateTime.Parse(value, provider);
        }

        public static DateTime ParseDateTime(this string value, IFormatProvider provider, DateTimeStyles styles)
        {
            return DateTime.Parse(value, provider, styles);
        }

        public static short ParseInt16(this string value)
        {
            return Parse(value, CultureInfo.InvariantCulture);
        }

        public static int ParseInt32(this string value)
        {
            return int.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static long ParseInt64(this string value)
        {
            return long.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static bool ToBoolean(this object value)
        {
            return Convert.ToBoolean(value, CultureInfo.InvariantCulture);
        }

        public static bool ToBoolean(this string value)
        {
            return Convert.ToBoolean(value, CultureInfo.InvariantCulture);
        }

        public static byte ToByte(this object value)
        {
            return Convert.ToByte(value, CultureInfo.InvariantCulture);
        }

        public static byte ToByte(this string value)
        {
            return Convert.ToByte(value, CultureInfo.InvariantCulture);
        }

        public static DateTime ToDateTime(this object value)
        {
            return Convert.ToDateTime(value, CultureInfo.InvariantCulture);
        }

        public static DateTime ToDateTime(this string value)
        {
            return Convert.ToDateTime(value, CultureInfo.InvariantCulture);
        }

        public static decimal ToDecimal(this object value)
        {
            return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        public static decimal ToDecimal(this string value)
        {
            return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the object as a dictionary of properties and values.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>A dictionary of properties and values.</returns>
        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            var properties = TypeDescriptor.GetProperties(obj);

            foreach (PropertyDescriptor property in properties)
            {
                result.Add(property.Name, property.GetValue(obj));
            }

            return result;
        }

        public static double ToDouble(this string value)
        {
            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        public static double ToDouble(this object value)
        {
            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        public static int ToInt16(this string value)
        {
            return Convert.ToInt16(value, CultureInfo.InvariantCulture);
        }

        public static int ToInt16(this object value)
        {
            return Convert.ToInt16(value, CultureInfo.InvariantCulture);
        }

        public static int ToInt32(this string value)
        {
            return Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        public static int ToInt32(this object value)
        {
            return Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        public static long ToInt64(this string value)
        {
            return Convert.ToInt64(value, CultureInfo.InvariantCulture);
        }

        public static long ToInt64(this object value)
        {
            return Convert.ToInt64(value, CultureInfo.InvariantCulture);
        }

        public static sbyte ToSByte(this string value)
        {
            return Convert.ToSByte(value, CultureInfo.InvariantCulture);
        }

        public static sbyte ToSByte(this object value)
        {
            return Convert.ToSByte(value, CultureInfo.InvariantCulture);
        }

        public static float ToSingle(this string value)
        {
            return Convert.ToSingle(value, CultureInfo.InvariantCulture);
        }

        public static float ToSingle(this object value)
        {
            return Convert.ToSingle(value, CultureInfo.InvariantCulture);
        }

        public static ushort ToUInt16(this string value)
        {
            return Convert.ToUInt16(value, CultureInfo.InvariantCulture);
        }

        public static ushort ToUInt16(this object value)
        {
            return Convert.ToUInt16(value, CultureInfo.InvariantCulture);
        }

        public static uint ToUInt32(this string value)
        {
            return Convert.ToUInt32(value, CultureInfo.InvariantCulture);
        }

        public static uint ToUInt32(this object value)
        {
            return Convert.ToUInt32(value, CultureInfo.InvariantCulture);
        }

        public static ulong ToUInt64(this string value)
        {
            return Convert.ToUInt64(value, CultureInfo.InvariantCulture);
        }

        public static ulong ToUInt64(this object value)
        {
            return Convert.ToUInt64(value, CultureInfo.InvariantCulture);
        }

        public static bool TryParseDateTime(this string value, out DateTime result)
        {
            return DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out result);
        }

        public static bool TryParseDateTime(this string value, out DateTime result, IFormatProvider provider)
        {
            return DateTime.TryParse(value, provider, DateTimeStyles.AssumeLocal, out result);
        }

        public static bool TryParseDateTime(this string value, out DateTime result, IFormatProvider provider, DateTimeStyles styles)
        {
            return DateTime.TryParse(value, provider, styles, out result);
        }

        public static bool TryParseInt16(this string value, out short result)
        {
            return TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        public static bool TryParseInt32(this string value, out int result)
        {
            return int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        public static bool TryParseInt64(this string value, out long result)
        {
            return long.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
    }
}