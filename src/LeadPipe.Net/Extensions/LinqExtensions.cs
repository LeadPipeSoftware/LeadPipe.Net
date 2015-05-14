// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinqExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using System.Text;

namespace LeadPipe.Net.Extensions
{
	/// <summary>
	/// The LINQ extension methods.
	/// </summary>
	public static class LinqExtensions
	{
		#region Public Methods and Operators

		/// <summary>
		/// Converts LINQ data to a comma separated string including header.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <returns>
		/// A CSV string representation of the data.
		/// </returns>
		public static string ToCommaDelimitedString(this IOrderedQueryable data)
		{
			return ToDelimitedString(data, ",");
		}

		/// <summary>
		/// Converts the LINQ data to a delimited string with a header.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="delimiter">The delimiter.</param>
		/// <returns>
		/// A CSV string representation of the data.
		/// </returns>
		public static string ToDelimitedString(this IOrderedQueryable data, string delimiter)
		{
			return ToDelimitedString(data, delimiter, null);
		}

		/// <summary>
		/// Converts the LINQ data to a delimited string with a header.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="delimiter">The delimiter.</param>
		/// <param name="nullValue">The null value.</param>
		/// <returns>
		/// A CSV string representation of the data.
		/// </returns>
		public static string ToDelimitedString(this IOrderedQueryable data, string delimiter, string nullValue)
		{
			var delimitedData = new StringBuilder();

			var replaceFrom = delimiter.Trim();

			var replaceDelimiter = ";";

			var headers = data.ElementType.GetProperties();

			switch (replaceFrom)
			{
				case ";":
					replaceDelimiter = ":";
					break;
				case ",":
					replaceDelimiter = "¸";
					break;
				case "\t":
					replaceDelimiter = "    ";
					break;
				default:
					break;
			}

			if (headers.Length > 0)
			{
				foreach (var head in headers)
				{
					delimitedData.Append(head.Name.Replace("_", " ") + delimiter);
				}

				delimitedData.Append("\n");
			}

			foreach (var row in data)
			{
				var fields = row.GetType().GetProperties();

				foreach (var t in fields)
				{
					object value = null;

					try
					{
						value = t.GetValue(row, null);
					}
					catch
					{
					}

					if (value.IsNotNull())
					{
						delimitedData.Append(
							value.ToString()
								.Replace("\r", "\f")
								.Replace("\n", " \f")
								.Replace("_", " ")
								.Replace(replaceFrom, replaceDelimiter) + delimiter);
					}
					else
					{
						delimitedData.Append(nullValue);
						delimitedData.Append(delimiter);
					}
				}

				delimitedData.Append("\n");
			}

			return delimitedData.ToString();
		}

		#endregion
	}
}