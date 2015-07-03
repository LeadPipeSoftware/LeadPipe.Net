// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatableObjectExtensions.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Validation
{
    /// <summary>
	/// A set of validatable object extension methods.
	/// </summary>
	public static class ValidatableObjectExtensions
	{
		#region Public Methods

		/// <summary>
		/// Determines whether the type has validation attributes on each field that match a specified type.
		/// </summary>
		/// <param name="t">
		/// The t.
		/// </param>
		/// <param name="typeToCompare">
		/// The type to compare.
		/// </param>
		/// <returns>
		/// <c>true</c> if the type has validation attributes on each field that match the specified type; otherwise, <c>false</c>.
		/// </returns>
		public static bool FieldValidationAttributesMatch(this Type t, Type typeToCompare)
		{
			// Get all the properties from each type...
			var leftSide = t.GetProperties().ToList();
			var rightSide = typeToCompare.GetProperties().ToList();

			return !(from rightSideField in rightSide
					 let leftSideField = leftSide.Find(p => p.Name == rightSideField.Name)
					 where leftSideField.IsNotNull()
					 let leftSideAttributes =
						leftSideField.GetCustomAttributes(false).Where(
							a => a.GetType().IsSubclassOf(typeof(LeadPipeValidationAttribute)))
					 let rightSideAttributes =
						rightSideField.GetCustomAttributes(false).Where(
							a => a.GetType().IsSubclassOf(typeof(LeadPipeValidationAttribute)))
					 where leftSideAttributes.Any(attribute => !rightSideAttributes.Contains(attribute))
					 select leftSideAttributes).Any();
		}

		/// <summary>
		/// Gets the Validation attributes.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This particular extension method is fairly useless since it strips away context.
		/// </para>
		/// </remarks>
		/// <param name="t">
		/// The type.
		/// </param>
		/// <returns>
		/// The ValidationAttribute.
		/// </returns>
		public static List<object> GetValidationAttributes(this Type t)
		{
			List<object> validationAttributes = (from property in t.GetProperties()
												 from attribute in property.GetCustomAttributes(false)
												 where attribute.GetType().IsSubclassOf(typeof(ValidationAttribute))
                                                    || attribute.GetType().IsSubclassOf(typeof(LeadPipeValidationAttribute))
												 select attribute).ToList();

			return validationAttributes;
		}

		/// <summary>
		/// Determines whether a type has one or more Validation attribute.
		/// </summary>
		/// <param name="t">
		/// The Type to inspect.
		/// </param>
		/// <returns>
		/// <c>true</c> if the type has the Validation attribute; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasValidationAttributes(this Type t)
		{
			return t.GetValidationAttributes().Count() > 0;
		}

		/// <summary>
		/// Determines whether the specified validatable object is valid.
		/// </summary>
		/// <param name="validatableObject">
		/// The validatable object.
		/// </param>
		/// <returns>
		/// <c>true</c> if the specified validatable object is valid; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsValid(this IValidatableObject validatableObject)
		{
			return validatableObject.Validate().Count == 0;
		}

		/// <summary>
		/// Determines whether the type has validation attributes on each method that match a specified type.
		/// </summary>
		/// <param name="t">
		/// The t.
		/// </param>
		/// <param name="typeToCompare">
		/// The type to compare.
		/// </param>
		/// <returns>
		/// <c>true</c> if the type has validation attributes on each method that match the specified type; otherwise, <c>false</c>.
		/// </returns>
		public static bool MethodValidationAttributesMatch(this Type t, Type typeToCompare)
		{
			// Get all the methods from each type...
			var leftSide = t.GetMethods().ToList();
			var rightSide = typeToCompare.GetMethods().ToList();

			return !(from rightSideMethod in rightSide
					 let leftSideMethod = leftSide.Find(p => p.Name == rightSideMethod.Name)
					 where leftSideMethod.IsNotNull()
					 let leftSideAttributes =
						leftSideMethod.GetCustomAttributes(false).Where(
							a => a.GetType().IsSubclassOf(typeof(LeadPipeValidationAttribute)))
					 let rightSideAttributes =
						rightSideMethod.GetCustomAttributes(false).Where(
							a => a.GetType().IsSubclassOf(typeof(LeadPipeValidationAttribute)))
					 where leftSideAttributes.Any(attribute => !rightSideAttributes.Contains(attribute))
					 select leftSideAttributes).Any();
		}

		/// <summary>
		/// Determines whether the type has validation attributes on each property that match a specified type.
		/// </summary>
		/// <param name="t">
		/// The t.
		/// </param>
		/// <param name="typeToCompare">
		/// The type to compare.
		/// </param>
		/// <returns>
		/// <c>true</c> if the type has validation attributes on each property that match the specified type; otherwise, <c>false</c>.
		/// </returns>
		public static bool PropertyValidationAttributesMatch(this Type t, Type typeToCompare)
		{
			// Get all the properties from each type...
			var leftSide = t.GetProperties().ToList();
			var rightSide = typeToCompare.GetProperties().ToList();

			return !(from rightSideProperty in rightSide
					 let leftSideProperty = leftSide.Find(p => p.Name == rightSideProperty.Name)
					 where leftSideProperty.IsNotNull()
					 let leftSideAttributes =
						leftSideProperty.GetCustomAttributes(false).Where(
							a => a.GetType().IsSubclassOf(typeof(LeadPipeValidationAttribute)))
					 let rightSideAttributes =
						rightSideProperty.GetCustomAttributes(false).Where(
							a => a.GetType().IsSubclassOf(typeof(LeadPipeValidationAttribute)))
					 where leftSideAttributes.Any(attribute => !rightSideAttributes.Contains(attribute))
					 select leftSideAttributes).Any();
		}

		/// <summary>
		/// Validates a validatable object.
		/// </summary>
		/// <param name="validatableObject">
		/// The validatable object.
		/// </param>
		/// <returns>
		/// A list of validation results.
		/// </returns>
		public static List<ValidationResult> Validate(this IValidatableObject validatableObject)
		{
			var validationResult = new List<ValidationResult>();

			System.ComponentModel.DataAnnotations.Validator.TryValidateObject(
				validatableObject, new ValidationContext(validatableObject, null, null), validationResult, true);

			return validationResult;
		}

		/// <summary>
		/// Determines whether the type has validation attributes that match a specified type.
		/// </summary>
		/// <param name="t">
		/// The t.
		/// </param>
		/// <param name="typeToCompare">
		/// The type to compare.
		/// </param>
		/// <returns>
		/// <c>true</c> if the type has validation attributes that match the specified type; otherwise, <c>false</c>.
		/// </returns>
		public static bool ValidationAttributesMatch(this Type t, Type typeToCompare)
		{
			return t.FieldValidationAttributesMatch(typeToCompare) && t.PropertyValidationAttributesMatch(typeToCompare)
				   && t.MethodValidationAttributesMatch(typeToCompare);
		}

		#endregion
	}
}