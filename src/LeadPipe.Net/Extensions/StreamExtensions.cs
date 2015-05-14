// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;

namespace LeadPipe.Net.Extensions
{
	/// <summary>
	/// The Stream type extensions.
	/// </summary>
	public static class StreamExtensions
	{
		#region Public Methods and Operators

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

		#endregion
	}
}