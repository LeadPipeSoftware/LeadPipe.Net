// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeadPipeNetException.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Defines a base LeadPipe.Net exception.
	/// </summary>
	[Serializable]
	public class LeadPipeNetException : Exception
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LeadPipeNetException"/> class.
		/// </summary>
		public LeadPipeNetException()
			: base("An error has occurred.")
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LeadPipeNetException"/> class.
		/// </summary>
		/// <param name="message">
		/// The exception message.
		/// </param>
		public LeadPipeNetException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LeadPipeNetException"/> class.
		/// </summary>
		/// <param name="message">
		/// The exception message.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		public LeadPipeNetException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the type of the LeadPipe.Net exception.
		/// </summary>
		public LeadPipeNetExceptionType LeadPipeNetExceptionType { get; set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		/// <PermissionSet>
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
		///   </PermissionSet>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			if (info != null)
			{
				info.AddValue("LeadPipeNetExceptionType", this.LeadPipeNetExceptionType);
			}
		}

		#endregion
	}
}