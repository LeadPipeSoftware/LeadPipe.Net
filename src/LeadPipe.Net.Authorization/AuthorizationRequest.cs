// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizationRequest.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
	/// The authorization request.
	/// </summary>
	public class AuthorizationRequest
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the name of the activities.
		/// </summary>
		public virtual IEnumerable<Activity> Activities { get; set; }

        /// <summary>
        /// Gets or sets the application user.
        /// </summary>
        /// <value>
        /// The application user.
        /// </value>
        public virtual ApplicationUser ApplicationUser { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether all activities in the list.
		/// </summary>
		/// <value>
		///   <c>true</c> if [authorize all]; otherwise, <c>false</c>.
		/// </value>
		public virtual bool AuthorizeAll { get; set; }

		#endregion
	}
}