// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LeadPipe.Net.Domain;
using LeadPipe.Net.Extensions;
using LeadPipe.Net.Validation;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
	/// An application user.
	/// </summary>
	public class User : PersistableObject<Guid>, IEntity
	{
		/// <summary>
		/// The domain id.
		/// </summary>
		private string domainId;

		/// <summary>
		/// The user's expiration date.
		/// </summary>
		private DateTime? expirationDate;

		/// <summary>
		/// Determines if the user is active.
		/// </summary>
		private bool isActive;

		/// <summary>
		/// Initializes a new instance of the <see cref="User" /> class.
		/// </summary>
		/// <param name="userName">Name of the user.</param>
		/// <param name="firstName">The first name.</param>
		/// <param name="lastName">The last name.</param>
		public User(string userName, string firstName, string lastName)
		{
			this.Name = userName;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.UserGrants = new List<UserGrant>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="User" /> class.
		/// </summary>
		protected User()
		{
			this.UserGrants = new List<UserGrant>();
		}

		/// <summary>
		/// Gets or sets the administered applications.
		/// </summary>
		/// <value>The administered applications.</value>
		public virtual IList<Application> AdministeredApplications { get; protected set; }

		/// <summary>
		/// Gets or sets the user's applications.
		/// </summary>
		/// <value>The applications.</value>
		public virtual IList<ApplicationUser> Applications { get; protected set; }

		/// <summary>
		/// Gets or sets the authorization request log entries.
		/// </summary>
		/// <value>The authorization request log entries.</value>
		public virtual IList<AuthorizationRequestLogEntry> AuthorizationRequestLogEntries { get; protected set; }

		/// <summary>
		/// Gets or sets the user's expiration date.
		/// </summary>
		/// <value>The expiration date.</value>
		public virtual DateTime? ExpirationDate
		{
			get
			{
				return this.expirationDate;
			}

			set
			{
				this.expirationDate = value;

				// If we're expired then automatically inactivate...
				if (this.IsExpired)
				{
					this.isActive = false;
				}
			}
		}

		/// <summary>
		/// Gets or sets the user's first name (ex: Greg).
		/// </summary>
		/// <value>The first name.</value>
        [Required]
        [NoTrailingWhitespace]
        [NoLeadingWhitespace]
        [Alpha(" ", "'", "-")]
        public virtual string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the user's initials (ex: GBM).
		/// </summary>
		/// <value>The initials.</value>
        [Alpha]
        [NoLowerCase]
        [NoTrailingWhitespace]
        [NoLeadingWhitespace]
        public virtual string Initials { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the user is active.
		/// </summary>
		/// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
		public virtual bool IsActive
		{
			get
			{
				// If we're expired then automatically inactivate...
				if (this.IsExpired)
				{
					this.isActive = false;
				}

				return this.isActive;
			}

			set
			{
				// If we're expired then automatically inactivate...
				if (this.IsExpired)
				{
					this.isActive = false;
				}

				this.isActive = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the user has expired.
		/// </summary>
		/// <value><c>true</c> if this instance is expired; otherwise, <c>false</c>.</value>
		public virtual bool IsExpired
		{
			get
			{
				if (this.ExpirationDate == null)
				{
					return false;
				}

				return this.ExpirationDate <= DateTime.Now;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the user is a super administrator (SA).
		/// </summary>
		/// <value><c>true</c> if this instance is super administrator; otherwise, <c>false</c>.</value>
		public virtual bool IsSuperAdministrator { get; set; }

		/// <summary>
		/// Gets or sets the natural id.
		/// </summary>
		/// <value>The key.</value>
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
		/// Gets or sets the user's last name (ex: Major).
		/// </summary>
		/// <value>The last name.</value>
        [Required]
        [NoTrailingWhitespace]
        [NoLeadingWhitespace]
        [Alpha(" ", "'", "-", ".")]
        public virtual string LastName { get; set; }

		/// <summary>
		/// Gets or sets the user's name (ex: AMERICAS\majorgb).
		/// </summary>
		/// <value>The name.</value>
        [Required]
        [NoTrailingWhitespace]
        [NoLeadingWhitespace]
        public virtual string Name { get; protected set; }

		/// <summary>
		/// Gets or sets the user's hashed password.
		/// </summary>
		/// <value>The password hash.</value>
		public virtual string PasswordHash { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public virtual string Title { get; set; }

		/// <summary>
		/// Gets or sets the user grants.
		/// </summary>
		/// <value>The user grants.</value>
		public virtual IList<UserGrant> UserGrants { get; protected set; }

		/// <summary>
		/// Gets the effective permissions.
		/// </summary>
		/// <param name="application">The application.</param>
		/// <returns>The list of effective permissions.</returns>
		public virtual IList<Activity> GetEffectiveActivities(Application application)
		{
			Guard.Will.ThrowArgumentNullException("Application").When(application.IsNull());

			var validUserGrants = this.UserGrants.Where(x => x.ExpirationDate.IsNull() || x.ExpirationDate >= DateTime.Now);

			var effectiveActivities = validUserGrants.SelectMany(x => x.EffectiveActivities);

			return application.Activities.Intersect(effectiveActivities).ToList();
		}
	}
}