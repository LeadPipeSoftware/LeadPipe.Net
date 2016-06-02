// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines a strongly-typed repository.
    /// </summary>
    /// <typeparam name="T">
    /// The type that the repository serves.
    /// </typeparam>
    public interface IRepository<T> : IWithFinder<IObjectFinder<T>>
        where T : class
    {
        /*
         * For each type of object that needs global access, create an object that can provide the
         * illusion of an in-memory collection of all objects of that type. Set up access through a
         * well-known global interface. Provide methods to add and remove objects, which will
         * encapsulate the actual insertion or removal of data in the data store. Provide methods
         * that select objects based on some criteria and return fully instantiated objects or
         * collections of objects whose attribute values meet the criteria, thereby encapsulating
         * the actual storage and query technology. Provide REPOSITORIES only for AGGREGATE roots
         * that actually need direct access. Keep the client focused on the model, delegating all
         * object storage and access to the REPOSITORIES.
         *
         * Page 152 - Evans, Eric. Domain Driven Design. 2004. Addison-Wesley. September 2010
         */

        /*
         * Anyone paying attention would likely notice that I've been careful to use the term
         * 'object' rather than 'entity' throughout this type. Why? Because while entities (well,
         * aggregate roots actually) are accessed via repositories in DDD, that doesn't mean that
         * the repository pattern doesn't have value outside of DDD as well. For that matter, we
         * should take care to remember that persistence does not necessarily mean "save it to
         * disk" and that the pattern is useful beyond CRUD.
         */

        /// <summary>
        /// Creates an object in the repository.
        /// </summary>
        /// <param name="obj">The object to create.</param>
        void Create(T obj);

        /// <summary>
        /// Creates multiple objects in the repository.
        /// </summary>
        /// <param name="objects">The objects to create.</param>
        void Create(IEnumerable<T> objects);

        /// <summary>
        /// Delete an object from the repository.
        /// </summary>
        /// <param name="obj">The object to delete.</param>
        void Delete(T obj);

        /// <summary>
        /// Delete multiple objects from the repository.
        /// </summary>
        /// <param name="objects">The objects to delete.</param>
        void Delete(IEnumerable<T> objects);

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Get(object id);

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Get(string id);

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Load(object id);

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        T Load(string id);

        /// <summary>
        /// Saves an object to the repository.
        /// </summary>
        /// <param name="obj">The object to save.</param>
        void Save(T obj);

        /// <summary>
        /// Saves multiple objects to the repository.
        /// </summary>
        /// <param name="objects">The objects to save.</param>
        void Save(IEnumerable<T> objects);

        /// <summary>
        /// Updates an object in the repository.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        void Update(T obj);

        /// <summary>
        /// Updates multiple objects in the repository.
        /// </summary>
        /// <param name="objects">The objects to update.</param>
        void Update(IEnumerable<T> objects);
    }
}