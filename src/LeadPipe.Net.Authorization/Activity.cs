// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Activity.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
	/// Represents a single, discrete capability in the application. The smallest unit of work possible.
	/// </summary>
	public class Activity : PersistableObject<Guid>, IEntity
	{
		/// <summary>
		/// The domain id.
		/// </summary>
		private string domainId;

		/// <summary>
		/// Initializes a new instance of the <see cref="Activity" /> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="application">The application.</param>
		public Activity(string name, Application application)
		{
			this.Application = application;
			this.Name = name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Activity" /> class.
		/// </summary>
		protected Activity()
		{
		}

		#region Public Properties

		/// <summary>
		/// Gets or sets Description.
		/// </summary>
		public virtual string Description { get; set; }

		/// <summary>
		/// Gets or sets the Key.
		/// </summary>
		public virtual string Key
		{
			get
			{
				return this.Name;
			}

			set
			{
				this.domainId = value;
			}
		}

		/// <summary>
		/// Gets or sets Name.
		/// </summary>
		[Required]
        public virtual string Name { get; set; }

		/// <summary>
		/// Gets or sets the activity's application.
		/// </summary>
		[Required]
        public virtual Application Application { get; set; }

		/// <summary>
		/// Gets or sets the activity's users.
		/// </summary>
		public virtual IList<User> Users { get; protected set; }

		/// <summary>
		/// Gets or sets the activity's activity groups.
		/// </summary>
		public virtual IList<ActivityGroup> ActivityGroups { get; protected set; }

		/// <summary>
		/// Gets or sets the activity's roles.
		/// </summary>
		public virtual IList<Role> Roles { get; protected set; }

		/// <summary>
		/// Gets or sets the authorization request log entries.
		/// </summary>
		public virtual IList<AuthorizationRequestLogEntry> AuthorizationRequestLogEntries { get; protected set; }

		#endregion
	}
}