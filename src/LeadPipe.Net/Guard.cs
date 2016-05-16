// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net
{
	/// <summary>
	/// A fluent guarding class.
	/// </summary>
	public class Guard
	{
		#region Constants and Fields

		/// <summary>
		/// The action to invoke.
		/// </summary>
		private Action actionToInvoke;

		/// <summary>
		/// The exception to throw.
		/// </summary>
		private Exception exception;

		/// <summary>
		/// Provides a context to help chain together exceptions that may occur in different threads.
		/// </summary>
		private string relationshipId;

		#endregion

		#region Public Properties

		/// <summary>
		/// Chaining candy.
		/// </summary>
		public Guard And
		{
			get
			{
				return this;
			}
		}

		/// <summary>
		/// Gets the start of the fluent guard chain.
		/// </summary>
		public static Guard Will
		{
			get
			{
				return new Guard();
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Sets the relationship id.
		/// </summary>
		/// <param name="relationshipId">The relationship id.</param>
		/// <remarks>
		/// <para>
		/// Note that this must be called BEFORE any Throw statements if you want the relationship displayed in the message.
		/// </para>
		/// </remarks>
		/// <returns>The Guard with the relationship id set.</returns>
		public Guard AssociateExceptionsWith(string relationshipId)
		{
			this.relationshipId = relationshipId;

			return this;
		}

		/// <summary>
		/// Sets the action to invoke when the guard condition is met.
		/// </summary>
		/// <param name="actionToInvoke">The action.</param>
		public Guard Execute(Action actionToInvoke)
		{
			this.actionToInvoke = actionToInvoke;

			return this;
		}

		/// <summary>
		/// Sets up to throw an InvalidOperationException with no message if the assertion fails.
		/// </summary>
		/// <returns>The Guard with an exception type set.</returns>
		public Guard ThrowException()
		{
			var exceptionMessage = this.AddRelationshipIdToExceptionMessage(string.Empty);

			this.exception = (InvalidOperationException)Activator.CreateInstance(typeof(InvalidOperationException), exceptionMessage);

			return this;
		}

		/// <summary>
		/// Sets the message to include in the InvalidOperationException if the assertion fails.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <returns>The Guard with an exception type set.</returns>
		public Guard ThrowException(string message)
		{
			var exceptionMessage = this.AddRelationshipIdToExceptionMessage(message);

			this.exception = (InvalidOperationException)Activator.CreateInstance(typeof(InvalidOperationException), exceptionMessage);

			return this;
		}

		/// <summary>
		/// Sets the exception to throw if the assertion fails.
		/// </summary>
		/// <remarks>
		/// <para>Note that the relationship will not included even if it is set when using this call.</para>
		/// </remarks>
		/// <param name="exceptionToThrow">The exception to throw.</param>
		/// <returns>The Guard with an exception set.</returns>
		public Guard ThrowException(Exception exceptionToThrow)
		{
			this.exception = exceptionToThrow;

			return this;
		}

		/// <summary>
		/// Guards against a null argument.
		/// </summary>
		/// <typeparam name="T">The argument type.</typeparam>
		/// <param name="argument">The argument.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		/// <remarks><code>
		/// Guard.AgainstNullArgument(() =&gt; argument);
		/// </code></remarks>
		public void ProtectAgainstNullArgument<T>(Func<T> argument) where T : class
		{
			if (argument().IsNotNull())
			{
				return;
			}

			var message = string.Format("Argument of type '{0}' cannot be null.", typeof(T));

			var exceptionMessage = this.AddRelationshipIdToExceptionMessage(message);

			var fieldName = GetFieldName(argument);

			if (fieldName.IsNotNull())
			{
				throw new ArgumentNullException(fieldName, exceptionMessage);
			}

			throw new ArgumentNullException(exceptionMessage);
		}

		/// <summary>
		/// Guards against an argument with a default value.
		/// </summary>
		/// <typeparam name="T">The argument type.</typeparam>
		/// <param name="argument">The argument.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		/// <remarks><code>
		/// Guard.ProtectAgainstDefaultValueArgument(() =&gt; argument);
		/// </code></remarks>
		public void ProtectAgainstDefaultValueArgument<T>(Func<T> argument)
		{
			if (!argument().IsDefaultValue()) return;

			var message = string.Format("Argument of type '{0}' cannot be the type's default value.", typeof(T));

			var exceptionMessage = this.AddRelationshipIdToExceptionMessage(message);

			var fieldName = GetFieldName(argument);

			if (fieldName.IsNotNull())
			{
				throw new ArgumentOutOfRangeException(fieldName, exceptionMessage);
			}

			throw new ArgumentOutOfRangeException(exceptionMessage);
		}

		/// <summary>
		/// Guards against a null or empty string argument.
		/// </summary>
		/// <typeparam name="T">The argument type.</typeparam>
		/// <param name="argument">The argument.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		/// <remarks><code>
		/// Guard.AgainstNullArgument(() =&gt; argument);
		/// </code></remarks>
		public void ProtectAgainstNullOrEmptyStringArgument<T>(Func<T> argument) where T : class
		{
			var argumentAsString = argument().IsNull() ? null : argument().ToString();

			if (!string.IsNullOrEmpty(argumentAsString))
			{
				return;
			}

			var message = string.Format("Argument of type '{0}' cannot be null.", typeof(T));

			var exceptionMessage = this.AddRelationshipIdToExceptionMessage(message);

			var fieldName = GetFieldName(argument);

			if (fieldName.IsNotNull())
			{
				throw new ArgumentNullException(fieldName, exceptionMessage);
			}

			throw new ArgumentNullException(exceptionMessage);
		}

		/// <summary>
		/// Gets an exception.
		/// </summary>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <returns>The Guard with an exception type set.</returns>
		public Guard ThrowArgumentNullException(string parameterName)
		{
			this.exception = (ArgumentNullException)Activator.CreateInstance(typeof(ArgumentNullException), parameterName);

			return this;
		}

		/// <summary>
		/// Gets an exception.
		/// </summary>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="message">The exception message.</param>
		/// <returns>The Guard with an exception type set.</returns>
		public Guard ThrowArgumentNullException(string parameterName, string message)
		{
			this.exception = (ArgumentNullException)Activator.CreateInstance(typeof(ArgumentNullException), parameterName, message);

			return this;
		}

		/// <summary>
		/// Gets an exception.
		/// </summary>
		/// <typeparam name="TException">The type of the exception.</typeparam>
		/// <returns>The Guard with an exception type set.</returns>
		public Guard ThrowExceptionOfType<TException>() where TException : Exception
		{
			var exceptionMessage = this.AddRelationshipIdToExceptionMessage(String.Empty);

			this.exception = (TException)Activator.CreateInstance(typeof(TException), exceptionMessage);

			return this;
		}

		/// <summary>
		/// Gets an exception.
		/// </summary>
		/// <typeparam name="TException">The type of the exception.</typeparam>
		/// <param name="message">The exception message.</param>
		/// <returns>The Guard with an exception type set.</returns>
		public Guard ThrowExceptionOfType<TException>(string message) where TException : Exception
		{
			var exceptionMessage = this.AddRelationshipIdToExceptionMessage(message);

			this.exception = (TException)Activator.CreateInstance(typeof(TException), exceptionMessage);

			return this;
		}

		/// <summary>
		/// Conditions the specified assertion.
		/// </summary>
		/// <param name="assertion">if set to <c>true</c> [assertion].</param>
		public void When(bool assertion)
		{
			// If the assertion is false then bail...
			if (!assertion) return;

			// Invoke the action if there is one...
			if (actionToInvoke.IsNotNull())
			{
				this.actionToInvoke.Invoke();
			}

			if (this.exception.IsNotNull())
			{
				throw this.exception;
			}
		}

		#endregion

		#region Private Methods

		private string AddRelationshipIdToExceptionMessage(string rootMessage)
		{
			if (rootMessage.IsNullOrEmpty() && this.relationshipId.IsNotNullOrEmpty()) return this.relationshipId.FormattedWith("[{0}]");

			return this.relationshipId.IsNotNullOrEmpty()
				? string.Format("[{0}] {1}", this.relationshipId, rootMessage)
				: rootMessage;
		}

		/// <summary>
		/// Gets the name of the field.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="argument">The argument.</param>
		/// <returns>The field name.</returns>
		private static string GetFieldName<T>(Func<T> argument)
		{
			/*
			 * Good information about this technique can be found at http://abdullin.com/journal/2008/12/19/how-to-get-parameter-name-and-argument-value-from-c-lambda-v.html
			 */

			try
			{
				// Get the IL code behind the delegate...
				var methodBody = argument.Method.GetMethodBody();

				if (methodBody == null) return null;

				var il = methodBody.GetILAsByteArray();

				if (il == null) return null;

				// Get the field handle (bytes 2-6 represent the field handle)...
				var fieldHandle = BitConverter.ToInt32(il, 2);

				// Resolve the handle...
				var field = argument.Target.GetType().Module.ResolveField(fieldHandle);

				if (field == null) return null;

				return field.Name;
			}
			catch (Exception)
			{
				// By design
			}

			return null;
		}

		#endregion
	}
}