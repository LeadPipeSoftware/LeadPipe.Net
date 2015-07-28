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
		/// The exception to throw.
		/// </summary>
		private Exception exception;

		#endregion

		#region Public Properties

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
		/// Gets an exception.
		/// </summary>
		/// <returns>The Guard with an exception type set.</returns>
		public Guard ThrowException()
		{
			// Throw an exception of the specified type...
			this.exception = (InvalidOperationException)Activator.CreateInstance(typeof(InvalidOperationException));

			return this;
		}

		/// <summary>
		/// Gets an exception.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <returns>The Guard with an exception type set.</returns>
		public Guard ThrowException(string message)
		{
			// Throw an exception of the specified type...
			this.exception = (InvalidOperationException)Activator.CreateInstance(typeof(InvalidOperationException), message);

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
			/*
			 * Good information about this technique can be found at http://abdullin.com/journal/2008/12/19/how-to-get-parameter-name-and-argument-value-from-c-lambda-v.html
			 */

			if (argument().IsNotNull())
			{
				return;
			}

			// Get the IL code behind the delegate...
			var il = argument.Method.GetMethodBody().GetILAsByteArray();

			// Get the field handle (bytes 2-6 represent the field handle)...
			var fieldHandle = BitConverter.ToInt32(il, 2);

			// Resolve the handle...
			var field = argument.Target.GetType().Module.ResolveField(fieldHandle);

			// Build the message...
			var message = string.Format("Argument of type '{0}' cannot be null.", typeof(T));

			// Throw the exception...
			throw new ArgumentNullException(field.Name, message);
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

            // Get the IL code behind the delegate...
            var il = argument.Method.GetMethodBody().GetILAsByteArray();

            // Get the field handle (bytes 2-6 represent the field handle)...
            var fieldHandle = BitConverter.ToInt32(il, 2);

            // Resolve the handle...
            var field = argument.Target.GetType().Module.ResolveField(fieldHandle);

            // Build the message...
            var message = string.Format("Argument of type '{0}' cannot be the type's default value.", typeof(T));

            // Throw the exception...
            throw new ArgumentOutOfRangeException(field.Name, message);
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
			/*
			 * Good information about this technique can be found at http://abdullin.com/journal/2008/12/19/how-to-get-parameter-name-and-argument-value-from-c-lambda-v.html
			 */

			var argumentAsString = argument().IsNull() ? null : argument().ToString();

			if (!string.IsNullOrEmpty(argumentAsString))
			{
				return;
			}

			// Get the IL code behind the delegate...
			var il = argument.Method.GetMethodBody().GetILAsByteArray();

			// Get the field handle (bytes 2-6 represent the field handle)...
			var fieldHandle = BitConverter.ToInt32(il, 2);

			// Resolve the handle...
			var field = argument.Target.GetType().Module.ResolveField(fieldHandle);

			// Build the message...
			var message = string.Format("Argument of type '{0}' cannot be null.", typeof(T));

			// Throw the exception...
			throw new ArgumentNullException(field.Name, message);
		}

		/// <summary>
		/// Gets an exception.
		/// </summary>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <returns>The Guard with an exception type set.</returns>
		public Guard ThrowArgumentNullException(string parameterName)
		{
			// Throw an exception of the specified type...
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
			// Throw an exception of the specified type...
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
			// Throw an exception of the specified type...
			this.exception = (TException)Activator.CreateInstance(typeof(TException));

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
			// Throw an exception of the specified type...
			this.exception = (TException)Activator.CreateInstance(typeof(TException), message);

			return this;
		}

		/// <summary>
		/// Conditions the specified assertion.
		/// </summary>
		/// <param name="assertion">if set to <c>true</c> [assertion].</param>
		public void When(bool assertion)
		{
			// If the assertion is true then...
			if (assertion)
			{
				throw this.exception;
			}
		}

		#endregion
	}
}