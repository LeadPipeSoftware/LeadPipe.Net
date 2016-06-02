// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
    /// <summary>
    /// The LeadPipe.Net exception type enumeration.
    /// </summary>
    public enum LeadPipeNetExceptionType
    {
        /// <summary>
        /// The exception is a core exception.
        /// </summary>
        Core,

        /// <summary>
        /// The exception is a business/domain exception.
        /// </summary>
        Domain,

        /// <summary>
        /// The exception is an entity validation exception.
        /// </summary>
        Validation,

        /// <summary>
        /// The exception is a data exception.
        /// </summary>
        Data,

        /// <summary>
        /// The exception is an application exception.
        /// </summary>
        Application,

        /// <summary>
        /// The exception is a distributed services exception.
        /// </summary>
        DistributedServices,

        /// <summary>
        /// The exception is a presentation exception.
        /// </summary>
        Presentation,

        /// <summary>
        /// The exception is a security exception.
        /// </summary>
        Security,

        /// <summary>
        /// The exception is an infrastructure exception.
        /// </summary>
        Infrastructure,

        /// <summary>
        /// The exception type is unknown.
        /// </summary>
        Unknown
    }
}