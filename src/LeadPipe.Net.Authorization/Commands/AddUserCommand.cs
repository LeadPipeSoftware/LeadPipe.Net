// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace LeadPipe.Net.Authorization.Commands
{
    /// <summary>
    /// Adds a user to the application.
    /// </summary>
    public class AddUserCommand : ApplicationCommand
    {
        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the user's login.
        /// </summary>
        [Required]
        public string Login { get; set; }
    }
}