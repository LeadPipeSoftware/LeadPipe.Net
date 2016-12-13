using System;

namespace LeadPipe.Net.Commands
{
    public class CommandHandlerNotFoundException : LeadPipeNetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerNotFoundException"/> class.
        /// </summary>
        public CommandHandlerNotFoundException()
            : base("No command handler could be found for the submitted command.")
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Core;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public CommandHandlerNotFoundException(string message)
            : base(message)
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Core;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public CommandHandlerNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Core;
        }
    }
}