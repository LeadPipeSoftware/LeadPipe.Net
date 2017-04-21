// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;

namespace LeadPipe.Net.Extensions
{
    public static class HexExtensions
    {
        /// <summary>
        /// Converts the byte array to a hexadecimal string.
        /// </summary>
        public static string BytesToHex(this byte[] value)
        {
            return string.Join("", "0x", BitConverter.ToString(value).Replace("-", null));
        }

        /// <summary>
        /// Decodes a hexadecimal string to a UTF8 byte array and then back to a string.
        /// </summary>
        public static string DecodeStringFromHex(this string s)
        {
            return Encoding.UTF8.GetString(s.HexToBytes());
        }

        /// <summary>
        /// Converts the string to a UTF8 byte array and then encodes it as a hexadecimal string.
        /// </summary>
        public static string EncodeStringToHex(this string s)
        {
            return Encoding.UTF8.GetBytes(s).BytesToHex();
        }

        /// <summary>
        /// Converts the value of the specified string to a hexadecimal byte array.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>The string as a byte array.</returns>
        /// <exception cref="System.FormatException">The exception thrown if the value has an invalid format.</exception>
        /// <exception cref="System.OverflowException">
        /// The exception thrown if the value is a number less than System.Byte.MinValue
        /// or greater than System.Byte.MaxValue.
        /// </exception>
        public static byte[] HexToBytes(this string s)
        {
            // it is customary for a hex string to start with 0x, so we need to account for that
            var start = s.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? 2 : 0;

            return Enumerable.Range(start, s.Length - start)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(s.Substring(x, 2), 16))
                .ToArray();
        }
    }
}