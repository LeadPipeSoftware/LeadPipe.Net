// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LeadPipe.Net.Extensions
{
    /// <summary>
    /// The Exception type extensions.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets the exception messages.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>A list of exception messages (recursive).</returns>
        public static IList<string> GetExceptionMessages(this Exception exception)
        {
            var exceptionMessages = new List<string> { exception.Message };

            while (exception.InnerException.IsNotNull())
            {
                exceptionMessages.Add(exception.Message);

                exception = exception.InnerException;
            }

            return exceptionMessages;
        }

        /// <summary>
        /// Gets the first exception that matches a particular type.
        /// </summary>
        /// <typeparam name="T">The exception type.</typeparam>
        /// <param name="exception">The exception.</param>
        /// <returns>The first matching exception.</returns>
        public static T GetFirstExceptionOfType<T>(this Exception exception) where T : Exception
        {
            if (exception is T)
            {
                return exception as T;
            }

            while (exception.InnerException.IsNotNull())
            {
                if (exception.InnerException is T)
                {
                    return exception.InnerException as T;
                }

                exception = exception.InnerException;
            }

            return null;
        }

        /// <summary>
        /// Determines whether [is or contains exception of type] [the specified exception].
        /// </summary>
        /// <typeparam name="T">The type to inspect.</typeparam>
        /// <param name="exception">The exception.</param>
        /// <returns>
        ///   <c>true</c> if [is or contains exception of type] [the specified exception]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOrContainsExceptionOfType<T>(this Exception exception)
        {
            if (exception is T)
            {
                return true;
            }

            while (exception.InnerException.IsNotNull())
            {
                if (exception.InnerException is T)
                {
                    return true;
                }

                exception = exception.InnerException;
            }

            return false;
        }
    }
}