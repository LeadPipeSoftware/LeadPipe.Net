// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LeadPipe.Net.Extensions
{
	/// <summary>
	/// The type extensions.
	/// </summary>
	public static class TypeExtensions
	{
		#region Public Methods

		/// <summary>
		/// Returns a new instance of the specified Type passing in the specified constructor arguments.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="args">The arguments to pass to the type's constructor.</param>
		/// <returns>An instance of the type.</returns>
		public static object CreateInstance(this Type type, params object[] args)
		{
			//// TODO: [GBM] Write unit tests.
			return Activator.CreateInstance(type, args);
		}

		/// <summary>
		/// Returns a new instance of the specified Type cast as the specified Generic type, passing in the specified constructor arguments.
		/// </summary>
		/// <typeparam name="T">The type to cast to.</typeparam>
		/// <param name="type">The type.</param>
		/// <param name="args">The arguments to pass to the type's constructor.</param>
		/// <returns>A casted instance of the type.</returns>
		public static T CreateInstance<T>(this Type type, params object[] args)
		{
			//// TODO: [GBM] Write unit tests.
			return (T)type.CreateInstance(args);
		}

		/// <summary>
		/// Converts an expression into a <see cref="MemberInfo" />.
		/// </summary>
		/// <param name="expression">The expression to convert.</param>
		/// <returns>The member info.</returns>
		public static MemberInfo GetMemberInfo(this Expression expression)
		{
			var lambda = (LambdaExpression)expression;

			MemberExpression memberExpression;

			if (lambda.Body is UnaryExpression)
			{
				var unaryExpression = (UnaryExpression)lambda.Body;

				memberExpression = (MemberExpression)unaryExpression.Operand;
			}
			else
			{
				memberExpression = (MemberExpression)lambda.Body;
			}

			return memberExpression.Member;
		}

		/// <summary>
		/// Determines whether the type has the specified attribute.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="attributeType">Type of the attribute.</param>
		/// <returns><c>true</c> if the type has the specified attribute; otherwise, <c>false</c>.</returns>
		public static bool HasAttribute(this Type type, Type attributeType)
		{
			return type.GetCustomAttributes(attributeType, false).Length > 0;
		}

		/// <summary>
		/// Determines whether the type has methods with the specified attribute.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="attributeType">Type of the attribute.</param>
		/// <returns><c>true</c> if the type has methods with the specified attribute; otherwise, <c>false</c>.</returns>
		public static bool HasMethodsWithAttribute(this Type type, Type attributeType)
		{
			return type.GetMethods().Any(methodInfo => methodInfo.GetCustomAttributes(attributeType, false).Length > 0);
		}

		/// <summary>
		/// Determines whether a method has the specified attribute.
		/// </summary>
		/// <param name="methodInfo">The method.</param>
		/// <param name="attributeType">Type of the attribute.</param>
		/// <returns><c>true</c> if the method has the specified attribute; otherwise, <c>false</c>.</returns>
		public static bool HasAttribute(this MethodInfo methodInfo, Type attributeType)
		{
			return methodInfo.GetCustomAttributes(attributeType, false).Length > 0;
		}

		/// <summary>
		/// Determines whether this instance [can be cast to] the specified type.
		/// </summary>
		/// <typeparam name="T">The type to check the cast against</typeparam>
		/// <param name="type">The type.</param>
		/// <returns><c>true</c> if this instance [can be cast to] the specified type; otherwise, <c>false</c>.</returns>
		public static bool CanBeCastTo<T>(this Type type)
		{
			if (type == null)
			{
				return false;
			}

			var destinationType = typeof(T);

			return CanBeCastTo(type, destinationType);
		}

		/// <summary>
		/// Determines whether this instance [can be cast to] the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="destinationType">Type of the destination.</param>
		/// <returns><c>true</c> if this instance [can be cast to] the specified type; otherwise, <c>false</c>.</returns>
		public static bool CanBeCastTo(this Type type, Type destinationType)
		{
			if (type == null)
			{
				return false;
			}

			if (type == destinationType)
			{
				return true;
			}

			return destinationType.IsAssignableFrom(type);
		}

		/// <summary>
		/// Determines whether the specified type is concrete.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns><c>true</c> if the specified type is concrete; otherwise, <c>false</c>.</returns>
		public static bool IsConcrete(this Type type)
		{
			if (type == null)
			{
				return false;
			}

			return !type.IsAbstract && !type.IsInterface;
		}

		/// <summary>
		/// Determines whether [is not concrete] [the specified type].
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns><c>true</c> if [is not concrete] [the specified type]; otherwise, <c>false</c>.</returns>
		public static bool IsNotConcrete(this Type type)
		{
			return !type.IsConcrete();
		}

		#endregion
	}
}