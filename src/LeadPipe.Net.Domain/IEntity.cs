// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
    /// <summary>
    /// Defines an instance is a domain entity.
    /// </summary>
    public interface IEntity : IKeyed
    {
        /*
         * While all domain entities are keyed (that is, after all, their concern), not all keyed objects are entities
         * and this interface helps to make that clear.
         */
    }
}