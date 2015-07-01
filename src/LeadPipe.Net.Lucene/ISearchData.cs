// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchData.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// The search data interface.
    /// </summary>
    /// <typeparam name="TIdType">The type of the identifier type.</typeparam>
    public interface ISearchData<TIdType>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        TIdType Id { get; }
    }
}
