// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// The data command provider.
    /// </summary>
    /// <remarks>
    /// The DataCommandProvider's job is to provide the data persistence "usual suspects".
    /// </remarks>
    public interface IDataCommandProvider
    {
        /// <summary>
        /// Gets the total number of results for the last executed query.
        /// </summary>
        int TotalResults { get; }

        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object to create.</param>
        void Create(object obj);

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="obj">The object to delete.</param>
        void Delete(object obj);

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Get<T>(object id);

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Get<T>(string id);

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Load<T>(object id);

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Load<T>(string id);

        /// <summary>
        /// Provides LINQ.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>
        /// The LINQ interface.
        /// </returns>
        IQueryable<T> Query<T>();

        /// <summary>
        /// Saves the specified object.
        /// </summary>
        /// <param name="obj">The object to save.</param>
        void Save(object obj);

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        void Update(object obj);
    }
}