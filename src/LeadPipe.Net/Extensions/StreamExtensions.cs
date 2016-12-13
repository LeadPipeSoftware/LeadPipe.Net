// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.IO;

namespace LeadPipe.Net.Extensions
{
    /// <summary>
    /// The Stream type extensions.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Reads all bytes.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>All of the bytes in the stream.</returns>
        public static byte[] ReadAllBytes(this Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}