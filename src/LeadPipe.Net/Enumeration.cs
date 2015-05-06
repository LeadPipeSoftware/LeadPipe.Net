// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enumeration.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Reflection;

	using LeadPipe.Net.Core.Extensions;

	/// <summary>
	/// The enumeration supertype.
	/// </summary>
	/// <remarks><para>
	/// A frequent problem with standard enumerations is that they often lead to gnarly switch statements. For example:
	///   </para>
	///   <code>
	/// public class Employee
	/// {
	/// public EmployeeType Type { get; set; }
	/// }
	/// public enum EmployeeType
	/// {
	/// FullTime,
	/// PartTime,
	/// Contract
	/// }
	/// public void ApplyBonus(Employee employee)
	/// {
	/// switch(employee.Type)
	/// {
	/// case EmployeeType.FullTime:
	/// employee.Bonus = 1000m;
	/// break;
	/// case EmployeeType.PartTime:
	/// employee.Bonus = 1.0m;
	/// case EmployeeType.Contract:
	/// employee.Bonus = 0.01m;
	/// default:
	/// throw new ArgumentOutOfRangeException();
	/// }
	/// }
	///   </code>
	///   <para>
	/// The trouble is that behavior related to the enumeration will often become scattered throughout the application
	/// and simple activities such as adding a new enumeration get messy. Using this class we can do this instead:
	///   </para>
	///   <code>
	/// public class EmployeeType : Enumeration
	/// {
	/// public static readonly EmployeeType FullTime = new EmployeeType(0, "Full Time");
	/// public static readonly EmployeeType PartTime = new EmployeeType(1, "Part Time");
	/// public static readonly EmployeeType Contract = new EmployeeType(2, "Contract");
	/// private EmployeeType ()
	/// {
	/// }
	/// private EmployeeType(int value, string displayName) : base(value, displayName)
	/// {
	/// }
	/// }
	///   </code>
	///   <para>
	/// The actual enumeration doesn't look any different in code. You can still do this:
	///   </para>
	///   <code>
	/// gregMajor.Type = EmployeeType.FullTime;
	///   </code>
	///   <para>
	/// Ah, but now we have a place to put behavior associated with the enumeration which means we can do this:
	///   </para>
	///   <code>
	/// public void ApplyBonus(Employee employee)
	/// {
	/// employee.Bonus = employee.Type.BonusSize;
	/// }
	///   </code>
	///   <para>
	/// See what happened there? The entire switch statement got dropped to a single line of code. How did we do that?
	/// Well, we could have simply assigned the enum's BonusSize value somewhere. We could have also done this:
	///   </para>
	///   <code>
	/// public abstract class EmployeeType : Enumeration
	/// {
	/// public static readonly EmployeeType FullTime = new FullTimeEmployeeType();
	/// protected EmployeeType()
	/// {
	/// }
	/// protected EmployeeType(int value, string displayName) : base(value, displayName)
	/// {
	/// }
	/// public abstract decimal BonusSize { get; }
	/// public override decimal BonusSize
	/// {
	/// get { return 1000m; }
	/// }
	/// }
	///   </code>
	///   <para>
	/// Pretty cool, huh? Now we can zero in on implementation without having to hunt all over our code for references
	/// to the enumeration. This is basically just the Strategy pattern applied to the enumeration class idea. Props to
	/// Jimmy Bogard (http://lostechies.com/jimmybogard) for laying this one out.
	/// </para></remarks>
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
	public class Enumeration : IComparable
	{
		/// <summary>
		/// The enumeration item display name.
		/// </summary>
		private readonly string displayName;

		/// <summary>
		/// The enumeration item value.
		/// </summary>
		private readonly int value;

		/// <summary>
		/// Initializes a new instance of the <see cref="Enumeration" /> class.
		/// </summary>
		protected Enumeration()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Enumeration" /> class.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="displayName">The display name.</param>
		protected Enumeration(int value, string displayName)
		{
			this.value = value;
			this.displayName = displayName;
		}

		/// <summary>
		/// Gets the display name.
		/// </summary>
		/// <value>The display name.</value>
		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public int Value
		{
			get
			{
				return this.value;
			}
		}

		/// <summary>
		/// The absolute difference.
		/// </summary>
		/// <param name="firstValue">The first value.</param>
		/// <param name="secondValue">The second value.</param>
		/// <returns>The absolute difference between the values.</returns>
		public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
		{
			var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);

			return absoluteDifference;
		}

		/// <summary>
		/// Gets the enumeration from the display name.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="displayName">The display name.</param>
		/// <returns>The matching enumeration item.</returns>
		public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
		{
			var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);

			return matchingItem;
		}

		/// <summary>
		/// Gets the enumeration from the display name.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="displayName">The display name.</param>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns>The matching enumeration item.</returns>
		public static T FromDisplayName<T>(string displayName, bool ignoreCase) where T : Enumeration, new()
		{
			var matchingItem = Parse<T, string>(
				displayName, "display name", item => string.Compare(item.DisplayName, displayName, ignoreCase) == 0);

			return matchingItem;
		}

		/// <summary>
		/// The from value.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="value">The value.</param>
		/// <returns>The enumeration type from</returns>
		public static T FromValue<T>(int value) where T : Enumeration, new()
		{
			var matchingItem = Parse<T, int>(value, "value", item => item.Value == value);

			return matchingItem;
		}

		/// <summary>
		/// Gets all of the enumeration values.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <returns>An enumeration of enumerations. Yeah. Really.</returns>
		public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
		{
			var type = typeof(T);

			var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

			return (from info in fields let instance = new T() select info.GetValue(instance)).OfType<T>();
		}

		/// <summary>
		/// Compares an object to the enumeration value.
		/// </summary>
		/// <param name="other">The object to compare against.</param>
		/// <returns>An indication of the relative values.</returns>
		public int CompareTo(object other)
		{
			return this.Value.CompareTo(((Enumeration)other).Value);
		}

		/// <summary>
		/// Determines if the enumeration equals an object.
		/// </summary>
		/// <param name="obj">The object to match.</param>
		/// <returns>True if the object equals the enumeration value. False otherwise.</returns>
		public override bool Equals(object obj)
		{
			var otherValue = obj as Enumeration;

			if (otherValue.IsNull())
			{
				return false;
			}

			var typeMatches = this.GetType().Equals(obj.GetType());

			var valueMatches = this.value.Equals(otherValue.Value);

			return typeMatches && valueMatches;
		}

		/// <summary>
		/// Gets the hash code for the enumeration value.
		/// </summary>
		/// <returns>The get hash code.</returns>
		public override int GetHashCode()
		{
			return this.value.GetHashCode();
		}

		/// <summary>
		/// Returns the enumeration value as a string.
		/// </summary>
		/// <returns>The enumeration value as a string.</returns>
		public override string ToString()
		{
			return this.DisplayName;
		}

		/// <summary>
		/// Parses the enumeration.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <typeparam name="K">The enumeration value type.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="description">The description.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>The matching item.</returns>
		/// <exception cref="ApplicationException">Raised if a the value is not valid in the enumeration type.</exception>
		private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
		{
			var matchingItem = GetAll<T>().FirstOrDefault(predicate);

			if (matchingItem.IsNull())
			{
				var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));

				throw new ApplicationException(message);
			}

			return matchingItem;
		}
	}

	/// <summary>
	/// The enumeration supertype.
	/// </summary>
	/// <typeparam name="T">The type for the enumeration value.</typeparam>
	/// <typeparamref name="T">
	/// The type for the enumeration value.
	///   </typeparamref>
	/// <remarks><para>
	/// A frequent problem with standard enumerations is that they often lead to gnarly switch statements. For example:
	///   </para>
	///   <code>
	/// public class Employee
	/// {
	/// public EmployeeType Type { get; set; }
	/// }
	/// public enum EmployeeType
	/// {
	/// FullTime,
	/// PartTime,
	/// Contract
	/// }
	/// public void ApplyBonus(Employee employee)
	/// {
	/// switch(employee.Type)
	/// {
	/// case EmployeeType.FullTime:
	/// employee.Bonus = 1000m;
	/// break;
	/// case EmployeeType.PartTime:
	/// employee.Bonus = 1.0m;
	/// case EmployeeType.Contract:
	/// employee.Bonus = 0.01m;
	/// default:
	/// throw new ArgumentOutOfRangeException();
	/// }
	/// }
	///   </code>
	///   <para>
	/// The trouble is that behavior related to the enumeration will often become scattered throughout the application
	/// and simple activities such as adding a new enumeration get messy. Using this class we can do this instead:
	///   </para>
	///   <code>
	/// public class EmployeeType : Enumeration
	/// {
	/// public static readonly EmployeeType FullTime = new EmployeeType(0, "Full Time");
	/// public static readonly EmployeeType PartTime = new EmployeeType(1, "Part Time");
	/// public static readonly EmployeeType Contract = new EmployeeType(2, "Contract");
	/// private EmployeeType ()
	/// {
	/// }
	/// private EmployeeType(int value, string displayName) : base(value, displayName)
	/// {
	/// }
	/// }
	///   </code>
	///   <para>
	/// The actual enumeration doesn't look any different in code. You can still do this:
	///   </para>
	///   <code>
	/// gregMajor.Type = EmployeeType.FullTime;
	///   </code>
	///   <para>
	/// Ah, but now we have a place to put behavior associated with the enumeration which means we can do this:
	///   </para>
	///   <code>
	/// public void ApplyBonus(Employee employee)
	/// {
	/// employee.Bonus = employee.Type.BonusSize;
	/// }
	///   </code>
	///   <para>
	/// See what happened there? The entire switch statement got dropped to a single line of code. How did we do that?
	/// Well, we could have simply assigned the enum's BonusSize value somewhere. We could have also done this:
	///   </para>
	///   <code>
	/// public abstract class EmployeeType : Enumeration
	/// {
	/// public static readonly EmployeeType FullTime = new FullTimeEmployeeType();
	/// protected EmployeeType()
	/// {
	/// }
	/// protected EmployeeType(int value, string displayName) : base(value, displayName)
	/// {
	/// }
	/// public abstract decimal BonusSize { get; }
	/// public override decimal BonusSize
	/// {
	/// get { return 1000m; }
	/// }
	/// }
	///   </code>
	///   <para>
	/// Pretty cool, huh? Now we can zero in on implementation without having to hunt all over our code for references
	/// to the enumeration. This is basically just the Strategy pattern applied to the enumeration class idea. Props to
	/// Jimmy Bogard (http://lostechies.com/jimmybogard) for laying this one out.
	/// </para></remarks>
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "mwm. Suppression is OK here this is a generic version of the same class.")]
	public class Enumeration<T> : IComparable
		where T : IComparable
	{
		/// <summary>
		/// The enumeration item display name.
		/// </summary>
		private readonly string displayName;

		/// <summary>
		/// The enumeration item value.
		/// </summary>
		private readonly T value;

		/// <summary>
		/// Initializes a new instance of the <see cref="Enumeration{T}" /> class.
		/// Initializes a new instance of the <see cref="Enumeration" /> class.
		/// </summary>
		protected Enumeration()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Enumeration{T}" /> class.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="displayName">The display name.</param>
		protected Enumeration(T value, string displayName)
		{
			this.value = value;
			this.displayName = displayName;
		}

		/// <summary>
		/// Gets the display name.
		/// </summary>
		/// <value>The display name.</value>
		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public T Value
		{
			get
			{
				return this.value;
			}
		}

		/// <summary>
		/// The absolute difference.
		/// </summary>
		/// <param name="firstValue">The first value.</param>
		/// <param name="secondValue">The second value.</param>
		/// <returns>The absolute difference between the values.</returns>
		public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
		{
			var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);

			return absoluteDifference;
		}

		/// <summary>
		/// Gets the enumeration from the display name.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="displayName">The display name.</param>
		/// <returns>The matching enumeration item.</returns>
#pragma warning disable 693
		public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
#pragma warning restore 693
		{
			var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);

			return matchingItem;
		}

		/// <summary>
		/// Gets the enumeration from the display name.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="displayName">The display name.</param>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns>The matching enumeration item.</returns>
#pragma warning disable 693
		public static T FromDisplayName<T>(string displayName, bool ignoreCase) where T : Enumeration, new()
#pragma warning restore 693
		{
			var matchingItem = Parse<T, string>(
				displayName, "display name", item => string.Compare(item.DisplayName, displayName, ignoreCase) == 0);

			return matchingItem;
		}

		/// <summary>
		/// The from value.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="value">The value.</param>
		/// <returns>The enumeration type from</returns>
#pragma warning disable 693
		public static T FromValue<T>(int value) where T : Enumeration, new()
#pragma warning restore 693
		{
			var matchingItem = Parse<T, int>(value, "value", item => item.Value == value);

			return matchingItem;
		}

		/// <summary>
		/// Gets all of the enumeration values.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <returns>An enumeration of enumerations. Yeah. Really.</returns>
#pragma warning disable 693
		public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
#pragma warning restore 693
		{
			var type = typeof(T);

			var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

			return (from info in fields let instance = new T() select info.GetValue(instance)).OfType<T>();
		}

		/// <summary>
		/// Compares an object to the enumeration value.
		/// </summary>
		/// <param name="other">The object to compare against.</param>
		/// <returns>An indication of the relative values.</returns>
		public int CompareTo(object other)
		{
			return this.Value.CompareTo(((Enumeration)other).Value);
		}

		/// <summary>
		/// Determines if the enumeration equals an object.
		/// </summary>
		/// <param name="obj">The object to match.</param>
		/// <returns>True if the object equals the enumeration value. False otherwise.</returns>
		public override bool Equals(object obj)
		{
			var otherValue = obj as Enumeration;

			if (otherValue.IsNull())
			{
				return false;
			}

			var typeMatches = this.GetType().Equals(obj.GetType());

			var valueMatches = this.value.Equals(otherValue.Value);

			return typeMatches && valueMatches;
		}

		/// <summary>
		/// Gets the hash code for the enumeration value.
		/// </summary>
		/// <returns>The get hash code.</returns>
		public override int GetHashCode()
		{
			return this.value.GetHashCode();
		}

		/// <summary>
		/// Returns the enumeration value as a string.
		/// </summary>
		/// <returns>The enumeration value as a string.</returns>
		public override string ToString()
		{
			return this.DisplayName;
		}

		/// <summary>
		/// Parses the enumeration.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <typeparam name="K">The enumeration value type.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="description">The description.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>The matching item.</returns>
		/// <exception cref="ApplicationException">Raised if a the value is not valid in the enumeration type.</exception>
#pragma warning disable 693
		private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
#pragma warning restore 693
		{
			var matchingItem = GetAll<T>().FirstOrDefault(predicate);

			if (matchingItem.IsNull())
			{
				var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));

				throw new ApplicationException(message);
			}

			return matchingItem;
		}
	}
}