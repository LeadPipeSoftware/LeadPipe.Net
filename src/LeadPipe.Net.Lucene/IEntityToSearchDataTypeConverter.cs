// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Converts entity types to SearchData types.
    /// </summary>
    public interface IEntityToSearchDataTypeConverter<TEntity, TSearchData> where TSearchData : new()
    {
        /// <summary>
        /// Converts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TSearchData Convert(TEntity entity);
    }
}