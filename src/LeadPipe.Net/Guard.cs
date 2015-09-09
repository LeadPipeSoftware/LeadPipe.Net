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
			if (argument().IsNotNull())
			{
				return;
			}

            var message = string.Format("Argument of type '{0}' cannot be null.", typeof(T));

		    var fieldName = GetFieldName(argument);

		    if (fieldName.IsNotNull())
		    {
                throw new ArgumentNullException(fieldName, message);
		    }

			throw new ArgumentNullException(message);
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

            var fieldName = GetFieldName(argument);

            if (fieldName.IsNotNull())
            {
                throw new ArgumentOutOfRangeException(fieldName, message);
            }
            
            throw new ArgumentOutOfRangeException(message);
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

	        var fieldName = GetFieldName(argument);

	        if (fieldName.IsNotNull())
	        {
                throw new ArgumentNullException(fieldName, message);
	        }

			throw new ArgumentNullException(message);
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

        #region Private Methods

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