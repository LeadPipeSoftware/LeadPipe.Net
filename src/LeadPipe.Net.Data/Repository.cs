// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using LeadPipe.Net.Extensions;
using System;
using System.Collections.Generic;

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="T">The repository type.</typeparam>
    public class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// The object finder.
        /// </summary>
        private readonly IObjectFinder<T> objectFinder;

        private readonly RepositoryStrictness repositoryStrictness;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="dataCommandProvider">The data session.</param>
        /// <param name="objectFinder">The object finder.</param>
        /// <param name="repositoryStrictness">The strictness of the repository.</param>
        public Repository(
            IDataCommandProvider dataCommandProvider,
            IObjectFinder<T> objectFinder,
            RepositoryStrictness repositoryStrictness = RepositoryStrictness.Strict)
        {
            Guard.Will.ThrowException("No unit of work was available.").When(dataCommandProvider == null);

            this.DataCommandProvider = dataCommandProvider;
            this.objectFinder = objectFinder;
            this.repositoryStrictness = repositoryStrictness;
        }

        /// <summary>
        /// Gets the object finder entry point.
        /// </summary>
        public virtual IObjectFinder<T> Find
        {
            get
            {
                EnforceStrictMode();

                return this.objectFinder;
            }
        }

        /// <summary>
        /// Gets the repository strictness.
        /// </summary>
        public RepositoryStrictness RepositoryStrictness
        {
            get { return this.repositoryStrictness; }
        }

        /// <summary>
        /// Gets the type of object the repository manages.
        /// </summary>
        /// <value>
        /// The object type of the repository.
        /// </value>
        public Type RepositoryType
        {
            get
            {
                return typeof(T);
            }
        }

        /// <summary>
        /// Gets or sets the data session.
        /// </summary>
        protected IDataCommandProvider DataCommandProvider { get; set; }

        /// <summary>
        /// Creates a new object in the repository.
        /// </summary>
        /// <param name="obj">
        /// The object to create.
        /// </param>
        public virtual void Create(T obj)
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);

            EnforceStrictMode();

            this.DataCommandProvider.Create(obj);
        }

        /// <summary>
        /// Creates multiple new objects in the repository.
        /// </summary>
        /// <param name="objects">The objects to create.</param>
        public virtual void Create(IEnumerable<T> objects)
        {
            Guard.Will.ProtectAgainstNullArgument(() => objects);

            EnforceStrictMode();

            // Create each object...
            foreach (T entity in objects)
            {
                this.DataCommandProvider.Create(entity);
            }
        }

        /// <summary>
        /// Deletes an object from the repository.
        /// </summary>
        /// <param name="obj">The object to delete.</param>
        public virtual void Delete(T obj)
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);

            EnforceStrictMode();

            this.DataCommandProvider.Delete(obj);
        }

        /// <summary>
        /// Deletes multiple objects from the repository.
        /// </summary>
        /// <param name="objects">The objects to delete.</param>
        public virtual void Delete(IEnumerable<T> objects)
        {
            Guard.Will.ProtectAgainstNullArgument(() => objects);

            EnforceStrictMode();

            // Delete each object...
            foreach (T entity in objects)
            {
                this.DataCommandProvider.Delete(entity);
            }
        }

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public virtual T Get(object id)
        {
            EnforceStrictMode();

            return this.DataCommandProvider.Get<T>(id);
        }

        /// <summary>
        /// Gets the object with the specified id or returns null.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public virtual T Get(string id)
        {
            EnforceStrictMode();

            return this.DataCommandProvider.Get<T>(id);
        }

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public virtual T Load(object id)
        {
            EnforceStrictMode();

            return this.DataCommandProvider.Load<T>(id);
        }

        /// <summary>
        /// Loads the object with the specified id or throws an exception.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The matching object.</returns>
        public T Load(string id)
        {
            EnforceStrictMode();

            return this.DataCommandProvider.Load<T>(id);
        }

        /// <summary>
        /// Saves an object to the repository.
        /// </summary>
        /// <param name="obj">The object to save.</param>
        public virtual void Save(T obj)
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);

            EnforceStrictMode();

            this.DataCommandProvider.Save(obj);
        }

        /// <summary>
        /// Saves multiple objects to the repository.
        /// </summary>
        /// <param name="objects">The objects to save.</param>
        public virtual void Save(IEnumerable<T> objects)
        {
            Guard.Will.ProtectAgainstNullArgument(() => objects);

            EnforceStrictMode();

            // Save each object...
            foreach (T entity in objects)
            {
                this.DataCommandProvider.Save(entity);
            }
        }

        /// <summary>
        /// Updates an object in the repository.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        public virtual void Update(T obj)
        {
            Guard.Will.ProtectAgainstNullArgument(() => obj);

            EnforceStrictMode();

            this.DataCommandProvider.Update(obj);
        }

        /// <summary>
        /// Updates multiple objects in the repository.
        /// </summary>
        /// <param name="objects">The objects to update.</param>
        public virtual void Update(IEnumerable<T> objects)
        {
            Guard.Will.ProtectAgainstNullArgument(() => objects);

            EnforceStrictMode();

            // Update each object...
            foreach (T entity in objects)
            {
                this.DataCommandProvider.Update(entity);
            }
        }

        private void EnforceStrictMode()
        {
            // Do nothing if we're in open mode...
            if (this.repositoryStrictness.Equals(RepositoryStrictness.Open)) return;

            // Otherwise, throw an exception if the generic type isn't an aggregate root...
            var isAggregateRoot = typeof(IAggregateRoot).IsAssignableFrom(this.RepositoryType);

            if (!isAggregateRoot)
            {
                throw new LeadPipeNetDataException(this.RepositoryType.FullName.FormattedWith("Type {0} is not an IAggregateRoot. Please inherit from IAggregateRoot or set the RepositoryStrictness value to RepositoryStrictness.Open to suppress this error."));
            }
        }
    }
}