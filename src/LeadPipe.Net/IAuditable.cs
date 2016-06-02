// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
    using System;

    /// <summary>
    /// Defines an instance that is auditable.
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Gets or sets identity of the person that created the instance.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time the instance was created.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the identity of the person that last updated the instance.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time the instance was last updated.
        /// </summary>
        DateTime? UpdatedOn { get; set; }
    }
}