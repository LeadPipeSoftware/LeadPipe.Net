// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LeadPipe.Net.Extensions
{
    /// <summary>
    /// The object extensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Gets a property name.
        /// </summary>
        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }

        /// <summary>
        /// Gets a property value.
        /// </summary>
        /// <param name="obj">The source.</param>
        /// <param name="property">The property.</param>
        /// <returns>The value of the property.</returns>
        public static object GetPropertyValue(this object obj, string property)
        {
            return TypeDescriptor.GetProperties(obj)[property].GetValue(obj);
        }

        /// <summary>
        /// Determines whether the specified object is the default value.
        /// </summary>
        /// <typeparam name="T">The type of the object to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is the default value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDefaultValue<T>(this T obj)
        {
            return EqualityComparer<T>.Default.Equals(obj, default(T));
        }

        /// <summary>
        /// Determines whether the specified object is not the default value.
        /// </summary>
        /// <typeparam name="T">The type of the object to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is not the default value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotDefaultValue<T>(this T obj)
        {
            return !EqualityComparer<T>.Default.Equals(obj, default(T));
        }

        /// <summary>
        /// Determines whether the specified object is not null.
        /// </summary>
        /// <typeparam name="T">The type of the object to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is not null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNull<T>(this T obj)
        {
            return obj != null;
        }

        /// <summary>
        /// Determines whether the specified object is null.
        /// </summary>
        /// <typeparam name="T">The type of the object to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull<T>(this T obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Returns the first non-null value of an object.
        /// </summary>
        /// <remarks>
        /// This is comparable to Coalesce in SQL Server.
        /// </remarks>
        /// <typeparam name="T">The type of the object to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="otherValues">The other values.</param>
        /// <returns>The first non-null value of an object.</returns>
        public static T OrElse<T>(this T obj, params T[] otherValues)
        {
            return obj.IsNotNull()
                ? obj
                : otherValues.FirstOrDefault(value => value.IsNotNull());
        }

        /// <summary>
        /// Sets the private field with reflection.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException">target;The assignment target cannot be null.</exception>
        /// <exception cref="System.ArgumentException">fieldName;The field name cannot be null or empty.</exception>
        /// <exception cref="System.Exception"></exception>
        public static void SetPrivateFieldWithReflection(this object obj, string fieldName, object value)
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);
            Guard.Will.ProtectAgainstNullOrEmptyStringArgument(() => fieldName);

            var t = obj.GetType();

            FieldInfo fi = null;

            while (t != null)
            {
                fi = t.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

                if (fi != null) break;

                t = t.BaseType;
            }

            if (fi == null)
            {
                throw new Exception(string.Format("Field '{0}' not found in the type hierarchy.", fieldName));
            }

            fi.SetValue(obj, value);
        }
    }
}