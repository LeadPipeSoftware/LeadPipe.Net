// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace LeadPipe.Net.Authorization.Commands
{
    /// <summary>
    /// Grants a user the ability to perform any of the activities in an activity group.
    /// </summary>
    public class GrantUserActivityGroupCommand : ApplicationCommand
    {
        /// <summary>
        /// Gets or sets the name of the activity group.
        /// </summary>
        [Required]
        public string ActivityGroupName { get; set; }

        /// <summary>
        /// Gets or sets the granting user's login.
        /// </summary>
        public string GrantingUserLogin { get; set; }

        /// <summary>
        /// Gets or sets the user's login.
        /// </summary>
        [Required]
        public string Login { get; set; }
    }
}