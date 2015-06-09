// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeadPipeNetDataException.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace LeadPipe.Net.Data
{
	/// <summary>
	/// An base exception for the data layer.
	/// </summary>
	[Serializable]
	public class LeadPipeNetDataException : LeadPipeNetException
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LeadPipeNetDataException"/> class.
		/// </summary>
		public LeadPipeNetDataException()
			: base("A data error has occurred.")
		{
			this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Data;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LeadPipeNetDataException"/> class. 
		/// </summary>
		/// <param name="message">
		/// The exception message.
		/// </param>
		public LeadPipeNetDataException(string message)
			: base(message)
		{
			this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Data;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LeadPipeNetDataException"/> class.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="innerException">The inner exception.</param>
		public LeadPipeNetDataException(string message, Exception innerException)
			: base(message, innerException)
		{
			this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Data;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the object key associated with the exception (where applicable).
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// Gets or sets the surrogate id of the entity associated with the exception (where applicable).
		/// </summary>
		public string Sid { get; set; }

		/// <summary>
		/// Gets or sets the SQL statement associated with the exception (where applicable).
		/// </summary>
		public string Sql { get; set; }

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
				info.AddValue("Key", this.Key);
				info.AddValue("Sid", this.Sid);
				info.AddValue("Sql", this.Sql);
			}
		}

		#endregion
	}
}