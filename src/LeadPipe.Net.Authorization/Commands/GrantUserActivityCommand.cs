// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace LeadPipe.Net.Authorization.Commands
{
    /// <summary>
    /// Grants a user the ability to perform an activity.
    /// </summary>
    public class GrantUserActivityCommand : ApplicationCommand
    {
        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        [Required]
        public string ActivityName { get; set; }

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