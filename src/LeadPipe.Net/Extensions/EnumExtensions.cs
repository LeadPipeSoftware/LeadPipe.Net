// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace LeadPipe.Net.Extensions
{
	/// <summary>
	/// Extension methods for the Enum type.
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Gets the enum description based on the DescriptionAttribute.
		/// </summary>
		/// <param name="enumeration">The enumeration.</param>
		/// <returns>
		/// The enum description.
		/// </returns>
		public static string ToDescription(this Enum enumeration)
		{
			var type = enumeration.GetType();

			var memberInfo = type.GetMember(enumeration.ToString());

			if (memberInfo.Length <= 0) return enumeration.ToString();

			var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

			return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : enumeration.ToString();
		}
	}
}