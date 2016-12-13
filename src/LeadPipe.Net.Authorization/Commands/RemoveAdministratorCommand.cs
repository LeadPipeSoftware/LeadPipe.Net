// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace LeadPipe.Net.Authorization.Commands
{
    /// <summary>
    /// Removes an administrator from the application.
    /// </summary>
    public class RemoveAdministratorCommand : ApplicationCommand
    {
        /// <summary>
        /// Gets or sets the user's login.
        /// </summary>
        [Required]
        public string Login { get; set; }
    }
}