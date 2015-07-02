// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizationRequestLogEntry.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
	/// The authorization request log entry.
	/// </summary>
	public class AuthorizationRequestLogEntry : PersistableObject<Guid>
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the activity.
		/// </summary>
		[Required]
        public virtual Activity Activity { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the request was granted or denied.
		/// </summary>
		public virtual bool Granted { get; set; }

		/// <summary>
		/// Gets or sets the request date and time.
		/// </summary>
        public virtual DateTime RequestedOn { get; set; }

		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		[Required]
        public virtual User User { get; set; }

		/// <summary>
		/// Gets or sets the granting user.
		/// </summary>
		/// <value>
		/// The granting user.
		/// </value>
		public virtual string GrantingUser { get; set; }

        /// <summary>
        /// Gets or sets the granted on.
        /// </summary>
        /// <value>
        /// The granted on date and time.
        /// </value>
		public virtual DateTime GrantedOn { get; set; }

		#endregion
	}
}